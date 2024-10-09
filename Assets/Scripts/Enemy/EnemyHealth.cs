using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthNumber;

    //UI
    public Slider slider;

    //BillBoard
    public Transform cam;

    public Health e_health;
    public MCHealthbar damage;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (healthNumber != null)
           healthNumber.SetText(currentHealth  + " / " + maxHealth);

    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    public void DamageTaken(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
