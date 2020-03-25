using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInitHelper {
    public static SnakeModel InitModelWithSettings(GameSettings settings) {
        Snake snake = new SimpleSnake();
        snake.SpawnSnakeAtPosition(new Vector3Int(-3,0,0), 3);
        snake.SetNextDirection(Direction.Rigth);

        Level level = SimpleLevelFactory.CreateLevel(settings.LevelName, settings.LevelWidth, settings.LevelHeight);
        Scorer scorer = GetScorer();
        Food foodModel = new SimpleFood();

        return new SnakeModel(snake, level, scorer, foodModel);
    }

    private static Scorer GetScorer() {
        SnakeModel model = SnakeApplication.GetInstance().model;
        if (model != null && model.scorer != null)
             return model.scorer;
         else
            return new Scorer();
    }

    public static List<Controller> GetRequaredControllers() {
        List<Controller> GameControllers = new List<Controller>();
        GameControllers.Add(new SnakeDirectionController());
        GameControllers.Add(new FoodSpawnController());
        GameControllers.Add(new FoodSwallowController());
        GameControllers.Add(new GameLooseController());
        GameControllers.Add(new GameWinController());
        GameControllers.Add(new ScorerController());
        GameControllers.Add(new SnakeInteractController());
        GameControllers.Add(new TeleportWallController());
        GameControllers.Add(new SnakeMovementController());
        return GameControllers;
    }
}