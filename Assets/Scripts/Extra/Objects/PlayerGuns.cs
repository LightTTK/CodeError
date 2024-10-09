using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    public List<GameObject> guns = new List<GameObject>();

    void Start()
    {
        ToggleGunByID("", false);
    }

    public void ToggleGunByID(string _id, bool _enabled)
    {
        foreach (var gun in guns)
        {
            gun.SetActive(false);
        }
        foreach (var gun in guns)
        {
            if (gun.GetComponent<PickupID>().id == _id)
            {
                gun.SetActive(_enabled);
                GetComponent<Move>().ToggleGunAnimation(_enabled);
                break;
            }
        }
    }
}
