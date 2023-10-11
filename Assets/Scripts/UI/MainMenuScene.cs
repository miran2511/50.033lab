using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScene : MonoBehaviour
{
    public GameObject highscore;
    public GameObject mush;
    public IntVariable gameScore;

    void Start()
    {
        // set highscore
        highscore.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
        mush.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        GameManager.instance.GameRestart();
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