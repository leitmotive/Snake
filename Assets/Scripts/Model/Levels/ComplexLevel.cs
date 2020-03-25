using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexLevel : PlainLevel {

    public ComplexLevel(int levelWidth, int levelHeight):base(levelWidth,levelHeight) {}
    public override void Generate() {
        VerticalBorders("SolidWall");
        HorizontalBorders("SolidWall");
        InnerObstacles("SolidWall");
    }

    private void InnerObstacles(string wallName) {
        for (int x = LevelLeftBound+2; x < LevelRightBound; x++) {
            FillPosition(x, LevelTopBound-1, wallName);
            FillPosition(x, LevelBottomBound+2, wallName);
        }
    }
}