using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public void Retry()
    {
        SceneManager.LoadScene("Scenes/MainGame");
    }

    public void Character()
    {
        SceneManager.LoadScene("Scenes/CharacterSelect");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
