using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //player
    public float rotationSpeed;
    private Vector2 mousePos;

    //projectile (s)
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform launchingPoint;
    [Range(0.1f, 2f)]
    [SerializeField] private float launchRate = 0.5f;
    private float launchTmer;

    //magnetic ray 
    [SerializeField]
    private GameObject magnetRay;

    //check if ray is enabled
    public  bool isRayEnabled;

    //magnetic behavior
    MagnetBehavior magnetBehavior;

    public void setRay(bool isRayEnabled)
    {
        this.isRayEnabled = isRayEnabled;
    }

    public bool getRay()
    {
        return isRayEnabled;
    }


    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
        //transform.Rotate(Vector3.forward * rotationSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);

        if (Input.GetMouseButtonDown(1) && launchTmer <= 0f)
        {
            ShootProjectile();
            launchTmer = launchRate;
        }
        else
        {
            launchTmer -= Time.deltaTime;
        }


        if (Input.GetMouseButton(0))
        {
            setRay(true);
            magnetRay.GetComponent<CapsuleCollider2D>().enabled = true;
            magnetRay.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            setRay(false);
            magnetRay.GetComponent<CapsuleCollider2D>().enabled = false;
            magnetRay.GetComponent<SpriteRenderer>().enabled = false;

        }


        ///testing pull boxes

    }




    private void ShootProjectile()
    {
        Instantiate(projectile, launchingPoint.position, launchingPoint.rotation);
    }
}
