using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonController : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("HowTo");
    }

    public void NextButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
