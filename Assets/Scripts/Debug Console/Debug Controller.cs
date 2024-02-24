using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour {
    /* -------------------------------- Variables ------------------------------- */
    public bool allowDebugConsole = false;
    
    bool showConsole;
    bool showHelp;
    string input;
    Vector2 scroll;

    public static DebugCommand HELP;
    public static DebugCommand TEST;
    public static DebugCommand<int> TEST2;
    
    public List<object> commandList;

    /* --------------------------------- Methods -------------------------------- */
    void Update() {
        // Check if the backtick (`) key is pressed
        if (Input.GetKeyDown(KeyCode.BackQuote) && allowDebugConsole) { OnToggleDebug(); }

        // Check if return (enter) key is pressed
        if (Input.GetKeyDown(KeyCode.Return)) { OnReturn(); }
    }
    
    private void Awake() {
        // Comands
        HELP = new DebugCommand("help", "Show a list of commands", "help", () => {
            Debug.Log("[COMMAND] HELP");
            showHelp = true;
        });
        TEST = new DebugCommand("test", "Test command", "test", () => {
            Debug.Log("[COMMAND] TEST");
        });
        TEST2 = new DebugCommand<int>("test2", "Test command with argument", "test2 <int>", (x) => {
            Debug.Log("[COMMAND] TEST2: " + x);
        });
        

        // Update comamnd list
        commandList = new List<object> {
            HELP,
            TEST,
            TEST2
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
        //if (showConsole) { Debug.Log("TOGGLED CONSOLE"); }
    }

    private void OnGUI() {
        float consoleY = 20f;

        // Remove GUI if showConsole is false
        if (!showConsole) { return; }

        // Show help section if showHelp is true
        if (showHelp) {
            GUI.Box(new Rect(0, consoleY, Screen.width, 100), "");
            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);
            scroll = GUI.BeginScrollView(new Rect(0, consoleY+5f, Screen.width, 90), scroll, viewport);
            
            for (int i=0; i<commandList.Count; i++) {
                DebugCommandBase command = commandList[i] as DebugCommandBase;
                string label = $"{command.commandFormat} - {command.commandDescription}";
                Rect labelRect = new Rect(5, 20*i, viewport.width - 100, 20);
                GUI.Label(labelRect, label);
            }

            GUI.EndScrollView();
            consoleY += 100;
        }

        GUI.Box(new Rect(0, consoleY, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, consoleY+5f, Screen.width-20f, 20f), input);

    }

    private void HandleInput() {

        string[] properties = input.Split(' ');

        // Search through command list
        for (int i=0; i<commandList.Count; i++){
            
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;
            
            // Check if comamnd id matches input
            if (input.Contains(commandBase.commandId)){
                
                // Check if object type is correct (no args)
                if (commandList[i] as DebugCommand != null) {
                    (commandList[i] as DebugCommand).Invoke();
                }

                // Check if object type is correct (1 arg)
                else if (commandList[i] as DebugCommand<int> != null) {
                    (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
                }
            }
        }
    }
}
