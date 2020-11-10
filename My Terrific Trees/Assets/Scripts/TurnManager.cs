/*
 * Liam Barrett
 * Project 4-7 | My Terrific Trees
 * Manages turns and action counts for the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public int maxActionNum;
    public bool isPlayerTurn;
    [HideInInspector] public int turnCount;

    #region Singleton code
    public static TurnManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second" +
                "instance of singleton Turn Manager");
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        turnCount = 0;
        isPlayerTurn = true;
    }

    public void endTurn()
    {
        isPlayerTurn = false;
        Debug.Log("The player's turn has ended");
    }

    public void startTurn()
    {
        turnCount++;
        isPlayerTurn = true;
        Debug.Log("The player's turn has started");
    }
}
