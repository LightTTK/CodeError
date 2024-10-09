using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MCHealthbar : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
	public TextMeshProUGUI healthNumber;

	public Health mCHealthbar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		mCHealthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update(){
	 	if (healthNumber != null)
           healthNumber.SetText(currentHealth  + " / " + maxHealth);

		if (currentHealth <= 0)
		Death();
	}

	public void Death()
	{
		SceneManager.LoadScene(1);
	}



    // 
	// 	if (Input.GetKeyDown(KeyCode.Space))
	// 	{
	// 		TakeDamage(20);
	// 	}


    //

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		mCHealthbar.SetHealth(currentHealth);
	}

	
}
