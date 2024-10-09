using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform followTarget;

    void FixedUpdate(){
       transform.position = followTarget.position;
        // transform.position = quaternion.Euler(transform.rotation.eulerAngles.x,
        // followTarget.rotation.eulerAngles.y, 0);
    }

}
