using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// later on, teach interface
public class RestartButton : MonoBehaviour, IInteractiveButton
{
    public GameEvent gameEvent;
    // implements the interface
    public void ButtonClick()
    {
        Debug.Log("Onclick restart button");
        gameEvent.Raise();
        GameManager.instance.GameRestart();
    }
}