using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    
    private Vector2 mousePos;
    private Rigidbody2D shipRigidBody;

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform launchingPoint;
    [Range(0.1f, 2f)]
    [SerializeField] private float launchRate = 0.5f;
    private float launchTmer;

    private float moveX;
    private float moveY;
    public float moveSpeed;

    void Start()
    {
        shipRigidBody = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        //get key input
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 180f;
        Debug.Log("Angle : " + angle);
        transform.localRotation = Quaternion.Euler(0, 0, angle);

       
        if(Input.GetMouseButtonDown(0) && launchTmer <= 0f)
        {
            ShootProjectile();
            launchTmer = launchRate;
        }
        else
        {
            launchTmer -= Time.deltaTime;
        }
    }


    private void FixedUpdate()
    {
        MoveShip();
    }

    private void ShootProjectile()
    {
        Instantiate(projectile, launchingPoint.position, launchingPoint.rotation);
    }

    private void MoveShip()
    {
        shipRigidBody.velocity = new Vector2(moveX, moveY).normalized * moveSpeed;
    }

  /*  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
           
            SceneManager.LoadScene("Main");
        }
    }*/
}
