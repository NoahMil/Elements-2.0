using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Target")]
public class Target : ScriptableObject
{
    public int hpMax = 2;
    public int hp;
    public bool targetDestroyed;
}
