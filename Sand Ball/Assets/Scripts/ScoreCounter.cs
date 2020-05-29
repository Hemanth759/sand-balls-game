using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI scoreText;

    private int score;
    private bool endingGame;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        score = 1;
        endingGame = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Active")
        {
            score++;
            scoreText.text = "Score: " + score;

            if (!endingGame)
            {
                gameManager.showGameOver();
            }
        }
    }
}
