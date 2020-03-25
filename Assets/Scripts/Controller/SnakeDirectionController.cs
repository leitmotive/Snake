using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDirectionController : Controller {
    public override string[] ListNotificationInterests() {
        return new string[] { SnakeNotifications.PressUp, SnakeNotifications.PressDown, SnakeNotifications.PressLeft, SnakeNotifications.PressRight };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null){
        if (notificationName == SnakeNotifications.PressUp) 
            ChangeDirection(Direction.Up);
               
        if (notificationName == SnakeNotifications.PressDown) 
            ChangeDirection(Direction.Down);
             
        if (notificationName == SnakeNotifications.PressLeft) 
            ChangeDirection(Direction.Left);
                
        if (notificationName == SnakeNotifications.PressRight) 
            ChangeDirection(Direction.Rigth);
    }

    public void ChangeDirection(Direction nextDirection) {
        if (IsAvailableDirection(nextDirection)) 
            setDirection(nextDirection);
    }

    public bool IsAvailableDirection(Direction nextDirection) {
        Snake snake = SnakeApplication.GetInstance().model.snake;
        return SnakesDirectionHelper.IsAvailableDirection(snake.GetCurrentDirection(), nextDirection);
    }

    public void setDirection(Direction nextDirection) {
        SnakeApplication.GetInstance().model.snake.SetNextDirection(nextDirection);
    }
}
