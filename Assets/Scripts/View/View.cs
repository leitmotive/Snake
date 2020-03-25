using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {
    public virtual void InitView() {}

    public virtual void UpdateView() {}

    public void removeObjects(List<GameObject> ElementsView) {
        foreach (GameObject element in ElementsView)
            Destroy(element);
        
        ElementsView.Clear();
    }

    public void syncListView(List<GameObject> gameObjectList,  List<InteractiveElement> modelObjectList, GameObject prefabObject) {
            syncGameObjectsAmount(gameObjectList, modelObjectList, prefabObject);
            syncGameObjectsPosition(gameObjectList, modelObjectList);
    }

    public void syncGameObjectsAmount(List<GameObject> gameObjectList,  List<InteractiveElement> modelObjectList, GameObject prefabObject) {
        if (modelObjectList.Count > gameObjectList.Count) 
            while(gameObjectList.Count < modelObjectList.Count)
                gameObjectList.Add(Instantiate(prefabObject));
    }

    public void syncGameObjectsPosition(List<GameObject> gameObjectList,  List<InteractiveElement> modelObjectList) {
            int i = 0;
            foreach(var element in modelObjectList) {
                GameObject gameElementView = gameObjectList[i];
                gameElementView.transform.position = element.position;
                i++;
            }
    }

    public bool isOdd(int number) {
        return number % 2 != 0;
    }
}