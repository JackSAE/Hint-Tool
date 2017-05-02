using System.Collections;
using UnityEngine;

public class Hint : ScriptableObject {

    public string hintName;
    public string text;
    public Sprite hintImage;
    public GameObject hintCollider;
    public bool isRepeatable = false;

}
