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

    //For use in Inspector Debugging only!!!
    public bool makeGrow = false;

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
        
        //For use in Inspector Debugging only!!!
        if(makeGrow == true)
        {
            GrowTree();
            makeGrow = false;
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
