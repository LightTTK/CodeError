using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MCHealthbar : MonoBehaviour {
	public UnityEvent OnTakeDamage = new UnityEvent ();
	public UnityEvent OnDeath = new UnityEvent ();

	public int maxHealth = 100;
	public int currentHealth;
	public TextMeshProUGUI healthNumber;

	public Health mCHealthbar;

	// Start is called before the first frame update
	void Start () {
		currentHealth = maxHealth;
		mCHealthbar.SetMaxHealth (maxHealth);
	}

	// Update is called once per frame
	void Update () {
		if (healthNumber != null)
			healthNumber.SetText (currentHealth + " / " + maxHealth);

		if (currentHealth <= 0) {
			Death ();
			OnDeath?.Invoke ();
		}
	}

	public void Death () {
		SceneManager.LoadScene (1);
	}

	// 
	// 	if (Input.GetKeyDown(KeyCode.Space))
	// 	{
	// 		TakeDamage(20);
	// 	}

	//

	public void TakeDamage (int damage) {
		OnTakeDamage?.Invoke ();
		currentHealth -= damage;

		mCHealthbar.SetHealth (currentHealth);
	}

}