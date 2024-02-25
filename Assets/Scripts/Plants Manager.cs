using Unity.VisualScripting;
using UnityEngine;

public class PlantsManager : MonoBehaviour {
    /* -------------------------------- Variables ------------------------------- */
    public static PlantsManager Instance;

    [Header("Plants")]
    public GameObject plantsParent;
    public GameObject plantObject;

    [Header("Plants ScriptableObjects")]
    public PlantSO PLANT_PUMKIN;
    public PlantSO PLANT_CARROT;

    private TileSelector tileSelector;

    /* --------------------------------- Methods -------------------------------- */
    // START
    void Start() {
        // Get componments
        tileSelector = GetComponent<TileSelector>();
    }
    
    // UPDATE
    void Update() { 
        if (Input.GetKeyDown(KeyCode.Space)) {
            Plant(PLANT_PUMKIN);
        }
    }

    // Plant a plant
    public void Plant(PlantSO plantSO) {
        // Check if selected location is plantable
        if (tileSelector.IsCorrectTilemap(tileSelector.dirtTilemap)) {
            // Create a plant object
            GameObject newPlant = Instantiate(plantObject, plantsParent.transform);

            // Give name to game object
            newPlant.name = plantSO.name;

            // Get the PlantObject component attached to the new plant
            PlantObject newPlantScript = newPlant.GetComponent<PlantObject>();
            
            // Edit script variables of plant object
            if (newPlantScript != null) {
                newPlantScript.plantSO = plantSO;
                newPlantScript.plantedCoards = TileSelector.SELECTED_POS;
                newPlantScript.plantedTime = GameManager.CURRENT_EPOCH_TIMESTAMP;
                newPlantScript.lastWaterTime = GameManager.CURRENT_EPOCH_TIMESTAMP;
            }
            
            // Place stage 0 plant tile
            tileSelector.plantsTilemap.SetTile(new Vector3Int(newPlantScript.plantedCoards.x, newPlantScript.plantedCoards.y, 1), plantSO.tileStage0);
        }
    }
}
