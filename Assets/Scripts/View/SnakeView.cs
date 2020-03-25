using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeView : MonoBehaviour {
    public EnvironmentView enviromentView;
    public FoodView foodView;
    public SnakeBodyView snakeBodyView;

    public void InitView() {
        enviromentView.InitView();
        foodView.InitView();
        snakeBodyView.InitView();
    }

    public void UpdateView() {
        enviromentView.UpdateView();
        foodView.UpdateView();
        snakeBodyView.UpdateView();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
            SnakeApplication.GetInstance().Notify(SnakeNotifications.PressUp);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
            SnakeApplication.GetInstance().Notify(SnakeNotifications.PressLeft);

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
            SnakeApplication.GetInstance().Notify(SnakeNotifications.PressDown);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
            SnakeApplication.GetInstance().Notify(SnakeNotifications.PressRight);

        if (Input.GetKeyDown(KeyCode.C)) 
            SnakeApplication.GetInstance().Notify(SnakeNotifications.ChangeGameSpeed, 1f , "float");
    }
}