using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class FootStep_Sounds : MonoBehaviour
{
    [SerializeField] List<AudioClip> footsteps = new List<AudioClip> ();
    [SerializeField] AudioSource audioSource;

    public void FootStep()
    {
        audioSource.PlayOneShot(footsteps[Random.Range (0, footsteps.Count - 1)]);
    }

}
