using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public partial class Main : MonoBehaviour
{
    private bool _inAir = false;
    private bool _isItLeft = true;
    private int _frame = 0;
    private static Sprite _sprites;
    
    public float lastCordY = -1.00f;
    public Text scoreText;
    public int score = 0;
    public Rigidbody2D rb;
    public float xSpeed = 200f;
    public float force = 1f;
    public float jumpY = 300f;

    public float MAXXVELOCITY = 2f;

    public bool jumpable = true; // Check if the colliding object allows you to jump
    public string lastBlockName = "0"; // Needs to be set to zero because a block is automatically spawned at the start

    public List<GameObject> objects = new List<GameObject>();
    private GameObject _timer;
    private Timer _otherScript;

    public SpriteRenderer sr;
    public CharacterSelect playerSpr;


    private void Spawner()
    {
        GameObject obj = new GameObject(_frame.ToString());

        switch (_isItLeft)
        {
            case false:
                obj.transform.position += new Vector3(1.44f,lastCordY,1f);
                _isItLeft = true;
                obj.tag = "right";
                break;
            case true:
                obj.transform.position += new Vector3(-0.37f,lastCordY,1f);
                _isItLeft = false;
                obj.tag = "left";
                break;
        }

        obj.AddComponent<SpriteRenderer>();
        obj.GetComponent<SpriteRenderer>().sprite = _sprites;
        obj.AddComponent<BoxCollider2D>();
        
        lastCordY += 1.44f;
    }


    private void Movement()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(new Vector2(xSpeed, 0) * force * Time.deltaTime);
            if (_inAir == false) rb.velocity = Vector2.ClampMagnitude(rb.velocity, MAXXVELOCITY);
            GetComponent<SpriteRenderer>().flipX = true;

        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(new Vector2(-xSpeed, 0) * force * Time.deltaTime);
            if (_inAir == false) rb.velocity = Vector2.ClampMagnitude(rb.velocity, MAXXVELOCITY);
            GetComponent<SpriteRenderer>().flipX = false;
            
        }

        if (_inAir == false)
        {
            if (Input.GetKeyDown("w") || Input.GetKeyDown("space")) 
            {
                Vector2 dir = new Vector2(0.0f, jumpY * 25f) * Time.deltaTime;
                rb.AddForce(dir);
            }
        }

        if (_inAir == true) {
            if(rb.velocity.x > MAXXVELOCITY) rb.velocity = new Vector2(MAXXVELOCITY, rb.velocity.y);
            else if (rb.velocity.x < -MAXXVELOCITY) rb.velocity = new Vector2(-MAXXVELOCITY, rb.velocity.y);
        }
    }
}