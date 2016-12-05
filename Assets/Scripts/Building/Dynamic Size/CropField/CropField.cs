using UnityEngine;
using System.Collections;

public class CropField : MonoBehaviour {
    private CropFieldGlobals cropFieldImplementation;

    public float hp;
	// Use this for initialization
	void Start () {
        Debug.Log(Application.dataPath);
        LoadParametersFromFile(Application.dataPath + "/Scripts/Building/Dynamic Size/CropField/JsonInformation/" + "WheatField.json");

        hp = cropFieldImplementation.hp;
        Debug.Log(hp);
    }
	
	// Update is called once per frame
	void Update () {
	}

    // Used to load data into classes from json file
    public void LoadParametersFromFile(string p_fileName)
    {
        string t_jsonText = System.IO.File.ReadAllText(p_fileName);
        cropFieldImplementation = JsonUtility.FromJson<CropFieldGlobals>(t_jsonText);
        t_jsonText = JsonUtility.ToJson(cropFieldImplementation);
    }
}
