using System;
using System.Collections.Generic;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light
{
    public void On() => Console.WriteLine("Свет включен.");
    public void Off() => Console.WriteLine("Свет выключен.");
}

public class Television
{
    public void On() => Console.WriteLine("Телевизор включен.");
    public void Off() => Console.WriteLine("Телевизор выключен.");
}

public class LightOnCommand : ICommand
{
    private Light l;
    public LightOnCommand(Light light) { l = light; }
    public void Execute() { l.On(); }
    public void Undo() { l.Off(); }
}

public class LightOffCommand : ICommand
{
    private Light l;
    public LightOffCommand(Light light) { l = light; }
    public void Execute() { l.Off(); }
    public void Undo() { l.On(); }
}

public class TelevisionOnCommand : ICommand
{
    private Television t;
    public TelevisionOnCommand(Television tv) { t = tv; }
    public void Execute() { t.On(); }
    public void Undo() { t.Off(); }
}

public class TelevisionOffCommand : ICommand
{
    private Television t;
    public TelevisionOffCommand(Television tv) { t = tv; }
    public void Execute() { t.Off(); }
    public void Undo() { t.On(); }
}

public class RemoteControl
{
    private ICommand onCmd;
    private ICommand offCmd;

    public void SetCommands(ICommand on, ICommand off)
    {
        onCmd = on;
        offCmd = off;
    }

    public void PressOnButton() => onCmd?.Execute();
    public void PressOffButton() => offCmd?.Execute();
    public void PressUndoButton() => onCmd?.Undo();
}

class Program
{
    static void Main()
    {
        Light light = new Light();
        Television tv = new Television();
        ICommand lightOn = new LightOnCommand(light);
        ICommand lightOff = new LightOffCommand(light);
        ICommand tvOn = new TelevisionOnCommand(tv);
        ICommand tvOff = new TelevisionOffCommand(tv);
        RemoteControl remote = new RemoteControl();

        Console.WriteLine("Свет:");
        remote.SetCommands(lightOn, lightOff);
        remote.PressOnButton();
        remote.PressOffButton();
        remote.PressUndoButton();

        Console.WriteLine("\nТелевизор:");
        remote.SetCommands(tvOn, tvOff);
        remote.PressOnButton();
        remote.PressOffButton();
    }
}
