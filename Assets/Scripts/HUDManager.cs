using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class HUDManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject restartButton;
    public GameObject restartButton1;
    public GameObject scoreText;
    public GameObject scoreText1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        // hide gameover panel
        gameOverPanel.SetActive(false);
        scoreText.SetActive(true);
        scoreText1.SetActive(false);
        restartButton.gameObject.SetActive(true);
        restartButton1.gameObject.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        scoreText1.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreText.SetActive(false);
        scoreText1.SetActive(true);
        restartButton.gameObject.SetActive(false);
        restartButton1.gameObject.SetActive(true);
    }

}