using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PannelAutoSize : MonoBehaviour {

    [SerializeField]
    int textLength;

    public void reSize(string hint_text)
    {

        textLength = hint_text.Length;

        Debug.Log(this.gameObject.GetComponent<RectTransform>().rect.width);
        Debug.Log(this.gameObject.GetComponent<RectTransform>().rect.height);

        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(this.gameObject.GetComponent<RectTransform>().rect.width + (textLength * 2), this.gameObject.GetComponent<RectTransform>().rect.height);
    }
}
