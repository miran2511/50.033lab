using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button restartButton;
    public PlayerMovement playerMovement;
    public TextMeshProUGUI scoreText;
    public JumpOverGoomba jumpOverGoomba;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.isGameOver)
        {
            restartButton.gameObject.SetActive(false);
            scoreText.enabled = false;
            gameOverPanel.SetActive(true);
        }
    }
}
