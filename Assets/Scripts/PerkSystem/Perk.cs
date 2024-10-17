using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Perk : ScriptableObject{
    public string perkName;
    public Sprite perkIcon;

    public abstract void Enable ();
    public abstract void Disable ();


}
