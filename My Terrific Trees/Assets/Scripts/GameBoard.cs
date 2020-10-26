using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public Transform ground;
    public Vector2Int size;
    public GameTile tilePrefab;
    public GameTile[] tileArray;

    void Awake()
    {
        //creates the gameboard with preset size
        ground.localScale = new Vector3(size.x, size.y, 1f);

        Vector2 offset = new Vector2((size.x - 1) * 0.5f, (size.y - 1) * 0.5f);

        tileArray = new GameTile[size.x * size.y];

        //create a tile at each unit on the game board
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                GameTile tile = Instantiate(tilePrefab);
                tile.transform.SetParent(transform, false);
                tile.transform.localPosition = new Vector3(x - offset.x, 0f, y - offset.y);
                tileArray[(size.x * y) + x] = tile;
            }
        }
    }
}
