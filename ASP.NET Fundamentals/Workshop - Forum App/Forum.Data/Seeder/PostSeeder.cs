namespace Forum.Data.Seeder;

using Models;

public class PostSeeder
{
    internal Post[] GeneratePosts()
    {
        ICollection<Post> posts = new HashSet<Post>();

        posts.Add(new Post { Title = "Exploring the Sky", Content = "A brief look into aeronautical advancements." });
        posts.Add(new Post { Title = "The Future of Software", Content = "Predicting the next big trends in technology." });
        posts.Add(new Post { Title = "Fitness and You", Content = "Balancing workout routines with a busy schedule." });
        posts.Add(new Post { Title = "Engineering Dreams", Content = "The journey of becoming a leading aeronautical engineer." });
        posts.Add(new Post { Title = "Coding Challenges", Content = "Solving complex problems in .Net and React." });

        return posts.ToArray();
    }
}