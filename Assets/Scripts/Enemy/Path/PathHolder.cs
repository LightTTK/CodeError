using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathHolder : MonoBehaviour
{
    List<GameObject> paths = new List<GameObject> ();

    void Start(){
        for (int i = 0; i < transform.childCount; i++){ 
            paths.Add (transform.GetChild(i).gameObject);
            
        }
    }

    public List<GameObject> GetPaths(){
        return paths;

    }

}
