using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TileBase : MonoBehaviour
{
    [SerializeField] private Color lockedColor;
    [SerializeField] private Color unlockedColor;
    [SerializeField] private MeshRenderer meshRenderer;
    public float duration;
    public float shit;
    private void Awake()
    {
        ChangeColor(lockedColor);
        // ChangeColor(unlockedColor);
    }

    private void ChangeColor(Color newColor)
    {
        meshRenderer.material.color = newColor;
    }

    public void UnlockTile()
    {
        ChangeColor(unlockedColor);
        transform.DORotate(new Vector3(-180, 0, 0), 0.5f).SetEase(Ease.OutBack);
        transform.DOScale(0.8f, 0.25f).SetEase(Ease.InOutBack).SetLoops(2, LoopType.Yoyo);
    }
}