using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTranslationBombB : MonoBehaviour
{
    public float RotationSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(
            Vector3.left *RotationSpeed *Time.deltaTime +
                 Vector3.down *RotationSpeed *Time.deltaTime +
                 Vector3.forward *RotationSpeed *Time.deltaTime,
            Space.Self
            );
    }
}
