using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour {
    /* -------------------------------- Variables ------------------------------- */
    public static Vector2Int GRID_POS;
    public static Vector2Int PREVIOUS_GRID_POS;
    public static Vector2Int SELECTED_POS;
    public static Tilemap ACTIVE_TILEMAP;
    
    [Header("Tilemaps")]
    public Grid tileGrid;
    public Tilemap plantsTilemap;
    public Tilemap dirtTilemap;
    [Header("Tiles")]
    public Tile slectorTile;


    /* --------------------------------- Methods -------------------------------- */
    // Update
    void Update() {
        // Update methods
        UpdateGridPosition();
        UpdateActiveTilemap();

        // Select
        if (Input.GetMouseButtonDown(0)) {
            SelectGridPosition();
        }
    }

    // Update cell position
    void UpdateGridPosition() {
        Vector2Int position = LocationOnGrid();

        // Chenage GRID_POSITION if it changed
        if (position != PREVIOUS_GRID_POS) {
            GRID_POS = position;
            PREVIOUS_GRID_POS = GRID_POS;

            //Debug.Log("GRID: " + GRID_POSITION);
        }
    }

    // Update the active Tilemap based on GRID_POSITION
    void UpdateActiveTilemap() {
        Tilemap[] tilemaps = tileGrid.GetComponentsInChildren<Tilemap>();
        foreach (Tilemap tilemap in tilemaps) {
            if (tilemap.GetTile(new Vector3Int(GRID_POS.x, GRID_POS.y, 0)) != null) {
                ACTIVE_TILEMAP = tilemap;
                return;
            }
        }
        ACTIVE_TILEMAP = null;
    }
    
    // Update the dirt selector
    void SelectGridPosition() {
        // Remove old selector
        dirtTilemap.SetTile(new Vector3Int(SELECTED_POS.x, SELECTED_POS.y, 1), null);

        // Place selector (dirt)
        if (IsCorrectTilemap(dirtTilemap)) {
            dirtTilemap.SetTile(new Vector3Int(GRID_POS.x, GRID_POS.y, 1), slectorTile);
        }

        // Update SELECTED_GRID_POSITION
        SELECTED_POS = GRID_POS;
    }

    // Method that checks if ACTIVE_TILEMAP is a specific tilemap
    bool IsCorrectTilemap(Tilemap tilemap) {
        return ACTIVE_TILEMAP != null && ACTIVE_TILEMAP.name == tilemap.name;
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
