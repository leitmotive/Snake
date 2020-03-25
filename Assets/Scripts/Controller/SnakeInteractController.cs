using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInteractController : Controller {
    public override string[] ListNotificationInterests() {
        return new string[] { SnakeNotifications.TryInteractSnake };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null) {
        if (notificationName == SnakeNotifications.TryInteractSnake) 
            InteractWithNextElement();
    }

    void InteractWithNextElement() {
        Vector3Int nextHeadPosition = app.model.snake.GetSnakesHead().position;
        InteractWithElemetsAtPosition(nextHeadPosition);
    }

    void InteractWithElemetsAtPosition(Vector3Int position) {
        InteractiveElement element = app.model.level.GetElementWithPosition(position);
        element.Interact();
        element = app.model.snake.GetSnakesElementWithPosition(position);
        element.Interact();
    }
}
