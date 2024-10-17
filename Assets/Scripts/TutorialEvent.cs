using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TutorialEvent : MonoBehaviour
{
    [Header("Cascading of Events")]
    public EventType eventTypeThatCascades;
    public List<TutorialEvent> tutorialEventsToCascade = new List<TutorialEvent>();

    [Header("Events")]
    public UnityEvent OnEnter = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
    public bool disableWhenInteract;
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
        if (other.gameObject.CompareTag("Player"))
        {
            if (!entered) StartCoroutine(WaitThenInteract());
            OnEnter?.Invoke();
            if (eventTypeThatCascades == EventType.ENTERED) EnableTutorialEvents();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (entered) StopCoroutine(WaitThenInteract());
            entered = false;
            OnExit?.Invoke();
            if (eventTypeThatCascades == EventType.EXITED) EnableTutorialEvents();
        }

    }

    IEnumerator WaitThenInteract()
    {
        entered = true;
        Debug.Log("Trying to interact");
        while (!Interacted && entered)
        {
            Debug.Log("Waiting");
            yield return null;
        }
        if (entered)
        {
            Debug.Log("Interacted");
            OnInteract?.Invoke();
            if (eventTypeThatCascades == EventType.INTERACTED) EnableTutorialEvents();
            if (disableWhenInteract)
            {
                DestroySelf();
            }
        }
    }

    public void DestroySelf()
    {
        Destroy(this);
    }

    void EnableTutorialEvents()
    {
        foreach (var tutEvent in tutorialEventsToCascade)
        {
            tutEvent.gameObject.SetActive(true);
        }
    }
}

public enum EventType
{
    ENTERED,
    EXITED,
    INTERACTED
}

