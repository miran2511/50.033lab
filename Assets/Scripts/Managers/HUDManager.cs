using UnityEngine;
using TMPro;

public class HUDManager : Singleton<HUDManager>
{
    public GameObject gameOverPanel;
    public GameObject restartButton;
    public GameObject restartButton1;
    public GameObject scoreText;
    public GameObject scoreText1;
    public GameObject highscoreText;
    public GameObject pauseButton;
    public GameObject pausePanel;
    public GameObject mush;
    public IntVariable gameScore;


    void Awake()
    {
        // other instructions
        // subscribe to events
        GameManager.instance.gameStart.AddListener(GameStart);
        GameManager.instance.gameOver.AddListener(GameOver);
        GameManager.instance.gameRestart.AddListener(GameStart);
        GameManager.instance.scoreChange.AddListener(SetScore);
    }

    public void GameStart()
    {
        // hide gameover panel
        gameOverPanel.SetActive(false);
        // hide pause panel
        pausePanel.SetActive(false);
        // hide mushroom
        mush.SetActive(false);
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
        pauseButton.SetActive(false);
        scoreText.SetActive(false);
        scoreText1.SetActive(true);
        restartButton.gameObject.SetActive(false);
        restartButton1.gameObject.SetActive(true);
        // set highscore
        highscoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
        // show
        highscoreText.SetActive(true);
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