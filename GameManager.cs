using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image gameOverManu;
    public TextMeshProUGUI Timer;

    public float timeRemaining = 5;


    void Start()
    {
        UpdateTime(timeRemaining);
        gameOverManu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTime(timeRemaining);
        }
        else
        {
            UpdateTime(0);
            GameOver();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void UpdateTime(float timeLeft)
    {
        Timer.text = "Time remaining : " + timeLeft;
    }
    public void GameOver()
    {
        gameOverManu.gameObject.SetActive(true);
    }
}
