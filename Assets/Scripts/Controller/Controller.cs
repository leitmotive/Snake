using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Controller : IObserver {    
    public abstract string[] ListNotificationInterests();

    public abstract void HandeNotification(string notificationName, object body = null, string type = null);

    public SnakeApplication app { get {
            return SnakeApplication.GetInstance();
        }
    }

    public virtual void UpdateController(){
    }
}
