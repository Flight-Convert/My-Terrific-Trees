/*
 * Liam Barrett
 * Project 4-7 | My Terrific Trees
 * Makes trees grow over time
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrower : MonoBehaviour
{
    public GameObject smallTreePrefab;
    public GameObject bigTreePrefab;

    [HideInInspector] public int turnPlanted;
    [HideInInspector] public int turnsSincePlanted;

    // Start is called before the first frame update
    void Start()
    {
        turnPlanted = TurnManager.instance.turnCount;
    }

    private void Update()
    {
        turnsSincePlanted = turnPlanted - TurnManager.instance.turnCount;
        if (turnsSincePlanted == 2)
        {
            GrowTree();
        }
    }

    private void GrowTree()
    {
        if (gameObject.CompareTag("Sapling"))
        {
            Instantiate(smallTreePrefab, transform.position, transform.rotation);
        }
        else if (gameObject.CompareTag("Small Tree"))
        {
            Instantiate(bigTreePrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
