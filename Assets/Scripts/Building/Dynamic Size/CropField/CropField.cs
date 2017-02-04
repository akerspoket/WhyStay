using UnityEngine;
using System.Collections;

public class CropField : BuildingJsonInfo {
    private CropFieldGlobals cropFieldImplementation;

    public float hp;
	// Use this for initialization
	void Start () {
        LoadParametersFromJson();
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(cropFieldImplementation.name);
	}

    // We are counting on the fact that the base has set the json text
    public void LoadParametersFromJson()
    {
        cropFieldImplementation = JsonUtility.FromJson<CropFieldGlobals>(m_jsonText);
    }
}
