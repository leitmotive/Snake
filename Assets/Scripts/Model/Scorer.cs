using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Scorer {
    public int Score;
    public int TopScore;

    public Scorer() {
        Score = 0;
        TopScore = 0;
    }

    public void addPoints(int points) {
        Score += points;

        if (Score > TopScore) 
            TopScore = Score;
    }

    public void resetScore() {
        Score = 0;
    }
}