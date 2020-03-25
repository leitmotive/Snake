using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    Down, Up, Rigth, Left
}

public static class SnakesDirectionHelper {
    public static bool IsAvailableDirection(Direction direction, Direction nextDirection) {
        if (IsVerticalMovement(direction) && IsVerticalMovement(nextDirection))
            return false;

        if (IsHorizontalMovement(direction) && IsHorizontalMovement(nextDirection))
            return false;

        return true;
    }

    public static bool IsVerticalMovement(Direction direction) {
        return direction == Direction.Up || direction == Direction.Down;
    }

    public static bool IsHorizontalMovement(Direction direction) {
        return direction == Direction.Rigth || direction == Direction.Left;
    }

    public static Vector3Int NextHeadPosition(Direction direction, Vector3Int head) {
        switch(direction) {
            case Direction.Up:
                head.y++;
            break;
            case Direction.Down:
                head.y--;
            break;
            case Direction.Rigth:
                head.x++;
            break;
            case Direction.Left:
                head.x--;
            break;
        }
        return head;
    }
}