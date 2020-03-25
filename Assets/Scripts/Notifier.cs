using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier 
{
    private Dictionary<string, IList<IObserver>> observerMap;

    public Notifier() {
        observerMap = new Dictionary<string, IList<IObserver>>();
    }
    public void RegisterObserver(IObserver observer)
    {
        if (observer == null)
        {
            Debug.Log("error cannot register observer");
            return;
        }

        string[] interests = observer.ListNotificationInterests();

        if (interests.Length > 0)
        {
            for (int i = 0; i < interests.Length; i++)
            {
                RegisterObserver(interests[i], observer);
            }
        }
    }

    public virtual void RegisterObserver(string notificationName, IObserver observer)
    {
        if (observerMap.TryGetValue(notificationName, out IList<IObserver> observers))
        {
            observers.Add(observer);
        }
        else
        {
            observerMap.Add(notificationName, new List<IObserver> { observer });
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observer == null)
        {
            Debug.Log("error cannot remove observer");
            return;
        }

        string[] interests = observer.ListNotificationInterests();
        if (interests.Length > 0)
        {
            for (int i = 0; i < interests.Length; i++)
            {
                RemoveObserver(interests[i], observer);
            }
        }
    }

    public virtual void RemoveObserver(string notificationName, IObserver observer)
    {
        if (observerMap.TryGetValue(notificationName, out IList<IObserver> observers))
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }
    }

    public void SendMessage(string notificationName, object body = null, string type = null)
    {
        NotifyObservers(notificationName, body, type);
    }

    public void NotifyObservers(string notificationName, object body = null, string type = null)
    {
        if (observerMap.TryGetValue(notificationName, out IList<IObserver> observers))
        {
            for(int i = 0; i < observers.Count; i++)
            {
                observers[i].HandeNotification(notificationName, body, type);
            }
        }
    }
}
