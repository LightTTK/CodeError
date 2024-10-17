using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips_and_Tricks : MonoBehaviour

{
    public GameObject TAB_Tips;
    public GameObject tips_Menu;
    public bool Showing_Tips;
    public bool Showing_TABS;
    
    // Start is called before the first frame update
    void Start()
    {
        tips_Menu.SetActive(true);
        TAB_Tips.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(Showing_Tips)
            {
                notShowing();
                tabIS(); 
            }
            else
            {
                isShowing();
                notTab();
            }

        }
    }

    public void isShowing()
    {
        tips_Menu.SetActive(true);
        Showing_Tips = true;
    }

    public void notShowing()
    {
        tips_Menu.SetActive(false);
        Showing_Tips = false;

    }

    public void tabIS()
    {
        TAB_Tips.SetActive(true);
        Showing_TABS = true;
    }

    public void notTab()
    {
        TAB_Tips.SetActive(false);
        Showing_TABS = false;

    }

}