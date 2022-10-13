using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinData", menuName = "Skins/SkinData", order = 0)]
public class SkinData : ScriptableObject
{
    public Sprite skinImage;
    public string skinName;
    public int cost;
    public bool isUnlocked;
}
