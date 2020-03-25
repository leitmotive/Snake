using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnController : Controller {
    public override string[] ListNotificationInterests() {
        return new string[] { SnakeNotifications.FoodSpawn };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null){
        if (notificationName == SnakeNotifications.FoodSpawn ) 
            SpawnFood();
    }

    void SpawnFood() {
        Level level = app.model.level;
        InteractiveElement food = GetFoodElement();
        Vector3Int position = GetRandomPosition(level);
        food.position = position;
        level.SetElementAtPosition(position,food);
        app.Notify(SnakeNotifications.UpdateView);
    }

    InteractiveElement GetFoodElement() {
        Food foodModel = app.model.food;
        return foodModel.GetCurrentFoodElement();
    }

    Vector3Int GetRandomPosition(Level level) {
        Vector3Int position = GenerateNewRandomPosition(level);
        while (level.isEmptyCell(position)) {
            position = GetRandomPosition(level);
        }
        return position;
    }

    Vector3Int GenerateNewRandomPosition(Level level){
        Vector3Int position = new Vector3Int(0,0,0);
        position.x = Random.Range(level.LevelRightBound, level.LevelLeftBound);
        position.y = Random.Range(level.LevelTopBound, level.LevelBottomBound);
        return position;
    }
}
