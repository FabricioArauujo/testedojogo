using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SlotTag { None, Proteinas, Lipidios, acidosLaticos, glicose}

[CreateAssetMenu(menuName = "RPG 2D/Item")]
public class item : ScriptableObject
{
    public Sprite sprite;
    public SlotTag itemTag;
}
