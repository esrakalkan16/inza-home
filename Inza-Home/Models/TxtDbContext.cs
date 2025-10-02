using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Inza_Home.Models
{
    public class TxtDbContext
    {
        private readonly string _dataDirectory;
        public const string Separator = "##col##";

        public TxtDbContext(string dataDirectory)
        {
            _dataDirectory = dataDirectory;
            if (!Directory.Exists(_dataDirectory))
                Directory.CreateDirectory(_dataDirectory);
        }
        private string GetFilePath<T>()
        {
            return Path.Combine(_dataDirectory, typeof(T).Name + "s.txt");
        }
        public void Init<T>()
        {
            var filePath = GetFilePath<T>();
            if (!File.Exists(filePath))
            {
                var header = string.Join(Separator, typeof(T).GetProperties().Select(p => p.Name));
                File.WriteAllLines(filePath, new[] { header });
            }
            else
            {
                var headerLine = File.ReadLines(filePath).FirstOrDefault();
                var props = typeof(T).GetProperties().Select(p => p.Name).ToList();
                if (headerLine == null || headerLine.Split(Separator).Length != props.Count)
                {
                    var header = string.Join(Separator, props);
                    var lines = File.ReadAllLines(filePath).ToList();
                    if (lines.Count == 0)
                        lines.Add(header);
                    else
                        lines[0] = header;
                    File.WriteAllLines(filePath, lines);
                }
            }
        }
        public List<T> GetAll<T>() where T : new()
        {
            var filePath = GetFilePath<T>();
            if (!File.Exists(filePath)) return new List<T>();

            var lines = File.ReadAllLines(filePath).ToList();
            if (lines.Count < 2) return new List<T>();

            // İlk satır -> header
            var headers = lines[0].Split(Separator);
            var props = typeof(T).GetProperties()
                                 .ToDictionary(p => p.Name, p => p);

            var list = new List<T>();

            foreach (var line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(Separator);

                var obj = new T();

                for (int i = 0; i < headers.Length && i < parts.Length; i++)
                {
                    var columnName = headers[i];
                    if (!props.TryGetValue(columnName, out var prop)) continue;

                    var raw = parts[i];
                    if (string.IsNullOrWhiteSpace(raw)) continue;

                    object? value = null;

                    if (prop.PropertyType == typeof(int))
                    {
                        if (int.TryParse(raw, out int intVal))
                            value = intVal;
                    }
                    else if (prop.PropertyType == typeof(bool))
                    {
                        if (bool.TryParse(raw, out bool boolVal))
                            value = boolVal;
                    }
                    else
                    {
                        value = raw;
                    }

                    if (value != null)
                        prop.SetValue(obj, value);
                }

                list.Add(obj);
            }

            return list;
        }

        public void Add<T>(T entity)
        {
            var filePath = GetFilePath<T>();
            var props = typeof(T).GetProperties();

            var line = string.Join(Separator, props.Select(p => p.GetValue(entity)?.ToString() ?? ""));
            File.AppendAllLines(filePath, new[] { line });
        }

        public void Update<T>(T entity)
        {
            var filePath = GetFilePath<T>();
            var props = typeof(T).GetProperties();
            var keyProp = props.FirstOrDefault(p => p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase));
            if (keyProp == null) throw new Exception("No Id property found for update operation.");

            var id = keyProp.GetValue(entity)?.ToString();
            if (id == null) return;

            var lines = File.ReadAllLines(filePath).ToList();
            for (int i = 1; i < lines.Count; i++)
            {
                var parts = lines[i].Split(Separator);
                if (parts[0] == id)
                {
                    lines[i] = string.Join(Separator, props.Select(p => p.GetValue(entity)?.ToString() ?? ""));
                    break;
                }
            }
            File.WriteAllLines(filePath, lines);
        }

        public void Delete<T>(Func<T, bool> predicate) where T : new()
        {
            var filePath = GetFilePath<T>();
            var all = GetAll<T>();
            var toKeep = all.Where(e => !predicate(e)).ToList();

            var props = typeof(T).GetProperties();
            var header = string.Join(Separator, props.Select(p => p.Name));

            var lines = new List<string> { header };
            lines.AddRange(toKeep.Select(obj => string.Join(Separator,props.Select(p=> p.GetValue(obj)?.ToString() ?? ""))));
            
            File.WriteAllLines(filePath, lines);
        }

    }
}
