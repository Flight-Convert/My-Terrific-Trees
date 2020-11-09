/*
 * Anthony Wessel
 * Project 4-7 | My Terrific Trees!
 * Checks if all trees are gone, and thus the player has lost
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTreeCount : MonoBehaviour
{
    TreePlanter tp;
    bool lost = false;

    private void Start()
    {
        tp = FindObjectOfType<TreePlanter>();
        if (tp == null) Debug.LogWarning("There is no tree planter in the scene.");
    }

    void Update()
    {
        if (tp.remainingTrees <= 0)
        {
            int numTrees = GameObject.FindGameObjectsWithTag("Tree").Length
                + GameObject.FindGameObjectsWithTag("Sapling").Length
                + GameObject.FindGameObjectsWithTag("Small Tree").Length;
            if (numTrees == 0)
            {
                if (!lost)
                {
                    Debug.Log("There are no trees remaining. You lose!");
                    lost = true;
                }
            }
        }
    }
}
