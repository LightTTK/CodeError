using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHints : MonoBehaviour
{
    public GameObject tH;
    public bool isTH;
    
    // Start is called before the first frame update
    void Start()
    {
        tH.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(isTH)
            {
                isTHING();
            }
            else
            {
                isTHED();
            }

        }
    }

    public void isTHED()
    {
        tH.SetActive(true);
        isTH = true;
    }

    public void isTHING()
    {
        tH.SetActive(false);
        isTH = false;

    }

}
