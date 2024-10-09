using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Event : MonoBehaviour
{
    public UnityEvent OnEnter = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
    public UnityEvent OnInteract = new UnityEvent();

    public InputActionProperty InteractInput;
    bool Interacted;
    bool entered;

    private void Awake()
    {
        //Interaction        
        InteractInput.action.Enable();
        InteractInput.action.performed += ctx => Interacted = true;
        InteractInput.action.canceled += ctx => Interacted = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            if (!entered) StartCoroutine(WaitThenInteract());
            entered = true;
            OnEnter?.Invoke();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            if (!entered) StopCoroutine(WaitThenInteract());
            entered = false;
            OnExit?.Invoke();
        }

    }

    IEnumerator WaitThenInteract()
    {
        while (!Interacted && entered)
        {
            yield return null;
        }
        if (entered)
        {
            OnInteract?.Invoke();
        }
    }

    public void DestroySelf()
    {
        Destroy(this);
    }



}
