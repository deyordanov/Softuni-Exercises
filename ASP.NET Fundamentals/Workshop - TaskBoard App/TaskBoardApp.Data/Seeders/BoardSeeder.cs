namespace TaskBoardApp.Data.Seeders;

using Models;

public class BoardSeeder
{
    internal IEnumerable<Board> GenerateBoards()
    {
        return new HashSet<Board>()
        {
            new Board()
            {
                Id = 1,
                Name = "Open"
            },
            new Board()
            {
                Id = 2,
                Name = "In Progress"
            },
            new Board()
            {
                Id = 3,
                Name = "Done"
            }
        };
    }
}