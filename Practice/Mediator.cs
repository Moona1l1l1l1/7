using System;
using System.Collections.Generic;

interface IMediator {
    void Send(string msg, User u);
    void Add(User u);
}

class ChatMediator : IMediator {
    List<User> users = new();
    public void Add(User u) => users.Add(u);
    public void Send(string msg, User s) {
        foreach (var u in users)
            if (u != s) u.Receive(msg);
    }
}

class User {
    string name;
    IMediator med;
    public User(string n, IMediator m) { name = n; med = m; }
    public void Send(string msg) {
        Console.WriteLine($"{name} отправил: {msg}");
        med.Send(msg, this);
    }
    public void Receive(string msg) =>
        Console.WriteLine($"{name} получил: {msg}");
}

class Program3 {
    static void Main() {
        ChatMediator chat = new();
        User a = new("Али", chat);
        User b = new("Бек", chat);
        chat.Add(a);
        chat.Add(b);
        a.Send("Салам!");
        b.Send("Ваалейкум, брат!");
    }
}
