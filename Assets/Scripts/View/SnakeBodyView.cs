using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyView : View {
    private Snake snake;
    public GameObject snakesBodyObject;
    public List<GameObject> SnakeElementsView;

    void Awake() {
        SnakeElementsView = new List<GameObject>();
    }
    public override void InitView() {
        InitSnakeView();
    }

    void InitSnakeView() {
        removeObjects(SnakeElementsView);
        snake = SnakeApplication.GetInstance().model.snake;
        syncListView(SnakeElementsView, snake.GetSnake(), snakesBodyObject);
    }

    public override void UpdateView() {
        syncListView(SnakeElementsView, snake.GetSnake(), snakesBodyObject);
    }
}
