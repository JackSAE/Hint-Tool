using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class HintWindow : EditorWindow {


    Texture2D headerSectionTexture;
    Texture2D hintSectionTExture;

    Color headerSectionColor = new Color(43f / 255f, 144f / 255f, 217f / 255f); 

    Rect headerSection;
    Rect hintSection;

    static HintData hintData;

    public static HintData hintInfo {  get { return hintData; } }



    [MenuItem("Window/Hint Creator")]
    static void OpenWindow()
    {
        HintWindow window = (HintWindow)GetWindow(typeof(HintWindow));
        window.minSize = new Vector2(250, 200);
        window.Show();
    }


    void OnGUI()
    {

        

        //Make the Editor Window look nice <>
        DrawLayouts();
        DrawWindow();

        //Create all the other shit here <>


    }

    void InitWindow()
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

    }

    void OnEnable()
    {
        InitWindow();
        InitData();
    }

    public static void InitData()
    {
        hintData = (HintData)ScriptableObject.CreateInstance(typeof(HintData));
    }

    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = Screen.height;

        GUI.DrawTexture(headerSection, headerSectionTexture);
    }

    void DrawWindow()
    {

        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Hint Creator");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Hint Image");
        hintData.hintImage = (Sprite)EditorGUILayout.ObjectField(hintData.hintImage,typeof(Sprite),false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Hint Collider");
        hintData.hintCollider = (GameObject)EditorGUILayout.ObjectField(hintData.hintCollider,typeof(GameObject),false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Hint Name");
        hintData.hintName = EditorGUILayout.TextField(hintData.hintName);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Hint Text");
        hintData.text = EditorGUILayout.TextField(hintData.text);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Is this going to be used more than once?");
        hintData.isRepeatable = EditorGUILayout.Toggle(hintData.isRepeatable);
        EditorGUILayout.EndHorizontal();

        if (hintData.hintCollider == null)
        {
            EditorGUILayout.HelpBox("This hint needs a [GameObject] before it can be created.", MessageType.Warning);
        }
        else if (hintData.hintName == null || hintData.hintName.Length < 1)
        {
            EditorGUILayout.HelpBox("This hint needs a [Name] before it can be created.", MessageType.Warning);
        }
        else if (hintData.text == null || hintData.text.Length < 1)
        {
            EditorGUILayout.HelpBox("This hint needs a [text] before it can be created.", MessageType.Warning);
        }
        else if (GUILayout.Button("Finish and Save", GUILayout.Height(30)))
        {
            SaveAndAddHint();

        }
        GUILayout.EndArea();

    }

    void SaveAndAddHint()
    {
        //Save Data 

        //Add as a script to the selected gameObject

        string prefabPath;
        string newPrefabPath = "Assets/prefabs/";
        string secondPrefabPath = "Assets/resources/prefabs/";
        string dataPath = "Assets/resources/hintData/data/";

        dataPath += "hint/" + HintWindow.hintInfo.hintName + ".asset";
        AssetDatabase.CreateAsset(HintWindow.hintInfo, dataPath);

        newPrefabPath += "hints/" + HintWindow.hintInfo.hintName + ".prefab";

        prefabPath = AssetDatabase.GetAssetPath(HintWindow.hintInfo.hintCollider);

        AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        GameObject hintPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
        if (!hintPrefab.GetComponent<HintClass>())
            hintPrefab.AddComponent(typeof(HintClass));
        hintPrefab.GetComponent<HintClass>().hintData = HintWindow.hintInfo;


        #region old_Code
        /*
        secondPrefabPath += "hints/" + HintEpisodeWindow.hintInfo.hintName + ".prefab";

        prefabPath = AssetDatabase.GetAssetPath(HintEpisodeWindow.hintInfo.hintCollider);

        AssetDatabase.CopyAsset(prefabPath, secondPrefabPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        GameObject hintPrefabsecond = (GameObject)AssetDatabase.LoadAssetAtPath(secondPrefabPath, typeof(GameObject));
        if (!hintPrefabsecond.GetComponent<HintClass>())
            hintPrefabsecond.AddComponent(typeof(HintClass));
        hintPrefabsecond.GetComponent<HintClass>().hintData = HintEpisodeWindow.hintInfo;
        */
        #endregion

        GetWindow(typeof(HintWindow)).Close(); //Closes window when its down? 
    }
}
