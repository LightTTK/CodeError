using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips_and_Tricks : MonoBehaviour

{
    public GameObject taTMenu;
    public bool isTAT;
    
    // Start is called before the first frame update
    void Start()
    {
        taTMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(isTAT)
            {
                isTATTING();
            }
            else
            {
                isTATTED();
            }

        }
    }

    public void isTATTED()
    {
        taTMenu.SetActive(true);
        isTAT = true;
    }

    public void isTATTING()
    {
        taTMenu.SetActive(false);
        isTAT = false;

    }

}