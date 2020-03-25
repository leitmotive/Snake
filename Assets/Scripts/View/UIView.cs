using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIView : MonoBehaviour
{
    public GameObject LooseGameWindow;
    public GameObject WinGameWindow;
    public GameObject GameDifficultyWindow;

    public Text ScoreLabel;
    public Text TopScoreLabel;

    public GameObject ScoreUI;

    public void ShowScore() {
        ScoreUI.SetActive(true);
    }
    public void HideScore() {
        ScoreUI.SetActive(false);
    }

    public void UpdateScore() {
        Scorer scorer = SnakeApplication.GetInstance().model.scorer;
        ScoreLabel.text = scorer.Score.ToString();
        TopScoreLabel.text = scorer.TopScore.ToString();
    }

    public void StartNewGame(string difficulty) {
        HideGameDifficultyWindow();
        SnakeApplication.GetInstance().Notify(SnakeNotifications.InitGame, difficulty, "string");
    }

    public void ShowGameDifficultyWindow() {
        GameDifficultyWindow.SetActive(true);
    }

    public void HideGameDifficultyWindow() {
        GameDifficultyWindow.SetActive(false);
    }

    public void ShowLooseGameWindow() {
        LooseGameWindow.SetActive(true);
        StartCoroutine(CountDownTimer(3, () =>
        {
            HideLooseGameWindow();
            ShowGameDifficultyWindow();
        }));
    }

    public void HideLooseGameWindow() {
        LooseGameWindow.SetActive(false);
    }

    public void ShowWinGameWindow() {
        WinGameWindow.SetActive(true);
        StartCoroutine(CountDownTimer(3, () =>
        {
            HideWinGameWindow();
            ShowGameDifficultyWindow();
        }));
    }

    public void HideWinGameWindow() {
        WinGameWindow.SetActive(false);
    }

    IEnumerator CountDownTimer(float duration, Action action)
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }
        action.Invoke();
    }
}
