using System;
using System.Collections.Generic;

public interface IMediator
{
    void SendMessage(string message, Colleague sender);
}

public abstract class Colleague
{
    protected IMediator mediator;
    public Colleague(IMediator m) { mediator = m; }
    public abstract void ReceiveMessage(string message);
}

public class ChatMediator : IMediator
{
    private List<Colleague> colleagues = new List<Colleague>();
    public void RegisterColleague(Colleague c) => colleagues.Add(c);

    public void SendMessage(string msg, Colleague sender)
    {
        foreach (var c in colleagues)
            if (c != sender) c.ReceiveMessage(msg);
    }
}

public class User : Colleague
{
    private string name;
    public User(IMediator m, string n) : base(m) { name = n; }

    public void Send(string msg)
    {
        Console.WriteLine($"{name} отправляет: {msg}");
        mediator.SendMessage(msg, this);
    }

    public override void ReceiveMessage(string msg)
    {
        Console.WriteLine($"{name} получил: {msg}");
    }
}

class Program
{
    static void Main()
    {
        ChatMediator chat = new ChatMediator();
        User u1 = new User(chat, "Алиса");
        User u2 = new User(chat, "Боб");
        User u3 = new User(chat, "Чарли");

        chat.RegisterColleague(u1);
        chat.RegisterColleague(u2);
        chat.RegisterColleague(u3);

        u1.Send("Привет всем!");
        u2.Send("Привет, Алиса!");
        u3.Send("Всем привет!");
    }
}
