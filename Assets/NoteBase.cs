using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NoteBase : MonoBehaviour
{
    public float movementSpeed;
    public Image image;
    private bool canMove = true;

    private void Awake()
    {
        image.DOFade(1, 0.3f).From(0);
    }

    public void HandleTap()
    {
        TilesManager.Instance.UnlockRandomTile();
        canMove = false;
        FadeOut();
        transform.DOScale(0, 0.3f).OnComplete(() => NoteSpawner.Instance.RemoveNoteFromList(this));
    }

    private void FixedUpdate()
    {
        if (canMove)
            transform.position += new Vector3(0, movementSpeed * Time.deltaTime, 0);
    }

    public void FadeOut()
    {
        image.DOFade(0, 0.3f);
    }
}