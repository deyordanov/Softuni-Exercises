namespace ProxyDesignPattern.Models.Video.Contracts;

public interface IVideoDownloader
{
    Video GetVideo(string name);
}