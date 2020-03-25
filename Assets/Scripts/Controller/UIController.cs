using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : Controller {
     public override string[] ListNotificationInterests() {
        return new string[] {SnakeNotifications.ShowGameDifficultyWindow };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null) {
        if (notificationName == SnakeNotifications.ShowGameDifficultyWindow)
            app.uIView.ShowGameDifficultyWindow();
    }
}