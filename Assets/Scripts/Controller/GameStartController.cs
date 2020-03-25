using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStartController : Controller {

    public List<Controller> GameControllers;
    public override string[] ListNotificationInterests() {
        return new string[] { SnakeNotifications.InitGame, SnakeNotifications.StopGame };
    }

    public override void HandeNotification(string notificationName, object body = null, string type = null) {
        if (notificationName == SnakeNotifications.InitGame && type == "string")
            TryInitGame((string)body);

        if (notificationName == SnakeNotifications.StopGame)
            StopGame();
    }

    private void TryInitGame(string settingsPath) {
        try {
            InitGame(settingsPath);
        } catch (Exception ex) {
            Debug.LogError(ex.ToString());
        }
    }

    private void InitGame(string settingsPath) {
        LoadGameSettingsFromPath(settingsPath);
        InitModelWithSettings(app.Settings);
        RegisterGameControllers();
        app.view.InitView();
    
        StartGame();
    }

    void StartGame() {
        app.Notify(SnakeNotifications.UpdateView);
        app.Notify(SnakeNotifications.StartGame);
        app.Notify(SnakeNotifications.FoodSpawn);
    }

    void StopGame() {
        RemoveGameControllers();
    }

    private void LoadGameSettingsFromPath(string settingsPath) {
        app.Settings = Resources.Load<GameSettings>(settingsPath);
    }

    private void InitModelWithSettings(GameSettings settings) {
        app.model = GameInitHelper.InitModelWithSettings(settings);
    }

    private void RegisterGameControllers() {
        GameControllers = GameInitHelper.GetRequaredControllers();
        foreach(Controller controller in GameControllers) {
            app.RegisterController(controller);
        }
    }

    private void RemoveGameControllers() {
        foreach(Controller controller in GameControllers) 
            app.RemoveController(controller);

        GameControllers.Clear();
    }
}