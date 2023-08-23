using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Player player;
    Ship ship;
    CameraShake shake;
    public GameObject explosion;
    private int finalKaboom;
    void Start()
    {
        player = FindObjectOfType<Player>();
        ship = FindObjectOfType<Ship>();
    }

    void Update()
    {
        //follow ship
        if (ship != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, ship.transform.position, speed * Time.deltaTime);
            finalKaboom = 1;
        }
        else
        {
            //if the ship can not be found destroy all the spawned enemies and stop spawning
            Destroy(gameObject);
            if (finalKaboom == 1)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                finalKaboom = 0;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            speed = 0;
            transform.parent = player.transform;
        }

        if (other.CompareTag("Ship"))
        {
            speed = 0;
            transform.parent = ship.transform;
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("Projectile"))
        {            
            Destroy(gameObject);
            Destroy(other.gameObject);
            //shake the camera

            //display explosion effect
            Instantiate(explosion, transform.position, Quaternion.identity);
        }


        //die when mega zap zap strikes
        if (other.CompareTag("MagnetRay"))
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

    }
}
