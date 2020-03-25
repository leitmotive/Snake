using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class InteractiveElement {
    public Vector3Int position;
    int type;

    public abstract void Interact();
    public virtual void Interact(InteractiveElement element) {
        Interact();
    }
}

public static class SimpleInteractiveElementFactory {
    public static InteractiveElement CreateElement(string elementsClassName, Vector3Int position) {
        InteractiveElement element = CreateElement(elementsClassName);
        element.position = position;
        return element;
    }
    public static InteractiveElement CreateElement(string elementsClassName) {
        if (elementsClassName == "SnakesBodyElement")
            return new SnakesBodyElement();
        else if (elementsClassName == "FoodElement") 
            return new FoodElement();
        else if (elementsClassName == "BlankInteractiveElement") 
            return new BlankInteractiveElement();
        else if (elementsClassName == "SolidWall") 
            return new SolidWall(); 
        else if (elementsClassName == "TeleportWall") 
            return new TeleportWall();
        
        return new BlankInteractiveElement();
    }
}

public class BlankInteractiveElement : InteractiveElement {
    public override void Interact() {}
}

public class FoodElement : InteractiveElement {
    public override void Interact() {
        SnakeApplication.GetInstance().Notify(SnakeNotifications.IncreaseSnake);
        SnakeApplication.GetInstance().Notify(SnakeNotifications.FoodSwallow, this.position, "Vector3Int");
        SnakeApplication.GetInstance().Notify(SnakeNotifications.ChangeGameSpeed, 0.3f , "float");
        SnakeApplication.GetInstance().Notify(SnakeNotifications.ChangePoints, 1000 , "int");
    }
}

public class HealthyFood : InteractiveElement {
    public override void Interact() {
        SnakeApplication.GetInstance().Notify(SnakeNotifications.IncreaseSnake);
        SnakeApplication.GetInstance().Notify(SnakeNotifications.IncreaseSnake);
        SnakeApplication.GetInstance().Notify(SnakeNotifications.FoodSwallow, this.position, "Vector3Int");
        SnakeApplication.GetInstance().Notify(SnakeNotifications.ChangeGameSpeed, 1f , "float");
    }
}

public class SolidWall : InteractiveElement {
    public override void Interact() {
        SnakeApplication.GetInstance().Notify(SnakeNotifications.KillSnake);
        Debug.Log("Die");
    }
}

public class TeleportWall : InteractiveElement {
    public override void Interact() {
        SnakeApplication.GetInstance().Notify(SnakeNotifications.JumpSnake);
        Debug.Log("Jump");
    }
}

public class SnakesBodyElement : InteractiveElement {
    public override void Interact() {
        SnakeApplication.GetInstance().Notify(SnakeNotifications.KillSnake);
        Debug.Log("Die");
    }
}