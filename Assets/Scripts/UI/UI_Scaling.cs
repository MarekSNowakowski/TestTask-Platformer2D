using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scaling : MonoBehaviour
{
    [SerializeField]
    float heightRatio;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        var size = heightRatio * Screen.height;
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
    }
}
