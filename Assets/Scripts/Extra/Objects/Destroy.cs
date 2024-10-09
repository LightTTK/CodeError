using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float life = 1;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Hit {collision.gameObject.name}");

        if (collision.gameObject.GetComponent<ShellDestroy>() != null) return;
        //Enemy takes damage
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealthComponent))
        {
            enemyHealthComponent.DamageTaken(10);
        }

        //Destroy bullet
       Destroy(gameObject);


    }
}
