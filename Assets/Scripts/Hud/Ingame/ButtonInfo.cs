using UnityEngine;
using System.Collections;

public class ButtonInfo : MonoBehaviour
{
    GameObject m_objectToSpawn;
    GameObject m_buildingPlacer;
    // To make it work all classes that we should be able to create by pressing a building needs to have json text to diferentiate them.
    // I suppose this is not necesary if we dont want json files to easily create new classes
    string m_jsonTextToSpawnWith;
    // Use this for initialization
    void Start()
    {
        m_buildingPlacer = GameObject.Find("BuildingPlacer"); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetGameObjectToSpawn(GameObject p_objectToSpawn)
    {
        m_objectToSpawn = p_objectToSpawn;
    }

    public void SetJsonInfoToSpawnWith(string p_jsonText)
    {
        m_jsonTextToSpawnWith = p_jsonText;
    }

    public void SetPlacementObject()
    {
        m_buildingPlacer.GetComponent<MapPicking>().SetBuildingToPlaceWithInfo(m_objectToSpawn, m_jsonTextToSpawnWith);

    }
}
