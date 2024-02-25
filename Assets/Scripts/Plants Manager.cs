using Unity.VisualScripting;
using UnityEngine;

public class PlantsManager : MonoBehaviour {
    /* -------------------------------- Variables ------------------------------- */
    public static PlantsManager Instance;

    [Header("Plants")]
    public GameObject plantsParent;
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
    public void Plant(PlantSO plantId) {
        // Check if selected location is plantable
        if (tileSelector.IsCorrectTilemap(tileSelector.dirtTilemap)) {
            
        }
    }
}
