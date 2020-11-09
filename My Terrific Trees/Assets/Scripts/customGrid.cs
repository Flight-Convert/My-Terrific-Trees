/*
 * Liam Barrett
 * Project 4-7 | My Terrific Trees
 * Locks griddable objects to grid-based movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customGrid : MonoBehaviour
{
    public GameObject[] targets;
    public float gridSize;

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Griddable");
    }

    void LateUpdate()
    {
        for (int i = 0; i < targets.Length; ++i)
        {
            Vector3 truePos;

            truePos.x = Mathf.Round(targets[i].transform.position.x / gridSize) * gridSize;
            truePos.y = Mathf.Round(targets[i].transform.position.y / gridSize) * gridSize;
            truePos.z = Mathf.Round(targets[i].transform.position.z / gridSize) * gridSize;

            targets[i].transform.position = truePos;
        }
    }
}
