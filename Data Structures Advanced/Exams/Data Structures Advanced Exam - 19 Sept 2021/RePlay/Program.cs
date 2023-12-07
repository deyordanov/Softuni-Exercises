using System;

namespace Exam.RePlay
{
    class Program
    {
        static void Main(string[] args)
        {
            RePlayer rePlayer = new RePlayer();

            Track track = new Track("asd", "bsd", "csd", 100, 1);
            Track track2 = new Track("dsd", "esd", "csd", 200, 2);
            Track track3 = new Track("hsd", "isd", "jsd", 300, 5);
            Track track4 = new Track("ksd", "lsd", "msd", 500, 4);
            Track track5 = new Track("nsd", "osd", "csd", 400, 3);

            rePlayer.AddTrack(track, "randomAlbum");
            rePlayer.AddTrack(track2, "bandomAlbum");
            rePlayer.AddTrack(track3, "aandomAlbum2");
            rePlayer.AddTrack(track4, "aandomAlbum2");
            rePlayer.AddTrack(track5, "aandomAlbum2");

            var a = rePlayer.GetTracksInDurationRangeOrderedByDurationThenByPlaysDescending(2, 5);

            ;
        }
    }
}
