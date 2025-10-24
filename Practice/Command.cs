using System;
using System.Collections.Generic;

interface ICommand { void Execute(); void Undo(); }

class Light {
    public void On() => Console.WriteLine("💡 Свет включен");
    public void Off() => Console.WriteLine("💡 Свет выключен");
}

class LightOnCommand : ICommand {
    Light l;
    public LightOnCommand(Light l) => this.l = l;
    public void Execute() => l.On();
    public void Undo() => l.Off();
}

class LightOffCommand : ICommand {
    Light l;
    public LightOffCommand(Light l) => this.l = l;
    public void Execute() => l.Off();
    public void Undo() => l.On();
}

class RemoteControl {
    Stack<ICommand> history = new();
    public void Press(ICommand c) { c.Execute(); history.Push(c); }
    public void Undo() { if (history.Count > 0) history.Pop().Undo(); }
}

class Program {
    static void Main() {
        Light light = new();
        ICommand on = new LightOnCommand(light);
        ICommand off = new LightOffCommand(light);
        RemoteControl rc = new();
        rc.Press(on);
        rc.Press(off);
        rc.Undo();
    }
}
