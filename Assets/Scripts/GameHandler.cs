using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] bool game;
    [SerializeField] GameObject gameOver;

    private void OnEnable()
    {
        game = true;
        gameOver.SetActive(false);
    }

    public void GameIsPlaying(bool isPlaying)
    {
        game = isPlaying;
        if (game == true)
        {
            gameOver.SetActive(false);
        }
        else
        {
            gameOver.SetActive(true);
        }
    }

    public bool GetGameOn()
    {
        return game;
    }
}
