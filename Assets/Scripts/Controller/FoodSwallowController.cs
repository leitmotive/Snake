using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSwallowController : Controller
{
    public override string[] ListNotificationInterests() {
        return new string[] { SnakeNotifications.FoodSwallow };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null) {
        if (notificationName == SnakeNotifications.FoodSwallow && type == "Vector3Int") {
            Vector3Int position = (Vector3Int)body;
            SwallowFood(position);
        }
    }
    void SwallowFood(Vector3Int position) {
        Level level = SnakeApplication.GetInstance().model.level;
        level.RemoveElementWithPosition(position);
        app.Notify(SnakeNotifications.FoodSpawn);
    }
}
