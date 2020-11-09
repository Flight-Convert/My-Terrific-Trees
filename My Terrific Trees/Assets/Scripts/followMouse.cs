/*
 * Liam Barrett
 * Project 4-7 | My Terrific Trees
 * Script for selection indicator to follow mouse position
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour
{
    Vector3 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.y = 0;
        if (mousePos.x <= 5 && mousePos.x >= -5 && mousePos.z <= 5 && mousePos.z >= -5)
        {
            transform.position = mousePos;
        }
    }
}
