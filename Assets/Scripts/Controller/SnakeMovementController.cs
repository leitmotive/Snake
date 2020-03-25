using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovementController : Controller {
    float elapsedTime = 0;
    float SnakesSpeed;
    float FrameTime;
    Snake snake;

    bool GameNotStarted;
    public SnakeMovementController() {
        GameNotStarted = true;
    }

    public override string[] ListNotificationInterests() {
        return new string[] { SnakeNotifications.ChangeGameSpeed, SnakeNotifications.StartGame, SnakeNotifications.IncreaseSnake, SnakeNotifications.UpdateView };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null) {
        if (notificationName == SnakeNotifications.ChangeGameSpeed && type == "float") 
            ApplySpeed((float)body);
        
        if (notificationName == SnakeNotifications.StartGame) 
            ResetController();
        
        if (notificationName == SnakeNotifications.IncreaseSnake) 
            snake.IncreaseSnakesBody();

        if (notificationName == SnakeNotifications.UpdateView)
            app.view.UpdateView();  
    }

    public void ResetController() {
        snake = app.model.snake;
        SnakesSpeed = app.Settings.StartSpeed;
        FrameTime = 1/SnakesSpeed;
    }

    void ApplySpeed(float speed) {
        SnakesSpeed += speed;
        FrameTime = 1/SnakesSpeed;
    }

    public override void UpdateController() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > FrameTime) {
            elapsedTime -= FrameTime;
            MoveSnake();
        }
    }

    void MoveSnake() {
        snake.Move();
        app.Notify(SnakeNotifications.TryInteractSnake);
        app.Notify(SnakeNotifications.UpdateView);
    }
}