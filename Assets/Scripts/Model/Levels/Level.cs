using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level {
    public int LevelWidth;
    public int LevelHeight;
    public int LevelTopBound;
    public int LevelBottomBound;
    public int LevelRightBound;
    public int LevelLeftBound;

    public Dictionary<Vector3Int, InteractiveElement> gameField = new Dictionary<Vector3Int, InteractiveElement>();

    public Level(int levelWidth, int levelHeight) {
        LevelWidth = levelWidth;
        LevelHeight = levelHeight;
        LevelTopBound = levelHeight/2;
        LevelBottomBound = LevelTopBound - levelHeight;
        LevelRightBound = levelWidth/2;
        LevelLeftBound = LevelRightBound - levelWidth ;
    }

    public abstract void Generate();

    public bool isEmptyCell(Vector3Int position) {
        return gameField.ContainsKey(position);
    }

    public InteractiveElement GetElementWithPosition(Vector3Int position) {
        if (gameField.ContainsKey(position)) 
            return gameField[position];
        
        return new BlankInteractiveElement();
    }

    public void SetElementAtPosition(Vector3Int position, InteractiveElement element) {
        gameField.Add(position, element);
    }

    public void RemoveElementWithPosition(Vector3Int position) {
        gameField.Remove(position);
    }
}
