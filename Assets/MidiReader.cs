using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAudio;
using NAudio.Midi;
using System.IO;
using System;

public class MidiReader : MonoBehaviour
{
    public static MidiReader Instance { get; private set; }

    private IList<MidiEvent> tempoGetter;
    private MidiFile midi;
    private NoteOnEvent newNoteEvent = null;

    private float millisecondsPerTick;
    private float tempo = 0;
    private float newStartTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        millisecondsPerTick = (60000f / (90f * 96f));
        InitializeMidi();
        InitializeTempo();
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        foreach (MidiEvent note in midi.Events[1])
        {
            if (note is NoteOnEvent)
            {
                newNoteEvent = note as NoteOnEvent;
                newStartTime = ((float)((newNoteEvent.AbsoluteTime / (float)midi.DeltaTicksPerQuarterNote) * tempo));
                Debug.Log(newStartTime);
                NoteSpawner.Instance.SpawnNoteInTime(newStartTime / 1000);
            }
        }
    }

    private void InitializeTempo()
    {
        foreach (var temp in tempoGetter)
        {
            if (temp is TempoEvent)
            {
                tempo = (float)(temp as TempoEvent).MicrosecondsPerQuarterNote / 1000f;
            }
        }
    }

    public void InitializeMidi()
    {
        midi = new MidiFile("Assets/heh" + ".mid");
        // string[] files;
        // files = Directory.GetFiles(Directory.GetCurrentDirectory());
        // var info = new DirectoryInfo(Directory.GetCurrentDirectory());
        // var fileInfo = info.GetFiles();
        // for (int i = 0; i < files.Length; i++)
        // {
        //     if (files[i].EndsWith(".mid"))
        //     {
        //     }
        // }
        tempoGetter = midi.Events.GetTrackEvents(0);
    }
}