using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField]
    int timeToEnd;
    int points = 0;
    Dictionary<KeyColor, int> keys = new Dictionary<KeyColor, int>();


    bool isGamePaused = false;
    [SerializeField]
    KeyCode pausekey = KeyCode.P;

    bool endGame = false;
    bool win = false;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(this);
        }
        Time.timeScale = 1f;

        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
        keys[KeyColor.Red] = 0;
        keys[KeyColor.Green] = 0;
        keys[KeyColor.Gold] = 0;

        InvokeRepeating(nameof(Timer), 2f, 1f);
    }

    private void Update()
    {
        PauseCheck();
    }

    void Timer()
    {
        timeToEnd--;
        Debug.Log($"time: {timeToEnd}");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
            win = false;
        }
        if (endGame)
        {
            EndGame();
        }
    }

    private void PauseCheck()
    {
        if (!Input.GetKeyDown(pausekey))
        {
            return;
        }
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PausedGame();
        }

    }

    void PausedGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void EndGame()
    {
        CancelInvoke(nameof(Timer));

        Time.timeScale = 0f;

        if (win)
        {
            Debug.Log("you win!");
        }
        else
        {
            Debug.Log("you lose!");
        }
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }
    public void AddTime(int time)
    {
        timeToEnd += time;
    }
    public void FreezeTime(int freezeTime)
    {
        CancelInvoke(nameof(Timer));
        InvokeRepeating(nameof(Timer), freezeTime, 1f);

    }
    public void AddKey(KeyColor color)
    {
        keys[color]++;
        Debug.Log($"{color.ToString()} = {keys[color]}");
    }
}
