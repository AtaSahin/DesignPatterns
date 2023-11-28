using System;


interface IStrategy
{
    void Execute();
}


class ConcreteStrategy1 : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing ConcreteStrategy1");
    }
}


class ConcreteStrategy2 : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing ConcreteStrategy2");
    }
}


class Context
{
    private IStrategy strategy;

    public Context(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        strategy.Execute();
    }
}

class Program
{
    static void Main()
    {

        IStrategy strategy1 = new ConcreteStrategy1();
        IStrategy strategy2 = new ConcreteStrategy2();


        Context context = new Context(strategy1);


        context.ExecuteStrategy();


        context.SetStrategy(strategy2);


        context.ExecuteStrategy();

        Console.ReadLine();
    }
}
