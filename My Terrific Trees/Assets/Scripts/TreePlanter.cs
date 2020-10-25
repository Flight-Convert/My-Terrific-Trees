/*
 * Anthony Wessel
 * Project 4-7 | My Terrific Trees!
 * Places a sapling wherever the player clicks
 */
using UnityEngine;

public class TreePlanter : MonoBehaviour
{
    public GameObject treePrefab;

    GameBoard board;

    // Start is called before the first frame update
    void Start()
    {
        board = GetComponent<GameBoard>();
        if (treePrefab == null) Debug.LogWarning("No tree prefab set. Will throw error if TreePlanter tries to plant a tree");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            Vector2Int mouseTile = new Vector2Int((int)Mathf.Round(mousePos.x), (int)Mathf.Round(mousePos.z));

            print(mouseTile);
            PlantTree(mouseTile);
        }
    }

    public void PlantTree(Vector2 position)
    {
        Instantiate(treePrefab, new Vector3(-position.x, 0, -position.y), treePrefab.transform.rotation);
    }
}
