using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWallController : Controller {
    public override string[] ListNotificationInterests() {
        return new string[] { SnakeNotifications.JumpSnake };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null){
        if (notificationName == SnakeNotifications.JumpSnake) 
            JumpSnake();
    }

    void JumpSnake() {
        Snake snake = app.model.snake;
        InteractiveElement head = snake.GetSnakesHead();
        Vector3Int newPosition  = GetMirrorPosition(head.position);

        if (!newPosition.Equals(head.position)) {
            head.position = newPosition;
            app.Notify(SnakeNotifications.TryInteractSnake);
        }
    }

    Vector3Int GetMirrorPosition(Vector3Int oldPosition) {
        if (IsHorizontalMovement())
            return GetHorizontalMirrorPosition(oldPosition);
        else if (IsVerticalMovement()) 
            return GetVerticalMirrorPosition(oldPosition);
        
        return oldPosition;
    }

    bool IsHorizontalMovement() {
        return SnakesDirectionHelper.IsHorizontalMovement(GetCurrentDirection());
    }

    bool IsVerticalMovement() {
        return SnakesDirectionHelper.IsVerticalMovement(GetCurrentDirection());
    }

    Vector3Int GetHorizontalMirrorPosition(Vector3Int oldPosition) {
            int levelWidth = app.model.level.LevelWidth;
            levelWidth = (GetCurrentDirection() == Direction.Left) ? levelWidth : -levelWidth;
            return new Vector3Int (oldPosition.x + levelWidth, oldPosition.y, 0);
    }

    Vector3Int GetVerticalMirrorPosition(Vector3Int oldPosition) {
            int levelHeight = app.model.level.LevelHeight;
            levelHeight = (GetCurrentDirection() == Direction.Down) ? levelHeight : -levelHeight;
            return new Vector3Int (oldPosition.x, oldPosition.y + levelHeight, 0);
    }

    Direction GetCurrentDirection(){
        Snake snake = app.model.snake;
        return snake.GetCurrentDirection();
    }
}
