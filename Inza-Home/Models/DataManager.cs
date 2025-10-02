using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Inza_Home.Models
{
    public class DataManager
    {
        private static readonly string collectionsPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Collections2.txt");

        private const string ColumnSperator = "##col##";
        public static List<CollectionModel> GetCollections()
        {
            var list = new List<CollectionModel>();

            if (!File.Exists(collectionsPath))
                return list;

            var lines = File.ReadAllLines(collectionsPath).Skip(1);

            foreach (var line in lines)
            {

                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(ColumnSperator);

                if (parts.Length < 6) continue;

                var collection = new CollectionModel
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Description = parts[2],
                    CoverImage = parts[3],
                    Images = parts[4].Split('|', StringSplitOptions.RemoveEmptyEntries).ToList(),
                    Order = int.Parse(parts[5]),
                    Show = bool.Parse(parts[6]).Equals(true)
                };
                list.Add(collection);
            }

            return list.OrderBy(c => c.Order).ToList();
        }

        public static List<HighlightCollectionModel> GetHighlights()
        {
            var list = new List<HighlightCollectionModel>();
            var highlightsPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "highlightCollections.txt");

            if (!File.Exists(highlightsPath))
                return list;
            var lines = File.ReadAllLines(highlightsPath).Skip(1);
            foreach (var line in lines) 
            {
            if(string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(ColumnSperator);
                if (parts.Length < 6) continue;
                var highlight = new HighlightCollectionModel
                {
                    Id = int.Parse(parts[0]),
                    Title = parts[1],
                    HighlightDescription = parts[2],
                    ImageUrl = parts[3],
                    Order = int.Parse(parts[4]),
                    Show = bool.Parse(parts[5]).Equals(true)
                };
                list.Add(highlight);
            }
            return list.Where(h => h.Show).OrderBy(h => h.Order).ToList();
        }

    }
}
