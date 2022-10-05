// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using System.IO;

public class TestGit
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static TestGit? Instance { get; private set; }

    /// <summary>
    /// Constructor to set up singleton
    /// </summary>
    TestGit()
    {
        Instance = this;
    }

    /// <summary>
    /// Start of the solution 
    /// </summary>
    static void Main()
    {
        new TestGit();
        Instance?.RunSolution();
    }

    /// <summary>
    /// Run the solution, contains the loop of logic
    /// </summary>
    void RunSolution()
    {
        bool isStillRunning = true;
        while (isStillRunning)
        {
            SelectTypeOfCalculation();
            isStillRunning = CheckIfUserWantsToContinue();
        }
    }
    bool CheckIfUserWantsToContinue()
    {
        bool isStillRunning = true;
        Console.WriteLine("Do you still whish to use this app :: yes ? no ?");
        string? choice = "";
        while (choice == "")
        {
            choice = Console.ReadLine();

            if (choice == "")
            {
                Console.WriteLine("Please Say Yes Or No");
            }
            else
            {
                choice.ToLower().Trim();
                if (choice[0].ToString() == "y")
                {
                    Console.WriteLine("Well as you wish, lets go !! ");
                }
                else if (choice[0].ToString() == "n")
                {
                    Console.WriteLine("Well as you wish, lets go !! ");
                    isStillRunning = false;
                }
                else
                {
                    Console.WriteLine("Please Say Yes Or No");
                    choice = "";
                }
            }
        }
        return isStillRunning;
    }

    /// <summary>
    /// A fonction to selec te type of calculation
    /// </summary>
    void SelectTypeOfCalculation()
    {
        bool isInputRight = false;
        ValidDigit validDigit = new ValidDigit();
        while (!isInputRight) 
        {
            Console.WriteLine("Which type of calculation do you want \r");
            Console.WriteLine("-->   Press 1 for power");
            validDigit = GetDigitFromConsole();
            isInputRight = validDigit.isValid;
        }

        switch (Convert.ToInt32(validDigit.line))
        {
            case 1:
                CalculatePower();
                break;
        }
    }

    /// <summary>
    /// A fonction to calculate the powr of a number depending on a further read line statement
    /// </summary>
    void CalculatePower()
    {
        bool isInputRight = false;
        ValidDigit validDigit = new ValidDigit();
        while (!isInputRight)
        {
            Console.WriteLine("Pleas enter an int for which you need the power");
            validDigit = GetDigitFromConsole();
            isInputRight = validDigit.isValid;
        }

        string root_string = validDigit.line;
        string[] spits = root_string.Split(".");

        if (spits.Length > 1)
        {
            Console.WriteLine("You've entered a float");
            Double squared = Convert.ToDouble((root_string));
            squared *= squared;
            Console.WriteLine("The square of" + root_string + " is " + squared);
        }
        else
        {
            Console.WriteLine("You've entered an int");
            int squared = Convert.ToInt32((root_string));
            squared *= squared;
            Console.WriteLine("The square of" + root_string + " is " + squared);
        }       
    }

    private ValidDigit GetDigitFromConsole()
    {
        string readLine = "";
        ValidDigit validDigit;
        try
        {
            readLine = Console.ReadLine();
            Double input = Convert.ToDouble(readLine);
        }
        catch (Exception e)
        {
            Console.WriteLine("Please enter a number");
            return new ValidDigit(readLine, false);
        }
        return new ValidDigit(readLine, true);
    }
}

public class ValidDigit
{
    public string line;
    public bool isValid;
    public ValidDigit() { line = ""; this.isValid = false; }
    public ValidDigit (string line, bool isValid)
    {
        this.line = line;
        this.isValid = isValid;
        if (line == null)
        {
            line = "";
        }
    }
}
