using System;
using System.Collections.Generic;

interface ICommand
{
    void Execute();
    void Undo();
}

class Light
{
    public void On() => Console.WriteLine("Свет включен");
    public void Off() => Console.WriteLine("Свет выключен");
}

class Door
{
    public void Open() => Console.WriteLine("Дверь открыта");
    public void Close() => Console.WriteLine("Дверь закрыта");
}

class LightOnCommand : ICommand
{
    Light light;
    public LightOnCommand(Light l) => light = l;
    public void Execute() => light.On();
    public void Undo() => light.Off();
}

class DoorOpenCommand : ICommand
{
    Door door;
    public DoorOpenCommand(Door d) => door = d;
    public void Execute() => door.Open();
    public void Undo() => door.Close();
}

class RemoteControl
{
    Stack<ICommand> history = new Stack<ICommand>();
    public void Press(ICommand c)
    {
        c.Execute();
        history.Push(c);
    }
    public void Undo()
    {
        if (history.Count > 0)
            history.Pop().Undo();
        else
            Console.WriteLine("Нет команд для отмены");
    }
}

class Program
{
    static void Main()
    {
        var remote = new RemoteControl();
        var light = new Light();
        var door = new Door();

        remote.Press(new LightOnCommand(light));
        remote.Press(new DoorOpenCommand(door));

        remote.Undo();
        remote.Undo();
    }
}
