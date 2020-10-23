using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private Queue<GameObject> _tilePool;

    public int maxTiles;

    // Start is called before the first frame update
    void Awake()
    {
        _tilePool = new Queue<GameObject>();
        _BuildTilePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _BuildTilePool()
    {
        for (var count = 0; count < maxTiles; count++)
        {
            //enqueue new file from factory
            var tempTile = TileFactory.Instance().CreateTile();
            tempTile.SetActive(false);
            _tilePool.Enqueue(tempTile);
        }
    }


    //removes tile from pool
    public GameObject GetTile()
    {
        var tempTile = _tilePool.Dequeue();
        tempTile.SetActive(true);
        return tempTile;
    }

    //returns tile back to the pool
    public void ReturnTile(GameObject tile)
    {
        tile.SetActive(false);
        _tilePool.Enqueue(tile);
    }
}
