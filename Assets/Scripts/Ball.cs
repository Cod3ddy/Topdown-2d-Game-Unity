using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    Player player;
    private bool pullBall = false;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        //pull the ball if pullBall is true
        if (pullBall == true)
        {
            moveBall();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("MagnetRay"))
        {
            pullBall = player.getRay();
            if(pullBall == true)
            {
                moveBall();
            }
            
        }
        
    }
    //stop pulling the ball if the ray is no longer touching it

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetRay"))
        {
            pullBall = player.getRay();
        }
    }

    //move the ball when the ray touches it 
    public void moveBall()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, ballSpeed * Time.deltaTime);
    }
}
