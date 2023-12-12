using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTag : MonoBehaviour
{
    private RectTransform rectTransform;

    private RectTransform parentRectTransform;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, Input.mousePosition, null, out Vector2 localPoint);
        transform.localPosition = localPoint;
    }
}
