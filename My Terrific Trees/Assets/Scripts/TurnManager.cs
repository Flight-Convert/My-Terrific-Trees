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
    //public int enemyTurnsCount; //Dont use in new

    public int round_enemyMoves = 0; //Don't need maxMoves, just check against numberOfEnemies value for bounds
    public int round_currentRound = 0;
    public int round_maxRounds = 1; //If scene has Woodcutter of level > 1, set maxRounds to that value (use a helper function to pass in level_UP) 


    #region Singleton code
    public static TurnManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
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

        if (!isPlayerTurn && numberOfEnemies != 0)
        {

        }

        /*if(enemyTurnsCount == numberOfEnemies && numberOfEnemies != 0) //change to new implementation
        {
            enemyTurnsCount = 0;
            startTurn();
        }*/// vvv Changed to vvv

        if (round_enemyMoves >= numberOfEnemies)
        {
            //reset enemyMoves
            round_enemyMoves = 0;
            
            if (round_currentRound + 1 > round_maxRounds)
            {
                round_currentRound = 0; //Should stop additional logic from occuring
                startTurn();
            }
            else //start new round
            {
                round_currentRound += 1;
            }
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

    /// <summary>
    /// Ending the player's turn
    /// </summary>
    public void endTurn()
    {
        isPlayerTurn = false;
        
        Debug.Log("The player's turn has ended");
        /*if (numberOfEnemies == 0)
        {
            startTurn();
        }*/
        round_currentRound = 1;
    }

    /// <summary>
    /// Starting the player's turn
    /// </summary>
    public void startTurn()
    {
        isPlayerTurn = true;
        
        round_currentRound = 0; //set currentRound variable to produce no output
        turnCount++;

        Debug.Log("The player's turn has started"); 
    }

    /// <summary>
    /// More than often, on normal level_UP, have 'addition' as '1'
    /// </summary>
    /// <param name="addition"></param>
    public void increment_MaxRounds(int addition)
    {   
        round_maxRounds += addition;
        Debug.Log("Added [" + addition +  "] round_maxRounds: " + round_maxRounds);
    }

    /// <summary>
    /// Tells TurnManager that a Woodcutter has completed their action for the round
    /// </summary>
    public void increment_EnemyMoves()
    {
        round_enemyMoves++;
        Debug.Log("Enemy finished during this round");
    }

}
