using System;

string[] numbers = Console.ReadLine().Split(" ");

long sum = 0;
foreach (string number in numbers)
{
    try
    {
        int num = int.Parse(number);

        sum += num;
    }
    catch (FormatException fe)
    { 
        Console.WriteLine($"The element '{number}' is in wrong format!");
    }
    catch (OverflowException oe)
    {
        Console.WriteLine($"The element '{number}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{number}' processed - current sum: {sum}");
    }
}

Console.WriteLine($"The total sum of all integers is: {sum}");