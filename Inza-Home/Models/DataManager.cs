using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Inza_Home.Models
{
    public class DataManager
    {
        private static readonly string collectionsPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "collections.txt");

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
                    Images = parts[4].Split('|',StringSplitOptions.RemoveEmptyEntries).ToList(),
                    Order = int.Parse(parts[5])
                };
                list.Add(collection);
            }

            return list.OrderBy(c => c.Order).ToList();
        }
    }
}
