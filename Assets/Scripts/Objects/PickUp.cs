using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Projectile gunScript;
    public BulletHolder ShellScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    [SerializeField] Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Setup
        if (!equipped)
        {
            if(gunScript) gunScript.enabled = false;
            if(ShellScript) ShellScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            
        }
        if (equipped)
        {
            if(gunScript) gunScript.enabled = true;
            if(ShellScript) ShellScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUpControl();
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            
        }

        //Drop if equipped and "Q" is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUpControl()
    {
        GetComponent<MeshRenderer>().enabled = false;

        player.GetComponent<PlayerGuns>().ToggleGunByID(GetComponent<PickupID>().id, true);

        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        // gunScript.enabled = true;
        // ShellScript.enabled = true;
    }

    private void Drop()
    {
        GetComponent<MeshRenderer>().enabled = true;

        player.GetComponent<PlayerGuns>().ToggleGunByID(GetComponent<PickupID>().id, false);

        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Gun carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        //Add random rotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        //Disable script
        // gunScript.enabled = false;
        // ShellScript.enabled = false;
    }
}
