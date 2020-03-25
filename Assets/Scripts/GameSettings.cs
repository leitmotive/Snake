using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings: ScriptableObject
{
    public float StartSpeed;
    public string LevelName;
    public int LevelWidth;
    public int LevelHeight;
    public int LengthQuantityToWin;
}
