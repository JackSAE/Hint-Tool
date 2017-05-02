using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{

    public GameObject[] go;
    public List<string> HintNames = new List<string>();
    public Sprite defaultSprite;

    //Variables used to display on UI
    public Text hintText;
    public GameObject HintImage;
    public GameObject hintShow;

    [SerializeField]
    private float hintTimer = 3;

    [SerializeField]
    private bool setActive;

    public bool reSizePannel = false;

    UIAutoReSize autoReSize;

    // Use this for initialization
    void Start()
    {
        go = GameObject.FindGameObjectsWithTag("Hints");
        HintImage = GameObject.FindGameObjectWithTag("SpriteImage");
        //autoReSize = GameObject.FindGameObjectWithTag("UIAutoReSize").GetComponent<UIAutoReSize>();
        hintShow.SetActive(false);

        Debug.Log(go.Length);
    }

    private void Update()
    {
        HintTimer(Time.deltaTime);
    }

    public void DisplayHintToScreen(string name, string hint_text, bool isRepeat, Sprite hint_Image)
    {
        

        if (hint_Image == null)
        {
            //This will be the sprite that will be displayed
            HintImage.GetComponent<Image>().overrideSprite = defaultSprite;
        }
        else
        {
            HintImage.GetComponent<Image>().overrideSprite = hint_Image;
        }

        if (HintNames.Count == 0)
        {
            HintNames.Add(name);

            //Display it to the screen.
            hintText.text = hint_text;

            //autoReSize.reSize(hint_text);

            setActive = true;
        }
        else
        {
            bool found = false;
            for (int i = 0; i < HintNames.Count; ++i)
            {
                if (HintNames[i] == name)
                {
                    found = true;
                }
            }
            if (!found)
            {
                //Add it to the list.
                HintNames.Add(name);

                //Display it to the screen.
                hintText.text = hint_text;

                //autoReSize.reSize(hint_text);

                setActive = true;
            }
            else
            {
                if (isRepeat)
                {
                    //Display it anyway cause its been marked to be repeated.
                    hintText.text = hint_text;

                    //autoReSize.reSize(hint_text);
                    setActive = true;
                }

            }
        }
    }

    //Timer for the hint system
    void HintTimer(float delta)
    {

        if (setActive)
        {
            hintShow.SetActive(true);

            hintTimer -= delta;

            if (hintTimer < 0)
            {
                hintShow.SetActive(false);
                hintTimer = 3;
                setActive = false;
            }
        }
    }
}
