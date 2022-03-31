using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSelect : MonoBehaviour
{
    public static Sprite character { get; set; }

    void Start() 
    {
        character = Resources.Load<Sprite>("liam");
    }

    public void Ben()
    {
        character = Resources.Load<Sprite>("Ben");

        Character data = new Character
        { 
            Selected = character
        };

        SceneManager.LoadScene("MainGame");
    }

    public void Tomatoe()
    {
        character = Resources.Load<Sprite>("tomatoe");

        Character data = new Character
        { 
            Selected = character
        };

        SceneManager.LoadScene("MainGame");
    }

    public void Lean_Bear()
    {
        character = Resources.Load<Sprite>("Lean Bear");

        Character data = new Character
        { 
            Selected = character
        };

        SceneManager.LoadScene("MainGame");
    }

    public void Liam()
    {
        character = Resources.Load<Sprite>("liam");

        Character data = new Character
        { 
            Selected = character
        };

        SceneManager.LoadScene("MainGame");
    }
}
