using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedIncreasePerk", menuName = "Perks/Create Speed Increase Perk")]
public class Perk_SpeedIncrease : Perk {
    public float speedMultiplier;

    public override void Enable(){
        Move.instance.MultiplySpeed(speedMultiplier);
    }
    public override void Disable(){
        Move.instance.ResetSpeed();
    }
}
