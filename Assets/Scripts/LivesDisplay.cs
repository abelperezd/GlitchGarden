using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;

    float lives;
    Text livesText;

    void Start()
    {
        if (baseLives - PlayerPrefsController.GetDifficulty() > 0)
            lives = baseLives - PlayerPrefsController.GetDifficulty();
        else
            lives = baseLives;
        livesText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("Current difficulty: " + PlayerPrefsController.GetDifficulty());
    }

    void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

}
