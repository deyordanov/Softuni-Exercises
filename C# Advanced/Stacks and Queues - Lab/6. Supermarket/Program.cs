string end;
Queue<String> queue = new Queue<String>();
while((end = Console.ReadLine()) != "End")
{
    string input = end;
    if(input == "Paid")
    {
        while(queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }
    }
    else
    {
        queue.Enqueue(input);
    }
}
Console.WriteLine($"{queue.Count()} people remaining.");