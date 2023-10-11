using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BackToMainMenuButton : MonoBehaviour, IInteractiveButton
{
    public void ButtonClick()
    {
        SceneManager.LoadScene(0);
    }

}
