using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class ButtonBuilder: MonoBehaviour {
    // Public variables
    [Header("Building types")]
    [Tooltip("The button associated with buildings")]
    public GameObject buildingButton;
    [Tooltip("Should contain the local path to the root of building")]
    public string m_buildingFolderPath;

    private List<Transform> m_buildingTypes = new List<Transform>();
    // The path should be at the top of the folderstructure for buildings.
    // This script will be going through every json in that file structure and create structures from them
    void Start () {
        m_buildingTypes.AddRange(transform.GetComponentsInChildren<Transform>());
        
        // Build all buttons for buildings

        string absoluteBuildingFolderPath = Application.dataPath + m_buildingFolderPath;

        int buttonsCreated = 0;
        // Get all json files in the root folder and sub directories by using a recursive method
        List<string> allJsonFiles = FindAllJsonFilesInRoot(absoluteBuildingFolderPath);
        // Lopp through all found json files
        foreach (var jsonFile in allJsonFiles)
        {
            // Create the header from the json file
            string t_jsonText = System.IO.File.ReadAllText(jsonFile);
            JsonHeader header = JsonUtility.FromJson<JsonHeader>(t_jsonText);
            // Go through every possible building type. Note that a new building type will need to recide in AllBuildings
            foreach (Transform buildingType in m_buildingTypes)
            {
                // Go through all classes that inherit building json info
                foreach (var classType in buildingType.GetComponents<BuildingJsonInfo>())
                {
                    // If we found the correct building type
                    if (classType.name == header.handledByClass)
                    {
                        // Create a new button for the building
                        GameObject newButton = (GameObject)Instantiate(buildingButton, GetComponentInParent<Canvas>().transform);
                        newButton.GetComponentInChildren<Text>().text = header.name;                        
                        newButton.GetComponent<ButtonInfo>().SetGameObjectToSpawn(buildingType.gameObject);
                        newButton.GetComponent<ButtonInfo>().SetJsonInfoToSpawnWith(t_jsonText);
                        newButton.transform.localPosition += new Vector3(1000* buttonsCreated, 0, 0);
                        buttonsCreated++;
                    }
                }
            } 
        }
         
	}

    List<string> FindAllJsonFilesInRoot(string p_rootDirectory)
    {
        List<string> files = new List<string>();
        // FInd all subdirectories
        string[] subDirectories = Directory.GetDirectories(p_rootDirectory);
        foreach (var directoryPath in subDirectories)
        {
            // Go to the next subfolder and do the same thing again
            files.AddRange(FindAllJsonFilesInRoot(directoryPath));
        }
        // When we have been to the bottom of the directory structure we look for .json files
        files.AddRange(Directory.GetFiles(p_rootDirectory, "*.json"));
        return files;
    }
	
}
