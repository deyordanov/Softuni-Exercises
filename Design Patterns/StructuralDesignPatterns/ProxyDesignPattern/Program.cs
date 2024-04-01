using ProxyDesignPattern.Models.Internet.Contracts;
using ProxyDesignPattern.Models.Video.Contracts;
using ProxyDesignPattern.Proxies;

IInternet internet = new InternetProxy();
internet.ConnectTo("google.com");
internet.ConnectTo("banned.com");

Console.WriteLine("<======================>");

IVideoDownloader videoDownloader = new VideoDownloaderProxy();
videoDownloader.GetVideo("video1");
videoDownloader.GetVideo("video1");
videoDownloader.GetVideo("video2");
videoDownloader.GetVideo("video3");
videoDownloader.GetVideo("video2");