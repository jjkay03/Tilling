using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour {
    /* -------------------------------- Variables ------------------------------- */
    public static Vector2Int GRID_POSITION;
    public static Vector2Int PREVIOUS_GRID_POSITION;
    public static Tilemap ACTIVE_TILEMAP;
    
    public Grid tileGrid;
    [Header("Tilemaps")]
    public Tilemap selectorTilemap;
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
        UpdateDirtSelector();
    }

    // Update cell position
    void UpdateGridPosition() {
        Vector2Int position = LocationOnGrid();

        // Chenage GRID_POSITION if it changed
        if (position != PREVIOUS_GRID_POSITION) {
            GRID_POSITION = position;
            PREVIOUS_GRID_POSITION = GRID_POSITION;

            //Debug.Log("GRID: " + GRID_POSITION);
        }
    }

    // Update the active Tilemap based on GRID_POSITION
    void UpdateActiveTilemap() {
        Tilemap[] tilemaps = tileGrid.GetComponentsInChildren<Tilemap>();
        foreach (Tilemap tilemap in tilemaps) {
            if (tilemap.GetTile(new Vector3Int(GRID_POSITION.x, GRID_POSITION.y, 0)) != null) {
                ACTIVE_TILEMAP = tilemap;
                return;
            }
        }
        ACTIVE_TILEMAP = null;
    }
    
    // Update the dirt selector
    void UpdateDirtSelector() {
        // Detect if its the right timemap
        if (IsCorrectTilemap(dirtTilemap)) {
            // Place slectorTile on selectorTilemap at GRID_POSITION
            selectorTilemap.SetTile(new Vector3Int(GRID_POSITION.x, GRID_POSITION.y, 1), slectorTile);
            Debug.Log("Placed selector");
        }
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
