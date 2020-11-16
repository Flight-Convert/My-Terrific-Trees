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
    TreePlanter tp;
    public int maxActionNum;
    public int actionNum = 0;
    public bool isPlayerTurn;
    [HideInInspector] public int turnCount;
    public int numberOfEnemies;
    public int enemyTurnsCount;

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
        tp = FindObjectOfType<TreePlanter>();
        turnCount = 0;
        isPlayerTurn = true;
    }

    private void FixedUpdate()
    {
        if(actionNum >= maxActionNum)
        {
            endTurn();
            actionNum = 0;
        }
        numberOfEnemies = FindObjectsOfType<Woodcutter>().Length;

        if(enemyTurnsCount == numberOfEnemies && numberOfEnemies != 0)
        {
            enemyTurnsCount = 0;
            startTurn();
        }
        if(tp.remainingTrees <= 0)
        {
            StartCoroutine("EndSequence");
        }
    }

    IEnumerator EndSequence()
    {
        int numYoungTrees = GameObject.FindGameObjectsWithTag("Sapling").Length
                            + GameObject.FindGameObjectsWithTag("Small Tree").Length;
        while (numYoungTrees > 0)
        {
            yield return new WaitForSeconds(1f);
            endTurn();
            if (numberOfEnemies > 0)
            {
                startTurn();
            }
            numYoungTrees = GameObject.FindGameObjectsWithTag("Sapling").Length + GameObject.FindGameObjectsWithTag("Small Tree").Length;
        }
        GameManager.instance.ended = true;
    }

    public void endTurn()
    {
        isPlayerTurn = false;
        Debug.Log("The player's turn has ended");
        if (numberOfEnemies == 0)
        {
            startTurn();
        }
    }

    public void startTurn()
    {
        turnCount++;
        isPlayerTurn = true;
        Debug.Log("The player's turn has started");
    }
}
