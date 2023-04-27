using CollectionHierarchy.Models;

AddCollection add = new AddCollection();
AddRemoveCollection remove = new AddRemoveCollection();
MyList list = new MyList();
string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
int[,] resultOfAdding = new int[3, input.Length];
int index = 0;
foreach(string item in input)
{
    resultOfAdding[0, index] = add.Add(item);
    resultOfAdding[1, index] = remove.Add(item);
    resultOfAdding[2, index] = list.Add(item);
    index++;
}

for (int row = 0; row < resultOfAdding.GetLength(0); row++)
{
    for (int col = 0; col < resultOfAdding.GetLength(1); col++)
    {
        Console.Write(resultOfAdding[row, col] + " ");
    }
    Console.WriteLine();
}

int numberOfRemoves = int.Parse(Console.ReadLine());
string[][] resultOfRemoving = new string[2][];
resultOfRemoving[0] = new string[numberOfRemoves];
resultOfRemoving[1] = new string[numberOfRemoves];
for (int i = 0; i < numberOfRemoves; i++)
{
    resultOfRemoving[0][i] = remove.Remove();
    resultOfRemoving[1][i] = list.Remove();
}

foreach (string[] array in resultOfRemoving)
{
    Console.WriteLine(string.Join(" ", array));
}
