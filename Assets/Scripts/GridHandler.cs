using UnityEngine;
using System.Collections;

public class GridHandler : MonoBehaviour {

    // Public variables
    [Header("Grid size option")]
    [Tooltip("Used for deciding the size of the grid")]
    public GameObject groundPlane;
    [Tooltip("Number of cells in Z")]
    public float numberOfCellsZ;
    [Tooltip("Number of cells in X")]
    public float numberOfCellsX;
    
    public int currentlySelectedGridX { get; set; }
    public int currentlySelectedGridZ { get; set; }
    // Private variables
    float gridSizeZ;
    float gridSizeX;

    float cellSizeZ;
    float cellSizeX;
    // Unity functions

	// Use this for initialization
	void Start () {
        Vector3 t_groundScale = groundPlane.transform.lossyScale;
        t_groundScale *= 10;
        gridSizeX = t_groundScale.x;
        gridSizeZ = t_groundScale.z;

        // Calculate how big each cell can be
        cellSizeZ = gridSizeZ / numberOfCellsZ;
        cellSizeX = gridSizeX / numberOfCellsX;

        //LightUpCell(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    // Private functions;
    public void TransformPositionToCellNumber(Vector3 p_position, out int o_cellNumberX, out int o_cellNumberZ)
    {
        float t_positionX = p_position.x;
        float t_positionZ = p_position.z;

        o_cellNumberX = Mathf.FloorToInt((t_positionX + gridSizeX * 0.5f - cellSizeX * 0.5f) / cellSizeX + 0.5f);
        o_cellNumberZ = Mathf.FloorToInt((t_positionZ + gridSizeZ * 0.5f - cellSizeZ * 0.5f) / cellSizeZ + 0.5f);
    }

    // out variables will contain the origo of the cell
    public void TransformCellNumberToPosition(int p_cellNumberX, int p_cellNumberZ, out Vector3 o_position)
    {
        float t_positionX = (float)p_cellNumberX * cellSizeX - gridSizeX * 0.5f + cellSizeX * 0.5f;
        float t_positionZ = (float)p_cellNumberZ * cellSizeZ - gridSizeZ * 0.5f + cellSizeZ * 0.5f;
        o_position = new Vector3(t_positionX, 0, t_positionZ); 
    }
}
