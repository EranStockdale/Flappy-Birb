using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public BirdScript birdScript;

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreGained) 
    {
        if (birdScript.isAlive) {
            playerScore += scoreGained;
            scoreText.text = playerScore.ToString();
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
