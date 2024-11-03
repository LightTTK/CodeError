using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public UnityEvent OnTakeDamage = new UnityEvent ();
    public UnityEvent OnDeath = new UnityEvent ();

    [SerializeField] Animator targetAnim;

    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthNumber;
    // [SerializeField] private GameObject Perk_Drop;
    [SerializeField] private GameObject Visual;
    [SerializeField] private GameObject Visual2;

    //UI
    public Slider slider;

    public Health e_health;
    public MCHealthbar damage;

    // Start is called before the first frame update
    void Start () {
        currentHealth = maxHealth;
    }

    void Update () {
        if (healthNumber != null)
            healthNumber.SetText (currentHealth + " / " + maxHealth);

    }

    public void DamageTaken (int damage) {
        currentHealth -= damage;
        if (targetAnim && currentHealth > 0) targetAnim.SetTrigger ("pop");
        OnTakeDamage?.Invoke ();
        if (currentHealth <= 0) {
            OnDeath?.Invoke ();
            GetComponent<Enemy> ()?.Death ();

            if (Visual) Visual.SetActive (false);
            if (Visual2) Visual2.SetActive (false);

            // Perk_Drop.SetActive(true);
            if (targetAnim) targetAnim.SetBool ("explode", true);
        }
    }
}