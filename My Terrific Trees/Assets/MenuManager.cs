using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject LevelSelectPanel;

    // Start is called before the first frame update
    void Start()
    {
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        MainMenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
    }

    public void LoadLevelSelect()
    {
        MainMenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
    }

    public void LoadGame(int index)
    {
        MainMenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(false);

        SceneManager.LoadScene(index);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            LoadMainMenu();
    }
}
