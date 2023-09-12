using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Nouvelle Target")]
public class Target : ScriptableObject
{
    public GameObject gameObject;
    public int hp = 1;
    public bool targetCompleted;

}
