using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene("Undead Survivor/Demo/Demo");
    }

    public void PlayButton()
    {
        MainMenuAnimation anim = new MainMenuAnimation();
        anim.PlayFromMain();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
