using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] bool game;
    [SerializeField] GameObject gameOver;
    [SerializeField] SpawnManager spawnManager;
    [SerializeField] GameObject score;
    [SerializeField] GameObject playAgain;
    [SerializeField] GameObject playGame;
    [SerializeField] GameObject quitGame;
    [SerializeField] GameObject gameTitle;

    private void OnEnable()
    {
        spawnManager = spawnManager.GetComponent<SpawnManager>();
        gameOver.SetActive(false);
        playAgain.SetActive(false);
        playGame.SetActive(true);
        quitGame.SetActive(true);
        gameTitle.SetActive(true);
        game = false;
    }

    public void GameIsPlaying(bool isPlaying)
    {
        game = isPlaying;
        if (game == false)
        {
            SetGameOver();
        }
    }

    public bool GetGameOn()
    {
        return game;
    }

    public void PlayGame()
    {
        SetGameMode();
    }

    public void PlayAgain()
    {
        score.GetComponent<Score>().ResetScore();
        SetGameMode();
    }

    void SetGameMode()
    {
        game = true;
        spawnManager.SpawnPlayer();
        spawnManager.SpawnObstacle();
        gameOver.SetActive(false);
        playGame.SetActive(false);
        playAgain.SetActive(false);
        quitGame.SetActive(false);
        gameTitle.SetActive(false);
    }

    void SetGameOver()
    {
        gameOver.SetActive(true);
        playAgain.SetActive(true);
        quitGame.SetActive(true);
        gameTitle.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
