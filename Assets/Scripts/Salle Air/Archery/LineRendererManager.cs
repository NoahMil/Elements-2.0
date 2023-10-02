using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererManager : MonoBehaviour
{

    public LineRenderer _lineRenderer;
    public LayerMask _uiLayer;
    public Transform leftController;
    public Transform rightController;

    void Update()
    {
        RaycastHit hitLeft, hitRight;
    }

}
