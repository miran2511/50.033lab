using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetHighscore : MonoBehaviour, IInteractiveButton
{
    public GameObject mush;
    // Start is called before the first frame update
    void Start()
    {
        mush.SetActive(false);
    }

    public void ButtonClick()
    {

    }

    public void OnPointerEnter()
    {
        mush.SetActive(true);
    }

    public void onPointerExit()
    {
        mush.SetActive(false);
    }
}