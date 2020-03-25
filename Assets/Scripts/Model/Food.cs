using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food {
    public abstract void addFood(InteractiveElement food);
    public abstract List<InteractiveElement> GetFood();
    public abstract void removeFood(InteractiveElement food);
    public abstract Vector3Int GetLastFoodPosition();
    public abstract void resetFood();
    public abstract InteractiveElement GetCurrentFoodElement();
}

public class SimpleFood: Food {
    List<InteractiveElement> foodList;
    Vector3Int lastFoodPosition;
    public  SimpleFood() {
        foodList = new List<InteractiveElement>();
    }

    public override void addFood(InteractiveElement food) {
        foodList.Add(food);
    }

    public override List<InteractiveElement> GetFood() {
        return foodList;
    }

    public override void removeFood(InteractiveElement food) {
        lastFoodPosition = food.position;
        foodList.Remove(food);
    }

    public override Vector3Int GetLastFoodPosition() {
        return lastFoodPosition;
    }

    public override void resetFood() {
        foodList.Clear();
    }
    public override InteractiveElement GetCurrentFoodElement() {
        InteractiveElement food;
        if (foodList.Count == 0) {
            food = SimpleInteractiveElementFactory.CreateElement("FoodElement");
            foodList.Add(food);
        }
        return foodList[0];
    }
}