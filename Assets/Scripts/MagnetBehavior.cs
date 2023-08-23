using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBehavior : MonoBehaviour
{
    Player player;
    [Range(1, 15)]
    [SerializeField]
    private float boxSpeed;
    bool pullBox = false;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        //pull the boxes if canPull 
       if(pullBox == true)
        {
            PullBoxes();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MagnetRay"))
        {
            pullBox = player.getRay();
            if(pullBox == true)
            {
                PullBoxes();
            }
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetRay"))
        {
            pullBox = player.getRay();
        }
    }


    public void PullBoxes()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, boxSpeed * Time.deltaTime);
    }
}
