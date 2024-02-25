using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour {
    /* -------------------------------- Variables ------------------------------- */
    public static long START_EPOCH_TIMESTAMP;
    public static long CURRENT_EPOCH_TIMESTAMP;
    public static int GOLD = 0;

    /* --------------------------------- Methods -------------------------------- */
    // START
    void Start() {
        // Set the start time
        START_EPOCH_TIMESTAMP = GetCurrentEpochTimestamp();
    }

    // UPDATE 
    void Update() {
        // Update current time
        UpdateEpochTimestamp();
    }

    // Update CURRENT_EPOCH_TIMESTAMP
    private void UpdateEpochTimestamp() {
        // Calculate the elapsed time since the game started
        float elapsedSeconds = Time.time;

        // Calculate the current timestamp by adding the elapsed time to the start timestamp
        CURRENT_EPOCH_TIMESTAMP = (long)(START_EPOCH_TIMESTAMP + elapsedSeconds);
    }

    // Get current Eapoch timestamp
    private long GetCurrentEpochTimestamp() {
        DateTime now = DateTime.UtcNow;
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        long secondsSinceEpoch = (long)(now - epoch).TotalSeconds;
        return secondsSinceEpoch;
    }
}
