using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeModel {
    public Snake snake;
    public Level level;
    public Food food;
    public Scorer scorer;

    public SnakeModel(Snake snake, Level level, Scorer scorer, Food food) {
        this.scorer = scorer;
        this.scorer.resetScore();
        this.snake = snake;
        this.level = level;
        this.level.Generate();
        this.food = food;
    }
}