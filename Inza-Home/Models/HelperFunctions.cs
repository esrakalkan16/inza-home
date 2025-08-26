namespace Inza_Home.Models
{
    public class HelperFunctions
    {

        public static string Translate(string TEXT)
        {
            try
            {
                var LANG = SessionHelper.GetSessionValue("LANG") ?? "TR";
                if (LANG == "EN")
                {
                    var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Languages", "TRANSLATE_EN.txt");
                    if (File.Exists(FilePath))
                    {
                        var lines = File.ReadAllLines(FilePath,System.Text.Encoding.UTF8);
                        foreach (var line in lines)
                        {
                            var parts = line.Split('=');
                            if (parts.Length == 2 && parts[0].Trim() == TEXT)
                            {
                                return parts[1].Trim();
                            }
                        }
                    }
                }
                return TEXT;
            }
            catch
            {
                return TEXT;
            }
            
        }
    }
}
