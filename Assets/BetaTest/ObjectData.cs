using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable", menuName = "Interactable")]
public class ObjectData : ScriptableObject
{
    public Sprite clean;
    public Sprite dirty;
    public float scoreWorth;    //0-1
    public float tapsToDestroy;   //0-1
    public float giveBabyDirt;  //0-1
}
