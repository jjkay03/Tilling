using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantableTilemapDetector : MonoBehaviour
{
    /* -------------------------------- Variables ------------------------------- */
    public Grid tileGrid;


    /* --------------------------------- Methods -------------------------------- */
    void Update() {
        LocationOnGrid();
    }

    void LocationOnGrid() {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Convert the world coordinates to cell coordinates on the grid
        Vector3Int cellPosition = tileGrid.WorldToCell(mousePosition);

        // Output the cell position
        Debug.Log("Cell Position: " + cellPosition);
    }
}
