using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkSystem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PerkPickup> () != null) {
            Debug.Log($"Picking up {other.GetComponent<PerkPickup> ().perk.perkName}");
            other.GetComponent<PerkPickup>().perk.Enable();
            other.gameObject.SetActive(false);
        }
        
    }

}
