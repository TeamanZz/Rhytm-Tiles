using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public static TilesManager Instance;
    public List<TileBase> lockedTiles = new List<TileBase>();
    public List<TileBase> unlockedTiles = new List<TileBase>();

    private void Awake()
    {
        Instance = this;
    }

    public void UnlockRandomTile()
    {
        if (lockedTiles.Count == 0)
            return;

        int randomIndex = Random.Range(0, lockedTiles.Count);
        lockedTiles[randomIndex].UnlockTile();
        unlockedTiles.Add(lockedTiles[randomIndex]);
        lockedTiles.RemoveAt(randomIndex);
    }
}