/*
 * Liam Barrett
 * Project 4-7 | My Terrific Trees
 * Controls tutorial pop ups at the beginning of the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text[] popUps;
    public int popUpIndex;

    private void Start()
    {
        popUpIndex = 0;
    }

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            popUps[i].gameObject.SetActive(i == popUpIndex);
        }

        if (popUpIndex == 0 || popUpIndex == 1 || popUpIndex == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            int clickCount = 0;
            if (Input.GetMouseButtonDown(0))
            {
                clickCount++;
            }
            if (clickCount >= 3)
            {
                popUpIndex++;
            }
        }
    }
}
