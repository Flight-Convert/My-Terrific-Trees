/*
 * Anthony Wessel
 * Project 4-7 | My Terrific Trees!
 * Places a sapling wherever the player clicks
 */
using UnityEngine;
using UnityEngine.UI;

public class TreePlanter : MonoBehaviour
{
    public GameObject treePrefab;
    public int remainingTrees = 5;
    public Text treeCountText;

    GameBoard board;


    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<GameBoard>();
        if (treePrefab == null) Debug.LogWarning("No tree prefab set. Will throw error if TreePlanter tries to plant a tree.");
        if (treeCountText == null) Debug.LogWarning("No tree count text is set. There is no UI keeping track of remaining trees.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            Vector2Int mouseTile = new Vector2Int((int)Mathf.Round(mousePos.x), (int)Mathf.Round(mousePos.z));

            if (remainingTrees > 0)
            {
                PlantTreeOnTile(mouseTile);
                Debug.Log("mouseTile Coords at plant: " + mouseTile);
            }
            else
                Debug.Log("You are out of trees!");
        }

        if (treeCountText != null)
           treeCountText.text = "Trees Remaining: " + remainingTrees;
    }

    public void PlantTreeOnTile(Vector2Int tileCoordinates)
    {
        /// Player clicked off of the grid, don't try to plant a tree
        if (tileCoordinates.x < -board.size.x / 2 || tileCoordinates.x > board.size.x / 2) return;
        if (tileCoordinates.y < -board.size.y / 2 || tileCoordinates.y > board.size.y / 2) return;

        /// Adjust the coordinates to be completely positive (so they can be passed into the tile array)
        tileCoordinates.x += board.size.x / 2;
        tileCoordinates.y += board.size.y / 2;
        int tileX = board.size.x - tileCoordinates.x-1;
        int tileY = board.size.y - tileCoordinates.y-1;

        /// Get the tile
        Transform tile = board.tileArray[tileX + board.size.x* tileY].transform;

        /// Plant the tree
        if (tile.childCount < 2)
        {
            Instantiate(treePrefab, tile);
            remainingTrees--;
        }
        
    }
}
