using UnityEngine;
using System.Collections;

public class ButtonInfo : MonoBehaviour
{
    GameObject m_objectToSpawn;
    // To make it work all classes that we should be able to create by pressing a building needs to have json text to diferentiate them.
    // I suppose this is not necesary if we dont want json files to easily create new classes
    string m_jsonTextToSpawnWith;
    // Use this for initialization
    void Start()
    {

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

    public void SpawnObject()
    {
        GameObject newObject = Instantiate(m_objectToSpawn);
        newObject.GetComponent<BuildingJsonInfo>().m_jsonText = m_jsonTextToSpawnWith;
        newObject.GetComponent<BuildingJsonInfo>().enabled = true;
    }
}
