using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodView : View {
    Food foodModel;
    public GameObject foodObject;
    public List<GameObject> FoodElementsView;

    void Awake() {
        FoodElementsView = new List<GameObject>();
    }
    public override void InitView() {
        InitFoodsView();
    }

    void InitFoodsView() {
        removeObjects(FoodElementsView);
        foodModel = SnakeApplication.GetInstance().model.food;
        syncListView(FoodElementsView, foodModel.GetFood(), foodObject);
    }

    public override void  UpdateView() {
        syncListView(FoodElementsView, foodModel.GetFood(), foodObject);
    }
}
