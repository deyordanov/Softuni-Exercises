Queue<string> kids = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
int n = int.Parse(Console.ReadLine());
while(kids.Count > 1)
{
    for(int i = 0; i < n; i++)
    {
        string currentKid = kids.Dequeue(); 
        if(i == n - 1)
        {
            Console.WriteLine($"Removed {currentKid}");
        }
        else
        {
            kids.Enqueue(currentKid);
        }
    }  
}
Console.WriteLine($"Last is {kids.Dequeue()}");