using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimpleLevelFactory {
    public static Level CreateLevel(string levelName, int levelWidth, int levelHeight) {
        if (levelName == "PlainLevel")
            return new PlainLevel(levelWidth, levelHeight);
        else if (levelName == "ComplexLevel") 
            return new ComplexLevel(levelWidth, levelHeight);

        return new PlainLevel(levelWidth, levelHeight);
    }
}