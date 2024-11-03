using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleQuest : MonoBehaviour
{
    public string description;
    public TextMeshProUGUI questText;

    public void SetQuest()
    {
        questText.text = description;
    }
}
