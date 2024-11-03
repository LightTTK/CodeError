using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
  Camera cam;

  private void Start () {
    cam = Camera.main;
  }

  void LateUpdate () {
    transform.LookAt (transform.position + cam.transform.forward);
  }
}