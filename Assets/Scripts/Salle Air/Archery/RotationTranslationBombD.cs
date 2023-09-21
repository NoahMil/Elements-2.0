using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTranslationBombD: MonoBehaviour
{
    public float RotationSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(
            Vector3.left *RotationSpeed *Time.deltaTime +
                 Vector3.up *RotationSpeed *Time.deltaTime +
                 Vector3.back *RotationSpeed *Time.deltaTime,
            Space.Self
            );
    }
}
