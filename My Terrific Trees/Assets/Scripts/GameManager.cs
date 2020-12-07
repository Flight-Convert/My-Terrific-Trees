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
    private Image carbonMeter;
    private CheckTreeCount treeCheck;
    private AudioSource music;

    public bool ended;
    public bool won;
    public float targetScore;
    public float score;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;
    public AudioClip music5;

    #region Singleton code
    public static GameManager instance;

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
                "instance of singleton Game Manager");
        }
    }
    #endregion

    void Start()
    {
        ended = false;
        won = false;
        score = 0;
        targetScore = 20;
        music = GetComponent<AudioSource>();
        treeCheck = GameObject.FindGameObjectWithTag("TreeCheck").GetComponent<CheckTreeCount>();
        endText = GameObject.FindGameObjectWithTag("EndText").GetComponent<Text>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        carbonMeter = GameObject.FindGameObjectWithTag("CarbonMeter").GetComponent<Image>();
        endText.text = "";
    }

    void Update()
    {
        if(treeCheck == null)
        {
            treeCheck = GameObject.FindGameObjectWithTag("TreeCheck").GetComponent<CheckTreeCount>();
            endText = GameObject.FindGameObjectWithTag("EndText").GetComponent<Text>();
            scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
            //endText.gameObject.SetActive(false);
        }
        if(score >= targetScore && ended != true)
        {
            won = true;
            ended = true;
        }
        if (ended)
        {
            //endText.gameObject.SetActive(true);
            if (won)
            {
                endText.text = "You Won!\nPress R To Restart\nPress N For the Next Level";
            }
            else
            {
                endText.text = "You Lose!\nPress R To Restart";
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                score = 0;
                if(SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1)
                {
                    targetScore = 20;
                }
                else
                {
                    targetScore = 10;
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKeyDown(KeyCode.N) && won)
            {
                score = 0;
                if (SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings - 1)
                {
                    targetScore = 20;
                }
                else
                {
                    targetScore = 10;
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        int timeIndex = music.timeSamples;
        AudioClip newClip;
        if (1 - (score / targetScore) >= 0.8)
        {
            newClip = music1;
        }
        else if (1 - (score / targetScore) >= 0.6)
        {
            newClip = music2;
        }
        else if (1 - (score / targetScore) >= 0.4)
        {
            newClip = music3;
        }
        else if (1 - (score / targetScore) >= 0.2)
        {
            newClip = music4;
        }
        else
        {
            newClip = music5;
        }
        if (!music.isPlaying)
        {
            music.clip = newClip;
            music.Play();
        }
        scoreText.text = "CO2 Levels: " + (score <= targetScore ? 100 - ((score / targetScore) * 100) : 0) + "%";
        if (score <= targetScore)
        {
            carbonMeter.gameObject.transform.localScale = new Vector3((100 - (score / targetScore) * 100) / 100, 1, 1);
        }
    }
}
