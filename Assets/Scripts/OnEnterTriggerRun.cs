using UnityEngine;
using UnityEngine.Events;

public class OnEnterTriggerRun : MonoBehaviour
{
    public UnityEvent Event;

    public string RequiredTag = "Player";

    private bool Triggered = false;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(Triggered)
        {
            return;
        }

        Triggered = true;

        if(collider.gameObject.CompareTag(RequiredTag))
        {
            Event.Invoke();
        }
    }
}
