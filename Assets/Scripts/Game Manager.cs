using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantableTilemapDetector : MonoBehaviour {
    /* -------------------------------- Variables ------------------------------- */
    public Grid grid;
    public Tilemap plantableTilemap;

    /* --------------------------------- Methods -------------------------------- */
    void Update() {
        DetectMouseOverPlantable();
    }

    void DetectCursorCell() {
        // Get the mouse position in world coordinates
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Convert the world position to cell coordinates on the grid
        Vector3Int cellPosition = grid.WorldToCell(mouseWorldPos);
    }

    void DetectMouseOverPlantable() {
        // Get the mouse position in world coordinates
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Cast a ray to detect if the mouse is over a Collider2D with the "Plantable" tag
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

        // Check if the hit object has the "Plantable" tag
        if (hit.collider != null && hit.collider.CompareTag("Plantable")) {
            Debug.Log("Mouse is over a plantable object!");
        }
    }
}
