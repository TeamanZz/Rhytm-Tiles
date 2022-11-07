using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NoteSpawner : MonoBehaviour
{
    public static NoteSpawner Instance;
    public GameObject notePrefab;
    public Transform notesContainer;
    public List<Transform> noteSpawnPositions = new List<Transform>();
    public List<NoteBase> noteList = new List<NoteBase>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // StartCoroutine(SpawnNoteRecursively());
    }

    public void SpawnNoteInTime(float time)
    {
        StartCoroutine(SpawnNote(time));
    }

    private IEnumerator SpawnNote(float time)
    {
        yield return new WaitForSeconds(time);
        Vector3 spawnPlace = noteSpawnPositions[Random.Range(0, noteSpawnPositions.Count)].position;
        var newNote = Instantiate(notePrefab, spawnPlace, Quaternion.identity, notesContainer);
        noteList.Add(newNote.GetComponent<NoteBase>());
    }

    public void RemoveNoteFromList(NoteBase note)
    {
        Destroy(note.gameObject);
        noteList.Remove(note);
    }
}