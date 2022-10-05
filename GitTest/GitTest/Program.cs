// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using System.IO;

public class TestGit
{
    public static TestGit? Instance { get; private set; }

    TestGit()
    {
        Instance = this;
    }

    static void Main()
    {
        new TestGit();
        Instance?.RunSolution();
    }

    void RunSolution()
    {
        while (true)
        {
            SelectTypeOfCalculation();
        }
    }

    void SelectTypeOfCalculation()
    {
        Console.WriteLine("Which type of calculation do you want \r");
        Console.WriteLine("-->   Press 1 for power");
        int input = Convert.ToInt32(Console.ReadLine());
        switch (input)
        {
            case 1:
                CalculatePower();
                break;
        }
    }

    void CalculatePower()
    {
        Console.WriteLine("Pleas enter an int for which you need the power");
        string? root_string = Console.ReadLine();

        string[] spits = root_string.Split(".");
        if (spits.Length > 1)
        {
            Console.WriteLine("You've entered a float");
            Double squared = Convert.ToDouble(root_string);
            squared *= squared;
            Console.WriteLine("The square of" + root_string + " is " + squared);
        }
        else
        {
            Console.WriteLine("You've entered an int");
            int squared = Convert.ToInt32(root_string);
            squared *= squared;
            Console.WriteLine("The square of" + root_string + " is " + squared);
        }       
    }
}
