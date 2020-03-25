using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSnake: Snake {
    public SimpleSnake() {
        snake = new List<InteractiveElement>();
    }

    public override List<InteractiveElement> GetSnake() {
        return snake;
    }

    public override void Move() {
        InteractiveElement head = GetSnakesHead();
        InteractiveElement tail = GetSnakesTail();

        snake.Remove(tail);
        tail.position = head.position;
        snake.Insert(1, tail);
        head.position = GetNextHeadPosition();
    }

    public Vector3Int GetNextHeadPosition() {
        InteractiveElement head = GetSnakesHead();
        SnakesDirection = NextDirection;
        return SnakesDirectionHelper.NextHeadPosition(SnakesDirection,head.position);
    }

    public override void SpawnSnakeAtPosition(Vector3Int position, int snakesLength) {
        snake.Clear();
        for(int i = snakesLength; i > 0; i--) {
            InteractiveElement bodyElement = CreateSnakesBodyElement(new Vector3Int(i + position.x, position.y, position.z));
            snake.Add(bodyElement);
        }
    }

    public override void IncreaseSnakesBody() {
        InteractiveElement tail = GetSnakesTail();
        snake.Add(CreateSnakesBodyElement(tail.position));
    }

    InteractiveElement CreateSnakesBodyElement(Vector3Int position) {
        return SimpleInteractiveElementFactory.CreateElement("SnakesBodyElement", position);
    }

    public override InteractiveElement GetSnakesElementWithPosition(Vector3Int position) {
        for (int i = 1; i < snake.Count; i++ )
            if (snake[i].position == position)
                return snake[i];
       
        return new BlankInteractiveElement();
    }
}