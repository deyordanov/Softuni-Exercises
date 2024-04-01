namespace ProxyDesignPattern.Proxies;

using Models.Video;
using Models.Video.Contracts;

public class VideoDownloaderProxy : IVideoDownloader
{
    private readonly List<Video> _cache;
    private readonly IVideoDownloader _videoDownloader;

    public VideoDownloaderProxy()
    {
        this._cache = new List<Video>();
        this._videoDownloader = new RealVideoDownloader();
    }

    public Video GetVideo(string name)
    {
        if (this._cache.All(v => v.Name != name))
        {
            this._cache.Add(new Video(name));
        }
        else
        {
            Console.WriteLine("Retrieving video from cache...");
        }

        return this._cache.First(v => v.Name == name);
    }
}