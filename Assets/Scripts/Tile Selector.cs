using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour {
    /* -------------------------------- Variables ------------------------------- */
    public Grid tileGrid;
    
    public static Vector2Int GRID_POSITION;
    public static Vector2Int PREVIOUS_GRID_POSITION;


    /* --------------------------------- Methods -------------------------------- */
    // Update
    void Update() {
        UpdateGridPosition();
    }

    // Update cell position
    void UpdateGridPosition() {
        Vector2Int position = LocationOnGrid();

        // Chenage GRID_POSITION if it changed
        if (position != PREVIOUS_GRID_POSITION) {
            GRID_POSITION = position;
            PREVIOUS_GRID_POSITION = GRID_POSITION;

            //Debug.Log("Cell changed: " + GRID_POSITION);
        }
    }

    // Get cursor coards on grid
    Vector2Int LocationOnGrid() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition3D = tileGrid.WorldToCell(mousePosition);
        
        // Convert the 3D cell position to 2D
        Vector2Int cellPosition2D = new Vector2Int(cellPosition3D.x, cellPosition3D.y);

        return cellPosition2D;
    }
}
