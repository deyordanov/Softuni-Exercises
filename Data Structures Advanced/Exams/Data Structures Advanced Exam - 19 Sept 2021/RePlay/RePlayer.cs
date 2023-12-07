using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Exam.RePlay
{
    using System.Linq;

    public class RePlayer : IRePlayer
    {
        private Dictionary<string, Dictionary<string, Track>> tracksByAlbumNameAndTrackTitle;

        private Dictionary<string, Dictionary<string, Dictionary<string, Track>>> tracksByArtistNameAndAlbumName;

        private Dictionary<int, Dictionary<string, Track>> tracksByDurationAndAlbumName;

        private HashSet<Track> allTracks;

        private Dictionary<Track, LinkedListNode<Track>> listeningQueueNodes;

        private LinkedList<Track> listeningQueue;

        public RePlayer()
        {
            tracksByAlbumNameAndTrackTitle = new Dictionary<string, Dictionary<string, Track>>();
            tracksByArtistNameAndAlbumName = new Dictionary<string, Dictionary<string, Dictionary<string, Track>>>();
            tracksByDurationAndAlbumName = new Dictionary<int, Dictionary<string, Track>>();
            allTracks = new HashSet<Track>();
            listeningQueueNodes = new Dictionary<Track, LinkedListNode<Track>>();
            listeningQueue = new LinkedList<Track>();
        }
        public int Count => this.allTracks.Count;

        public void AddToQueue(string trackName, string albumName)
        {
            Track track = this.GetTrack(trackName, albumName);

            this.listeningQueue.AddLast(track);
            this.listeningQueueNodes.Add(track, this.listeningQueue.Last);
        }

        public void AddTrack(Track track, string album)
        {
            if (!this.tracksByAlbumNameAndTrackTitle.ContainsKey(album))
            {
                this.tracksByAlbumNameAndTrackTitle.Add(album, new Dictionary<string, Track>());
                this.tracksByAlbumNameAndTrackTitle[album].Add(track.Title, track);
                this.allTracks.Add(track);

                //TODO: REFACTOR
                if (!this.tracksByArtistNameAndAlbumName.ContainsKey(track.Artist))
                {
                    this.tracksByArtistNameAndAlbumName.Add(track.Artist, new Dictionary<string, Dictionary<string, Track>>());
                }

                if (!this.tracksByArtistNameAndAlbumName[track.Artist].ContainsKey(album))
                {
                    this.tracksByArtistNameAndAlbumName[track.Artist].Add(album, new Dictionary<string, Track>());
                }

                if (!this.tracksByArtistNameAndAlbumName[track.Artist][album].ContainsKey(track.Title))
                {
                    this.tracksByArtistNameAndAlbumName[track.Artist][album].Add(track.Title, track);
                }

                if (!this.tracksByDurationAndAlbumName.ContainsKey(track.DurationInSeconds))
                {
                    this.tracksByDurationAndAlbumName.Add(track.DurationInSeconds, new Dictionary<string, Track>());
                }

                if (!this.tracksByDurationAndAlbumName[track.DurationInSeconds].ContainsKey(track.Title))
                {
                    this.tracksByDurationAndAlbumName[track.DurationInSeconds].Add(track.Title, track);
                }
                return;
            }

            if (!this.tracksByAlbumNameAndTrackTitle[album].ContainsKey(track.Title))
            {
                this.tracksByAlbumNameAndTrackTitle[album].Add(track.Title, track);
                this.allTracks.Add(track);
            }

            if (!this.tracksByArtistNameAndAlbumName.ContainsKey(track.Artist))
            {
                this.tracksByArtistNameAndAlbumName.Add(track.Artist, new Dictionary<string, Dictionary<string, Track>>());
            }

            if (!this.tracksByArtistNameAndAlbumName[track.Artist].ContainsKey(album))
            {
                this.tracksByArtistNameAndAlbumName[track.Artist].Add(album, new Dictionary<string, Track>());
            }

            if (!this.tracksByArtistNameAndAlbumName[track.Artist][album].ContainsKey(track.Title))
            {
                this.tracksByArtistNameAndAlbumName[track.Artist][album].Add(track.Title, track);
            }

            if (!this.tracksByDurationAndAlbumName.ContainsKey(track.DurationInSeconds))
            {
                this.tracksByDurationAndAlbumName.Add(track.DurationInSeconds, new Dictionary<string, Track>());
            }

            if (!this.tracksByDurationAndAlbumName[track.DurationInSeconds].ContainsKey(track.Title))
            {
                this.tracksByDurationAndAlbumName[track.DurationInSeconds].Add(track.Title, track);
            }
        }

        public bool Contains(Track track) => this.allTracks.Contains(track);

        public IEnumerable<Track> GetAlbum(string albumName)
        {
            if (!this.tracksByAlbumNameAndTrackTitle.ContainsKey(albumName))
            {
                throw new ArgumentException();
            }

            return this.tracksByAlbumNameAndTrackTitle[albumName]
                .Select(kvp => kvp.Value)
                .OrderByDescending(t => t.Plays);
        }

        public Dictionary<string, List<Track>> GetDiscography(string artistName)
        {
            if (!this.tracksByArtistNameAndAlbumName.ContainsKey(artistName) || this.tracksByArtistNameAndAlbumName[artistName].Sum(a => a.Value.Count) == 0)
            {
                throw new ArgumentException();
            }

            return this.tracksByArtistNameAndAlbumName
                .Where(kvp => kvp.Key == artistName)
                .SelectMany(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key , kvp => kvp.Value
                    .Select(t => t.Value)
                    .ToList());
        }

        public Track GetTrack(string title, string albumName)
        {
            if (!this.tracksByAlbumNameAndTrackTitle.ContainsKey(albumName))
            {
                throw new ArgumentException();
            }

            if (!this.tracksByAlbumNameAndTrackTitle[albumName].ContainsKey(title))
            {
                throw new ArgumentException();
            }

            return this.tracksByAlbumNameAndTrackTitle[albumName][title];
        }

        public IEnumerable<Track> GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(int lowerBound, int upperBound)
        {
            var filteredTracks = this.tracksByDurationAndAlbumName
                .Where(kvp => kvp.Key >= lowerBound && kvp.Key <= upperBound)
                .SelectMany(kvp => kvp.Value.Values);

            return filteredTracks.OrderBy(t => t.DurationInSeconds)
                .ThenByDescending(t => t.Plays);
        }


        public IEnumerable<Track> GetTracksOrderedByAlbumNameThenByPlaysDescendingThenByDurationDescending()
        {
            return this.tracksByAlbumNameAndTrackTitle
                .OrderBy(kvp => kvp.Key)
                .SelectMany(kvp => kvp.Value.Values)
                .OrderByDescending(t => t.Plays)
                .ThenByDescending(t => t.DurationInSeconds);
        }

        public Track Play()
        {
            if (this.listeningQueue.Count == 0)
            {
                throw new ArgumentException();
            }

            Track trackToListen = this.listeningQueue.First!.Value;
            this.listeningQueue.RemoveFirst();
            this.listeningQueueNodes.Remove(trackToListen);

            trackToListen.Plays++;
            return trackToListen;
        }

        public void RemoveTrack(string trackTitle, string albumName)
        {
            Track track = this.GetTrack(trackTitle, albumName);

            this.tracksByAlbumNameAndTrackTitle[albumName].Remove(track.Title);

            this.tracksByArtistNameAndAlbumName[track.Artist][albumName].Remove(track.Title);

            this.tracksByDurationAndAlbumName[track.DurationInSeconds].Remove(track.Title);

            this.allTracks.Remove(track);

            if (listeningQueueNodes.TryGetValue(track, out var node))
            {
                this.listeningQueue.Remove(node);
                this.listeningQueueNodes.Remove(track);
            }
        }
    }
}
