/*
 * Broc Edson
 * Project 4-7 | My Terrific Trees
 * Manages victory and loss conditions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Text endText;
    private Text scoreText;
    private CheckTreeCount treeCheck;

    public bool ended;
    public bool won;
    public float targetScore = 20;
    public float score = 0;

    #region Singleton code
    public static GameManager instance;

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

    void Start()
    {
        ended = false;
        won = false;
        treeCheck = GameObject.FindGameObjectWithTag("TreeCheck").GetComponent<CheckTreeCount>();
        endText = GameObject.FindGameObjectWithTag("EndText").GetComponent<Text>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        endText.gameObject.SetActive(false);
    }

    void Update()
    {
        if(treeCheck == null)
        {
            treeCheck = GameObject.FindGameObjectWithTag("TreeCheck").GetComponent<CheckTreeCount>();
            endText = GameObject.FindGameObjectWithTag("EndText").GetComponent<Text>();
            scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
            endText.gameObject.SetActive(false);
        }
        if(score >= targetScore && ended != true)
        {
            won = true;
            ended = true;
        }
        if (ended)
        {
            endText.gameObject.SetActive(true);
            if (won)
            {
                endText.text = "You Won!\nPress R To Restart";
            }
            else
            {
                endText.text = "You Lose!\nPress R To Restart";
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                ended = false;
                won = false;
                targetScore = 20;
                score = 0;

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        scoreText.text = "CO2 Levels: " + (score <= targetScore ? 100 - ((score / targetScore) * 100) : 0) + "%";
    }
}
