using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver {
    string[] ListNotificationInterests();
    void HandeNotification(string notificationName, object body = null, string type = null);    
}
