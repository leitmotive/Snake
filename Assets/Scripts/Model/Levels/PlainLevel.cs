using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainLevel : Level
{
    public PlainLevel(int levelWidth, int levelHeight):base(levelWidth,levelHeight) {
    }
    public override void Generate() {
        VerticalBorders("TeleportWall");
        HorizontalBorders("TeleportWall");
    }

    protected void VerticalBorders(string wallName) {
        for (int x = LevelLeftBound+1; x < LevelRightBound + 1; x++) {
            FillPosition(x, LevelTopBound+1, wallName);
            FillPosition(x, LevelBottomBound, wallName);
        }
    }

    protected void HorizontalBorders(string wallName) {
        for (int y = LevelBottomBound+1; y < LevelTopBound + 1; y++) {
            FillPosition(LevelLeftBound, y, wallName);
            FillPosition(LevelRightBound+1, y, wallName);
        }
    }

    protected void FillPosition(int x, int y, string wallName) {
        InteractiveElement obstacle = SimpleInteractiveElementFactory.CreateElement(wallName);
        obstacle.position = new Vector3Int(x,y,0);
        gameField.Add(obstacle.position, obstacle);
    }
}