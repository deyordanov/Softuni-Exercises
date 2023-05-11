using System.Text;

int n = int.Parse(Console.ReadLine());
Stack<string> operations = new Stack<string>();
StringBuilder text = new StringBuilder(string.Empty);
for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int command = int.Parse(input[0]);
    switch (command)
    {
        case 1:
            operations.Push(text.ToString());
            text.Append(input[1]);
            break;
        case 2:
            int elementsToRemove = int.Parse(input[1]);
            operations.Push(text.ToString());
            text.Remove(text.Length - elementsToRemove, elementsToRemove);
            break;
        case 3:
            int index = int.Parse(input[1]) - 1;
            Console.WriteLine(text[index]);
            break;
        case 4:
            text = new StringBuilder(operations.Pop());
            break;
    }
}
