namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var result = context
                .Producers
                .Where(p => p.Id == producerId)
                .ToArray()
                .Select(p => new
                {
                    Albums = p.Albums.Select(a => new
                        {
                            a.Name,
                            ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ProducerName = a.Producer.Name,
                            Songs = a.Songs.Select(s => new
                                {
                                    SongName = s.Name,
                                    Price = s.Price,
                                    SongWriterName = s.Writer.Name
                                })
                                .OrderByDescending(s => s.SongName)
                                .ThenBy(s => s.SongWriterName)
                                .ToArray(),
                            TotalAlbumPrice = a.Price
                        })
                        .OrderByDescending(a => a.TotalAlbumPrice)
                }).ToArray();

            foreach (var producer in result)
            {
                foreach (var album in producer.Albums)
                {
                    sb.AppendLine($"-AlbumName: {album.Name}");
                    sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                    sb.AppendLine($"-ProducerName: {album.ProducerName}");
                    sb.AppendLine($"-Songs:");
                    int rank = 1;
                    foreach (var song in album.Songs)
                    {
                        sb.AppendLine($"---#{rank++}");
                        sb.AppendLine($"---SongName: {song.SongName}");
                        sb.AppendLine($"---Price: {song.Price:F2}");
                        sb.AppendLine($"---Writer: {song.SongWriterName}");
                    }

                    sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:F2}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var result = context
                .Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Name = s.Name,
                    Performers = s.SongPerformers.Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}")
                        .OrderBy(p => p)
                        .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName);

            int rank = 1;
            foreach (var song in result)
            {
                sb.AppendLine($"-Song #{rank++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                foreach (var performer in song.Performers)
                {
                    sb.AppendLine($"---Performer: {performer}");
                }
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}