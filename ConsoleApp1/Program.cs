using System;

public sealed class Singleton
{

    private static Singleton instance;


    private static readonly object lockObject = new object();


    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {

            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }


    public void DisplayMessage()
    {
        Console.WriteLine("Singleton example usage");
    }
}

class Program
{
    static void Main()
    {

        Singleton singletonInstance = Singleton.Instance;


        singletonInstance.DisplayMessage();


        Singleton anotherInstance = Singleton.Instance;


        if (singletonInstance == anotherInstance)
        {
            Console.WriteLine("2 instances are the same time of Singleton class");
        }

        Console.ReadLine();
    }
}