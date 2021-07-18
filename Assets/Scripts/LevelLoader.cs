using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;

    int currenSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currenSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currenSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("1.Start");
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("1.Options");
    }

    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().name == "2.Level 6")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            if (PlayerPrefsController.GetDifficulty() > 0)
                PlayerPrefsController.SetDifficulty(PlayerPrefsController.GetDifficulty() + 1);
        }
        else
        {
            SceneManager.LoadScene(currenSceneIndex + 1);
        }
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("1.Lose");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            QuitGame();
    }
}
