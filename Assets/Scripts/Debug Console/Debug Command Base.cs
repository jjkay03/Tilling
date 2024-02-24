using UnityEngine;
using System;

public class DebugCommandBase {
    
    private string _commandId;
    private string _commandDescription;
    private string _commandFormat;

    public string commandId { get { return _commandId; } }
    public string commandDescription { get { return _commandDescription; } }
    public string commandFormat { get { return _commandFormat; } }

    public DebugCommandBase(string id, string description, string format) {
        _commandId = id;
        _commandDescription = description;
        _commandFormat = format;
    }
}

// Command no argument
public class DebugCommand : DebugCommandBase {

    public Action command;

    public DebugCommand(string id, string description, string format, Action command) : base (id, description, format) {
        this.command = command;
    }

    public void Invoke() {
        command.Invoke();
    }
}

// Command with 1 argument
public class DebugCommand<T1> : DebugCommandBase {

    public Action<T1> command;

    public DebugCommand(string id, string description, string format, Action<T1> command) : base (id, description, format) {
        this.command = command;
    }

    public void Invoke(T1 value) {
        command.Invoke(value);
    }
}