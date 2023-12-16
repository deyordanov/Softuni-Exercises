long sum = 0;

Task t1 = new Task(() =>
{
    for (long i = 0; i <= 100000000; i++)
    {
        if (i % 2 == 0)
        {
            Thread.Sleep(1000);
            sum += i;
        }
    }
});

t1.Start(); 

while (true)
{
    string command = Console.ReadLine();
    if (command == "show")
    {
        Console.WriteLine(sum);
    }
    else if (command == "exit")
    {
        return;
    }
}