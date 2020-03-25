using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLooseController : Controller {
    public override string[] ListNotificationInterests() {
        return new string[] { SnakeNotifications.KillSnake };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null) {
        if (notificationName == SnakeNotifications.KillSnake)
            LooseGame();
    }

    void LooseGame() {
            app.Notify(SnakeNotifications.StopGame);
            app.uIView.ShowLooseGameWindow();
    }
}
