using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour {
    public List<GameObject> guns = new List<GameObject> ();

    void Start () {
        ToggleGunByID ("", false);
    }

    public void ToggleAllGunsShootable (bool _enabled) {
        foreach (var gun in guns) {
            if (gun.GetComponent<Projectile> () != null) {
                gun.GetComponent<Projectile> ().canShoot = _enabled;
            } else if (gun.GetComponentInChildren<Projectile> () != null) {
                gun.GetComponentInChildren<Projectile> ().canShoot = _enabled;
            }
        }
    }

    public void ToggleGunByID (string _id, bool _enabled) {
        foreach (var gun in guns) {
            gun.SetActive (false);
        }
        foreach (var gun in guns) {
            if (gun.GetComponent<PickupID> ().id == _id) {
                gun.SetActive (_enabled);
                GetComponent<Move> ().ToggleGunAnimation (_enabled);
                break;
            }
        }
    }
}