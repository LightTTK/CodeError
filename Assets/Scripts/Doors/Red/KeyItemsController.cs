using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem{

public class KeyItemsController : MonoBehaviour
{
    [SerializeField] private bool redDoor = false;
    [SerializeField] private bool redKey = false;
    [SerializeField] private bool blueDoor = false;
    [SerializeField] private bool blueKey = false;
    [SerializeField] private GameObject KeyIcon;
    [SerializeField] private GameObject HeadsUp;

    [SerializeField] private KeyInventory _KeyInventory = null;

    private KeyDoorController doorObject;

    

    private void Start()
    {
        if (redDoor)
        {
            doorObject = GetComponent<KeyDoorController>();

        }
        else if (blueDoor)
        {
            doorObject = GetComponent<KeyDoorController>();

        }
    }

    public void ObjectInteraction()
    {
        if (redDoor)
        {
            doorObject.PlayAnimation();
            KeyIcon.SetActive(false);        
        }

        else if (blueDoor)
        {
            doorObject.PlayAnimation();
            KeyIcon.SetActive(false);           
        }

        else if (redKey)
        {
            _KeyInventory.hasRedKey = true;
            KeyIcon.SetActive(true);
            gameObject.SetActive(false);
            HeadsUp.SetActive(true);
        }

        else if (blueKey)
        {
            _KeyInventory.hasBlueKey = true;
            KeyIcon.SetActive(true);
            gameObject.SetActive(false);
            HeadsUp.SetActive(true);
    }
}
}
}