using UnityEngine;
using System.Collections;

public class MapPicking : MonoBehaviour {
    public GameObject gameField; // The plane that covers the whole world 

    [Header("Cell visualization")]
    [Tooltip("Offset of how far up the cell highlighter will be placed")]
    public float highlightOffsetY;
    [Tooltip("Cell highlighter")]
    public GameObject cellHighlighter;

    // Private
    GridHandler gridHandler;
    GameObject buildingToPlace = null;
    string jsonText = null;
    // Use this for initialization
    void Start () {
        gridHandler = transform.GetComponent<GridHandler>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 t_hitPosition;
        Ray t_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float t_distance = 0;
        Plane gamePlane = new Plane(new Vector3(0, 1, 0), -gameField.transform.position.y);
        if (gamePlane.Raycast(t_ray, out t_distance))
        {
            t_hitPosition = t_ray.GetPoint(t_distance);
            LightUpCell(t_hitPosition);
            if (Input.GetMouseButtonDown(0) && buildingToPlace != null)
            {
                Vector3 t_positionToPlaceBuilding;
                gridHandler.TransformCellNumberToPosition(gridHandler.currentlySelectedGridX, gridHandler.currentlySelectedGridZ, out t_positionToPlaceBuilding);
                GameObject newObject = (GameObject)Instantiate(buildingToPlace, t_positionToPlaceBuilding, Quaternion.identity);
                newObject.GetComponent<BuildingJsonInfo>().m_jsonText = jsonText;
                newObject.GetComponent<BuildingJsonInfo>().enabled = true;
            }     
        }

        
	}

    // Will not use Y dimension,  will also set currently active cell TODO maybee a bit wierd that it set the active
    private void LightUpCell(Vector3 p_position)
    {
        int t_cellNumberX;
        int t_cellNumberZ;
        Vector3 t_positionToLightUp;
        gridHandler.TransformPositionToCellNumber(p_position, out t_cellNumberX, out t_cellNumberZ);
        gridHandler.TransformCellNumberToPosition(t_cellNumberX, t_cellNumberZ, out t_positionToLightUp);
        gridHandler.currentlySelectedGridX = t_cellNumberX;
        gridHandler.currentlySelectedGridZ = t_cellNumberZ;
        t_positionToLightUp.y = highlightOffsetY;
        cellHighlighter.transform.position = t_positionToLightUp;
    }

    // Should probably not be here but lets go with it for now..
    public void SetBuildingToPlaceWithInfo(GameObject p_object, string p_jsonText)
    {
        buildingToPlace = p_object;
        jsonText = p_jsonText;
    }
}
