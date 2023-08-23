using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    private float particleLifeTime = 3f;
    private void Update()
    {
        //destroy instatiated particle after 3 seconds
        Destroy(gameObject, particleLifeTime);
    }
    
}
