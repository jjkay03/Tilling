using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {
    /* -------------------------------- Variables ------------------------------- */
    bool showConsole;
    string input;
    float consoleY = 20f;

    public static DebugCommand TEST;
    
    public List<object> commandList;

    /* --------------------------------- Methods -------------------------------- */
    void Update() {
        // Check if the backtick (`) key is pressed
        if (Input.GetKeyDown(KeyCode.BackQuote)) { OnToggleDebug(); }

        // Check if return (enter) key is pressed
        if (Input.GetKeyDown(KeyCode.Return)) { OnReturn(); }
    }
    
    private void Awake() {
        // Comands
        TEST = new DebugCommand("test", "Test command", "test", () => {
            Debug.Log("[COMMAND] TEST");
        });

        // Update comamnd list
        commandList = new List<object> {
            TEST,
        };
    }

    public void OnReturn() {
        if (showConsole) {
            HandleInput();
            input = "";
        }
    }

    public void OnToggleDebug() {
        showConsole = !showConsole;
        if (showConsole) { Debug.Log("TOGGLED CONSOLE"); }
    }

    private void OnGUI() {
        // Remove GUI if showConsole is false
        if (!showConsole) { return; }

        GUI.Box(new Rect(0, consoleY, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, consoleY+5f, Screen.width-20f, 20f), input);

    }

    private void HandleInput() {
        // Search through command list
        for(int i=0; i<commandList.Count; i++){
            
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;
            
            // Check if comamnd id matches input
            if(input.Contains(commandBase.commandId)){
                
                // Check if object type is correct
                if(commandList[i] as DebugCommand != null) {
                    
                    // Cast to this type and invoke the command
                    (commandList[i] as DebugCommand).Invoke();
                }
            }
        }
    }
}
