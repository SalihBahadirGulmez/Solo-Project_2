using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canJump = true;

    public int forceHorizontal = 1;
    public float forceVertical = 1f;

    public GameObject deathScreen;
    public GameManager gameManager;
    public TMP_Text deathScreenScore;
    void Start()
    {
        Time.timeScale = 1;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -5)
        {
            Time.timeScale = 0;
            deathScreenScore.text = gameManager.score.ToString("0");
            deathScreen.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            if(canJump) 
            {               
                rb.AddForce(new Vector2(0, 110f));
                canJump = false;
            }    
            rb.AddForce(new Vector2(6f, 0));
        }
        if (Input.GetKey("a"))
        {
            if (canJump)
            {
                rb.AddForce(new Vector2(0, 110f));
                canJump = false;
            }
            rb.AddForce(new Vector2(-6f, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "step")
        {
            canJump = true;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Time.timeScale = 0;
            deathScreenScore.text = gameManager.score.ToString();
            deathScreen.SetActive(true);
        }
    }
}
