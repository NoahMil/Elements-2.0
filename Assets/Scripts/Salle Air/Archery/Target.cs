using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Nouvelle Target")]
public class Target : ScriptableObject
{
    public int hpMax = 2;
    public int HP = 1;
    public float speed = 0.5f;
    public float amplitude = 1.0f;
    public bool targetCompleted = false;

}
