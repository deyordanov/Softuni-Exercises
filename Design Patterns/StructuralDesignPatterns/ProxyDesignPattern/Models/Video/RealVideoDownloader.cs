namespace ProxyDesignPattern.Models.Video;

using Contracts;

public class RealVideoDownloader : IVideoDownloader
{
    public Video GetVideo(string name)
    {
        Console.WriteLine("Connecting to https://www.youtube.com/");
        Console.WriteLine("Downloading video.");
        Console.WriteLine("Retrieving Video Metadata");
        return new Video(name);
    }
}