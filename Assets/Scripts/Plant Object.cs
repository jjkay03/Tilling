using UnityEngine;

public class PlantObject : MonoBehaviour {

    [Header("Plant ScriptableObject")]
    public PlantSO plantSO;

    [Header("Data")]
    public Vector2Int plantedCoards;
    public long plantedTime;
    public long lastWaterTime;
    public bool isCollectable = false;

}