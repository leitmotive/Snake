using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorerController : Controller {
    public override string[] ListNotificationInterests() {
        return new string[] { SnakeNotifications.ChangePoints, SnakeNotifications.ShowGameDifficultyWindow, SnakeNotifications.StartGame };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null) {
        if (notificationName == SnakeNotifications.ChangePoints && type == "int") 
            CalculateScore((int)body);
        
        if (notificationName == SnakeNotifications.ShowGameDifficultyWindow) 
            app.uIView.HideScore();
        
        if (notificationName == SnakeNotifications.StartGame) {
            app.uIView.ShowScore();
            app.uIView.UpdateScore();
        }
    }

    void CalculateScore(int points) {
        app.model.scorer.addPoints(points);
        app.uIView.UpdateScore();
    }
}