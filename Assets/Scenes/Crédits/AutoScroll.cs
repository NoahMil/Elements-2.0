using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoScroll : MonoBehaviour
{
    public float speed = 80.0f;

    private float textPosBegin = -1800f;

    private float boundaryTextEnd = 3600f;

    private RectTransform myGoRectTransform;

    [SerializeField] private TextMeshProUGUI mainText;
    // Start is called before the first frame update
    void Start()
    {
        myGoRectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }

    IEnumerator AutoScrollText()
    {
        while (myGoRectTransform.localPosition.y < boundaryTextEnd)
        {
            myGoRectTransform.Translate(Vector3.up*speed*Time.deltaTime);
            yield return null;
        }
    }

}
