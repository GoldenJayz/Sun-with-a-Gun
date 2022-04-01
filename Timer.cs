using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public const float targetTime = 10f;
    public float time = 0f;
    public int frame = 0;
    public Text chickenNug;
    public Sprite sprite;
    public Sprite sprite2;


    private GameObject _player;
    private Main _otherScript;
    private GameObject _nextBlock;
    private GameObject sun;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("character"); // Finds the _player so we can check the players Y position later
        _otherScript = _player.GetComponent<Main>();
        time = targetTime;
        // Create a new Timer object everytime the _player lands on a new block
        // Shrink the time based on how many GameObjects are loaded in
        // Game is clamped down to 60 FPS
        sprite = Resources.Load<Sprite>("VERYANGRYSUN");
        sprite2 = Resources.Load<Sprite>("happysun");
        sun = GameObject.Find("Image");
    }

    // Update is called once per frame
    void Update()
    {
        try { _nextBlock = _otherScript.objects[_otherScript.objects.Count - 1]; }
        catch { _nextBlock = null; }

        if (_nextBlock is not null) 
        {

            time -= Time.deltaTime;
            int rounded = (int)Math.Round(time, 0);

            chickenNug.text = rounded.ToString();

            if (time <= 0f && _nextBlock.tag != "alreadyTagged")
            {
                SceneManager.LoadScene("Scenes/GameOver");
            }

            if (time <= 5f)
            {
                sun.GetComponent<Image>().sprite = sprite;
            }
            else if(time > 5f)
            {
                sun.GetComponent<Image>().sprite = sprite2;
                
            }

        }
        frame++;
    }
}