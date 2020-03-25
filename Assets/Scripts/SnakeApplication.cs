using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeApplication : MonoBehaviour {
    private static SnakeApplication application;
    public static SnakeApplication GetInstance() {
        return application;
    }

    public GameSettings Settings;
    Notifier mainObserver;  
    public SnakeModel model;
    public List<Controller> controllers;
    public SnakeView view;

    public UIView uIView;

    public void Notify(string notificationName, object body = null, string type = null){
        mainObserver.NotifyObservers(notificationName, body, type);
    }

    void Awake() {
        application = this;
        mainObserver = new Notifier();
        controllers = new List<Controller>();
 
        RegisterController(new GameStartController());
        Notify(SnakeNotifications.ShowGameDifficultyWindow);
    }

    public void RegisterController(Controller controller) {
        mainObserver.RegisterObserver(controller);
        controllers.Add(controller);
    }

    public void RemoveController(Controller controller) {
        mainObserver.RemoveObserver(controller);
        controllers.Remove(controller);
    }

    void Update()
    {
        for(int i = 0; i < controllers.Count; i++)
            controllers[i].UpdateController();
    }
}
