using System;

public abstract class Beverage
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    private void BoilWater() => Console.WriteLine("Кипячение воды...");
    private void PourInCup() => Console.WriteLine("Наливание в чашку...");
    protected abstract void Brew();
    protected abstract void AddCondiments();
}

public class Tea : Beverage
{
    protected override void Brew() => Console.WriteLine("Заваривание чая...");
    protected override void AddCondiments() => Console.WriteLine("Добавление лимона...");
}

public class Coffee : Beverage
{
    protected override void Brew() => Console.WriteLine("Заваривание кофе...");
    protected override void AddCondiments() => Console.WriteLine("Добавление сахара и молока...");
}

class Program
{
    static void Main()
    {
        Beverage tea = new Tea();
        Console.WriteLine("Чай:");
        tea.PrepareRecipe();

        Console.WriteLine();

        Beverage coffee = new Coffee();
        Console.WriteLine("Кофе:");
        coffee.PrepareRecipe();
    }
}
