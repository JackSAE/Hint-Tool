using System.Collections;
using UnityEngine;

public class HintClass : MonoBehaviour {

    public HintData hintData;
    public GameObject player;
    public HintController hintController;

    MeshRenderer meshRenderer;

    public Material inactiveMaterial;
    public Material activeMaterial;

    private float interactLateInput;

    bool emitterOff = false;

    bool inRangeOfObject = false;

    void Start()
    {
        Test();
        player = GameObject.FindGameObjectWithTag("Player");
        hintController = GameObject.FindGameObjectWithTag("HintController").GetComponent<HintController>();
    }

    void Test()
    {
        Debug.Log(hintData.hintName);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.name);

            Debug.Log(hintData.hintName);
            Debug.Log(hintData.text);
            Debug.Log(hintData.isRepeatable);
            Debug.Log(hintData.hintImage);

            hintController.DisplayHintToScreen( hintData.hintName, hintData.text , hintData.isRepeatable, hintData.hintImage );

            inRangeOfObject = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRangeOfObject = false;
        }
    }

}
