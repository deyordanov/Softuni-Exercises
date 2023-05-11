int bulletPrice = int.Parse(Console.ReadLine());
int gunbarrelSize = int.Parse(Console.ReadLine());
Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
Queue<int> locks = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
int value = int.Parse(Console.ReadLine());
int bulletsShot = 0;
int reload = 0;
while(bullets.Count > 0 && locks.Count > 0)
{
    reload++;
    bulletsShot++;
    if (bullets.Peek() <= locks.Peek())
    {
        Console.WriteLine("Bang!");
        bullets.Pop();
        locks.Dequeue();       
    }
    else
    {
        Console.WriteLine("Ping!");
        bullets.Pop();
    }

    if(reload == gunbarrelSize && bullets.Count > 0)
    {
        reload = 0;
        Console.WriteLine("Reloading!");
    }
}

string output = locks.Count == 0 ? $"{bullets.Count} bullets left. Earned ${value - (bulletsShot * bulletPrice)}"
    : $"Couldn't get through. Locks left: {locks.Count}";
Console.WriteLine(output);