using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour {
    //Input
    [SerializeField] InputActionProperty moveInput;
    Rigidbody rb;
    Vector2 move;

    //Speed 
    [SerializeField] float moveSpeed;
    float defaultSpeed;

    //UI
    public TextMeshProUGUI MoveInfo;

    //Animations
    [SerializeField] Animator anim;
    [SerializeField] Animator anim_Arms;

    public static Move instance;

    public void ToggleInput (bool _enabled) {
        if (_enabled) {
            moveInput.action.Enable ();
        } else {
            moveInput.action.Disable ();
        }
    }

    void Awake () {
        instance = this;
        rb = GetComponent<Rigidbody> ();
    }

    void Start () {
        defaultSpeed = moveSpeed;
        ToggleInput (true);
        moveInput.action.performed += ctx => { // press down
            move = ctx.ReadValue<Vector2> ();

        };

        moveInput.action.canceled += ctx => { // release up
            move = Vector2.zero;
        };
    }

    void Update () {
        if (MoveInfo != null)
            MoveInfo.SetText (moveSpeed + " "); // UI

        //Animation
        anim.SetFloat ("x", move.x * rb.velocity.magnitude, 0.14f, Time.deltaTime);
        anim.SetFloat ("z", move.y * rb.velocity.magnitude, 0.14f, Time.deltaTime);

        anim_Arms.SetFloat ("x", move.x * rb.velocity.magnitude, 0.14f, Time.deltaTime);
        anim_Arms.SetFloat ("z", move.y * rb.velocity.magnitude, 0.14f, Time.deltaTime);
    }

    // void performed (InputAction.CallBackContext ctx) {}

    void FixedUpdate () {
        rb.velocity = transform.forward * moveSpeed * move.y * Time.fixedDeltaTime +
            transform.right * moveSpeed * move.x * Time.fixedDeltaTime +
            transform.up * rb.velocity.y; // Move
    }

    public void ToggleGunAnimation (bool _enabled) {
        anim.SetBool ("hasPP19Bizon", _enabled);
        anim_Arms.SetBool ("hasPP19Bizon", _enabled);
    }

    // Perk Stuff
    public void MultiplySpeed (float _multiplier) {
        moveSpeed *= _multiplier; //Enable Perk
    }

    public void ResetSpeed () {
        moveSpeed = defaultSpeed; //Disable Perk
    }
}