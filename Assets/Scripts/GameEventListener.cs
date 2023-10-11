using UnityEngine;
using UnityEngine.Events;

// if attached to an object that might be disabled, callback will not work
// attach it on a parent object that wont be disabled
public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;

    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
