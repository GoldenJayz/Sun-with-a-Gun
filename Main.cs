using UnityEngine;


public partial class Main : MonoBehaviour
{
    /*
     * Plans
     * 1. Add a power up that will send you up for a certain amount of time just like a bounce pad
     * 2. Make background sprites
     * 4. GUI timer that shows how long you have to stay on the platform for
     * 4.5. Gradually decreases time every platform you go up
     * 6. Lock the cameras Y if you have already passed thing so its stuck.
     *    So the camera can only go up and not go down. Does not move the X
     *    But the Y moves up in the UI.
     */


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _sprites = Resources.Load("character", typeof(Sprite)) as Sprite; // grabs the character sprite
        GameObject obj = new GameObject(_frame.ToString());
        obj.transform.position += new Vector3(-0.37f, -1.00f, 1f);
        obj.tag = "left";
        obj.AddComponent<SpriteRenderer>();
        obj.GetComponent<SpriteRenderer>().sprite = _sprites;
        obj.AddComponent<BoxCollider2D>();
        lastCordY += 1.44f;

        Application.targetFrameRate = 60;

        _timer = GameObject.Find("Timer");
        _otherScript = _timer.GetComponent<Timer>();

        sr = GetComponent<SpriteRenderer>();


        if(CharacterSelect.character is not null) sr.sprite = CharacterSelect.character;
        else if(CharacterSelect.character is null) sr.sprite = GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("liam");

        transform.localScale = new Vector3(0.1f, 0.1f, 0f);

    }


    private void OnTriggerStay2D(Collider2D col)
    {
        var collisionObj = col.gameObject;
        var playersVel = rb.velocity;
        
        switch (collisionObj.tag) 
        {
            case "LEFTBORDER":
                transform.position = new Vector3(2.89f, transform.position.y, 0f);
                break;
            
            case "RIGHTBORDER":
                transform.position = new Vector3(-2.7f, transform.position.y, 0f);
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D col) { _inAir = false; }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("left"))
        {
            GameObject obj = new GameObject(_frame.ToString());
            obj.transform.position += new Vector3(1.44f, lastCordY, 1f);
            obj.tag = "right";
            lastCordY += 1.44f;
            obj.AddComponent<SpriteRenderer>();
            obj.GetComponent<SpriteRenderer>().sprite = _sprites;
            obj.AddComponent<BoxCollider2D>();
            score++;
            scoreText.text = "Score: " + score.ToString();
            col.gameObject.tag = "alreadyTagged";

            GameObject leftBorder = GameObject.Find("leftBorder");
            GameObject rightBorder = GameObject.Find("rightBorder");

            rightBorder.transform.localScale += new Vector3(0f, 50f, 0f);
            leftBorder.transform.localScale += new Vector3(0f, 50f, 0f);

            lastBlockName = _frame.ToString();

            objects.Add(obj);

            _otherScript.time = 10f;
        }

        else if (col.gameObject.CompareTag("right"))
        {
            GameObject obj = new GameObject(_frame.ToString());
            obj.transform.position += new Vector3(-0.37f, lastCordY, 1f);
            obj.tag = "left";
            lastCordY += 1.44f;
            obj.AddComponent<SpriteRenderer>();
            obj.GetComponent<SpriteRenderer>().sprite = _sprites;
            obj.AddComponent<BoxCollider2D>();
            score++;
            scoreText.text = "Score: " + score.ToString();
            col.gameObject.tag = "alreadyTagged";

            GameObject leftBorder = GameObject.Find("leftBorder");
            GameObject rightBorder = GameObject.Find("rightBorder");


            rightBorder.transform.localScale += new Vector3(0f, 50f, 0f);
            leftBorder.transform.localScale += new Vector3(0f, 50f, 0f);

            objects.Add(obj);

            _otherScript.time = 10f;
        }
    }


    private void OnCollisionExit2D(Collision2D col) 
    {
        _inAir = true;
    }


    private void Update()
    {
        Movement();

        _frame++;
    }
}