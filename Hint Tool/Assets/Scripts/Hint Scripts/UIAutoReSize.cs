using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAutoReSize : MonoBehaviour {

    [SerializeField]
    int textLength;

    public GameObject pannelRect;
    public GameObject imageRect;
    public GameObject textRect;

    public void reSize(string hint_text)
    {
        #region setVars

        //pannelRect = GameObject.FindGameObjectWithTag("Pannel");
        //imageRect = GameObject.FindGameObjectWithTag("Image");
        //textRect = GameObject.FindGameObjectWithTag("Text");

        textLength = hint_text.Length;

        #endregion

        #region PannelReSize

        //Debug.Log(pannelRect.GetComponent<RectTransform>().rect.width);
        //Debug.Log(pannelRect.GetComponent<RectTransform>().rect.height);

        pannelRect.GetComponent<RectTransform>().sizeDelta = new Vector2(pannelRect.GetComponent<RectTransform>().rect.width + (textLength * 2), pannelRect.GetComponent<RectTransform>().rect.height);
        #endregion

        
        #region ImageReSize

        Debug.Log(imageRect.GetComponent<RectTransform>().position.x);
        Debug.Log(imageRect.GetComponent<RectTransform>().position.y);
        //160 - 19 | 30

        float imageSizeX = imageRect.GetComponent<RectTransform>().rect.position.x;
        float imageSizeY = imageRect.GetComponent<RectTransform>().rect.position.y;
        float iamgeX = imageSizeX - textLength;

        imageRect.GetComponent<RectTransform>().position = new Vector3(iamgeX, imageSizeY,0);

        #endregion

        #region textReSize

        Debug.Log(textRect.GetComponent<RectTransform>().rect.width);
        Debug.Log(textRect.GetComponent<RectTransform>().rect.height);


        //textRect.GetComponent<RectTransform>().sizeDelta = new Vector2(textRect.GetComponent<RectTransform>().rect.width + (textLength * 2), textRect.GetComponent<RectTransform>().rect.height);

        #endregion
    
    }
}
