// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;

public class TestGit
{
    static void Main()
    {
        Console.WriteLine("Pleas enter an int for which you need the power");
        int root_num = Convert.ToInt32(Console.ReadLine());
        int power_num = CalculatePower(root_num);
        Console.WriteLine("The power of " + root_num + " is " + power_num);
    }

    static int CalculatePower(int root_num)
    {
        int power_num = root_num * root_num;

        return power_num;
    }
}
