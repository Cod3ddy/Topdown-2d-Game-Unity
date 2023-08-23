using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRay : MonoBehaviour
{

    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.parent = player.transform;
    }
}
