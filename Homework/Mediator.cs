using System;
using System.Collections.Generic;

interface IMediator
{
    void Send(string msg, User user);
    void Register(User user);
}

class ChatRoom : IMediator
{
    List<User> users = new List<User>();
    public void Register(User u) => users.Add(u);
    public void Send(string msg, User sender)
    {
        foreach (var u in users)
            if (u != sender)
                u.Receive(msg);
    }
}

class User
{
    public string Name { get; }
    IMediator chat;

    public User(string name, IMediator c)
    {
        Name = name;
        chat = c;
        chat.Register(this);
    }

    public void Send(string msg)
    {
        Console.WriteLine($"{Name}: {msg}");
        chat.Send(msg, this);
    }

    public void Receive(string msg)
    {
        Console.WriteLine($"{Name} получил сообщение: {msg}");
    }
}

class Program3
{
    static void Main()
    {
        var chat = new ChatRoom();
        var a = new User("Али", chat);
        var b = new User("Бек", chat);

        a.Send("Привет!");
        b.Send("Привет, как дела?");
    }
}
