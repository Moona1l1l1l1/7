using System;

abstract class Beverage
{
    public void Prepare()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (WantAddons())
            AddCondiments();
    }

    void BoilWater() => Console.WriteLine("Кипятим воду");
    void PourInCup() => Console.WriteLine("Наливаем в кружку");

    protected abstract void Brew();
    protected abstract void AddCondiments();
    protected virtual bool WantAddons() => true;
}

class Tea : Beverage
{
    protected override void Brew() => Console.WriteLine("Завариваем чай");
    protected override void AddCondiments() => Console.WriteLine("Добавляем лимон");
}

class Coffee : Beverage
{
    protected override void Brew() => Console.WriteLine("Завариваем кофе");
    protected override void AddCondiments() => Console.WriteLine("Добавляем сахар и молоко");
    protected override bool WantAddons()
    {
        Console.Write("Добавить молоко и сахар? (y/n): ");
        return Console.ReadLine()?.ToLower() == "y";
    }
}

class Program2
{
    static void Main()
    {
        new Tea().Prepare();
        new Coffee().Prepare();
    }
}
