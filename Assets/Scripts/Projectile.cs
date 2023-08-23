using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField]
    public float projectileSpeed = 10f;

    [Range(1, 10)]
    [SerializeField]
    private float projectileLifeTime = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, projectileLifeTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * projectileSpeed;
    }

    
   

}
