using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellDestroy : MonoBehaviour
{
 public float life = 1;
 
    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter(Collision other)
    {
        //Destroy bullet
        Destroy(gameObject, life);
    }
}
