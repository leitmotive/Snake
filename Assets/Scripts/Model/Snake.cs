using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Snake {
    protected List<InteractiveElement> snake;
    protected Direction SnakesDirection;
    protected Direction NextDirection;
    public abstract void SpawnSnakeAtPosition(Vector3Int position, int snakesLength);
    public abstract List<InteractiveElement> GetSnake();
    public abstract void Move();
    public abstract void IncreaseSnakesBody();
    public abstract InteractiveElement GetSnakesElementWithPosition(Vector3Int position);

    public Direction GetCurrentDirection(){
        return SnakesDirection;
    }

    public void SetNextDirection(Direction nextDirection){
        this.NextDirection = nextDirection;
    }

    public InteractiveElement GetSnakesHead() {
        return snake[0];
    }

    public InteractiveElement GetSnakesTail() {
        return snake[snake.Count - 1];
    }
}
