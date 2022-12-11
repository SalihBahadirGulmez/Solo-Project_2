using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepMovement : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D rb;
    public int destroyTime = 12;
    private float scaleX = 1;
    private Vector2 speed = new Vector2(0, -1f);
    private float maxScale;
    void Start()
    {
        player = GameObject.Find("Player");
        if(transform.position.x > 0)
        {
            maxScale = 2.8f - transform.position.x;           
        }else 
        { 
            maxScale = 2.8f + transform.position.x;
        }
        scaleX = Random.Range(player.transform.localScale.x / 2, maxScale);
        gameObject.transform.localScale = new Vector2(scaleX, 0.16f);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1f);
        Destroy(gameObject, destroyTime);

    }

    private void FixedUpdate()
    {
        //transform.Translate(speed * Time.deltaTime);
        /*if(player.transform.position.y >= transform.position.y + 0.33f)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else { gameObject.GetComponent<BoxCollider2D>().isTrigger = true; }*/
        if (gameObject.GetComponent<BoxCollider2D>().isTrigger && player.transform.position.y - (player.transform.localScale.y / 2) >= transform.position.y + (transform.localScale.y))
        {
            //Debug.Log(player.transform.position.y - (player.transform.localScale.y / 2) + "player");
            //Debug.Log(transform.position.y + (transform.localScale.y / 2));

            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else if (!gameObject.GetComponent<BoxCollider2D>().isTrigger && player.transform.position.y - (player.transform.localScale.y / 2) < transform.position.y - (transform.localScale.y / 2)) 
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true; 
        }

    }
    


    private void Update()
    {
   

        /*if (player.transform.position.y >= transform.position.y + 0.35f)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else if (player.transform.position.y < transform.position.y + 0.12f)
        {
            Debug.Log("denem");
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }*/

    }

}
