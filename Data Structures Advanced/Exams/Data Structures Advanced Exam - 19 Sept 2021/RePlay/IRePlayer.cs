using System.Collections.Generic;

namespace Exam.RePlay
{
    public interface IRePlayer
    {
        void AddTrack(Track track, string album);

        void RemoveTrack(string trackTitle, string albumName);

        bool Contains(Track track);

        int Count { get; }

        Track GetTrack(string title, string albumName);

        IEnumerable<Track> GetAlbum(string albumName);

        void AddToQueue(string trackName, string albumName);

        Track Play();

        IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound);

        IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending();

        Dictionary<string, List<Track>> GetDiscography(string artistName);
    }
}
