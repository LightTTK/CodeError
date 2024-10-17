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
    [SerializeField] private GameObject Perk_Drop;
    [SerializeField] private GameObject Visual;  
    [SerializeField] private GameObject Visual2;  

    //UI
    public Slider slider;

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

    public void DamageTaken(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Visual.SetActive(false);
            Visual2.SetActive(false);
            
            Perk_Drop.SetActive(true);

        }
    }
}
