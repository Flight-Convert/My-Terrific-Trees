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

    public Vector2Int boardSize;


    // Start is called before the first frame update
    void Start()
    {
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
                //Debug.Log("mouseTile Coords at plant: " + mouseTile);
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
        if (tileCoordinates.x <= -boardSize.x / 2 || tileCoordinates.x > boardSize.x / 2) return;
        if (tileCoordinates.y <= -boardSize.y / 2 || tileCoordinates.y > boardSize.y / 2) return;

        /// Check if tree is already planted at this spot
        if (true) 
        {
            /// Plant the tree
            Instantiate(treePrefab, new Vector3(tileCoordinates.x, 0, tileCoordinates.y), treePrefab.transform.rotation);
            remainingTrees--;
        }
        
    }
}
