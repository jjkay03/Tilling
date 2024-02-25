using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Plant SO", menuName = "Sciptable Object/Plant")]
public class PlantSO : ScriptableObject {

    [Header("Text")]
    public new string name;
    public string description;

    [Header("Stats")]
    public int timeInStage0;
    public int timeInStage1;
    public int timeInStage2;
    public int timeInStage3;
    public int waterDelay;
    public int sellPrice;

    [Header("Data")]
    public Vector2Int plantedCoards;
    public long plantedTime;
    public long lastWaterTime;
    public bool isCollectable = false;

    [Header("Tiles")]
    public Tile tileStage0;
    public Tile tileStage1;
    public Tile tileStage2;
    public Tile tileStage3;
    public Tile tileStage4;

}
