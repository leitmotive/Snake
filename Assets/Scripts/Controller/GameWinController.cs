using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinController : Controller {
    public override string[] ListNotificationInterests() {
        return new string[] { SnakeNotifications.IncreaseSnake };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null) {
        if (notificationName == SnakeNotifications.IncreaseSnake) 
            CheckWinConditions();
    }

    void CheckWinConditions() {
        if (IsWinGameCondition())
            WinGame();
    }
    
    bool IsWinGameCondition() {
        Snake snake = app.model.snake;
        return snake.GetSnake().Count > app.Settings.LengthQuantityToWin;
    }

    void WinGame() {
        app.Notify(SnakeNotifications.StopGame);
        app.uIView.ShowWinGameWindow();
    }
}
