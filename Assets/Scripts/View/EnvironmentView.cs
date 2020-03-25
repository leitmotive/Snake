using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentView : View {
    private Level level;
    public GameObject GameField;
    public List<GameObject> ElementsView;

    void Awake() {
        ElementsView = new List<GameObject>();
    }
    public override void InitView() {
        level = SnakeApplication.GetInstance().model.level;
        AdjustGameView();
        InitObstaclesView();
    }

    public GameObject obstacleObject;
    void InitObstaclesView() {
        removeObjects(ElementsView);
        foreach (var element in level.gameField) {
            if (isBorder(element.Value))
                continue;

            GameObject obstacle = Instantiate(obstacleObject);
            obstacle.transform.position = new Vector3(element.Key.x, element.Key.y, element.Key.z);
            ElementsView.Add(obstacle);
        }
    }

    private bool isBorder(InteractiveElement element) {
        return  element.position.x == level.LevelLeftBound || 
                element.position.x == level.LevelRightBound + 1 || 
                element.position.y == level.LevelTopBound + 1 || 
                element.position.y == level.LevelBottomBound;
    }

    private void AdjustGameView() {
        GameField.transform.localScale = new Vector3(level.LevelWidth,level.LevelHeight,1);
        Vector3 position = new Vector3(0,0,0);
        position.x = isOdd(level.LevelWidth)  ? 0: 0.5f;
        position.y = isOdd(level.LevelHeight) ? 0: 0.5f;
        GameField.transform.position = position;
        Camera.main.transform.position = new Vector3(position.x,position.y,Camera.main.transform.position.z);
    }
}
