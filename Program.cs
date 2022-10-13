using Newtonsoft.Json;

namespace FileMover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var settingsFile = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "settings.json");
            string text = System.IO.File.ReadAllText(settingsFile);
            Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(text);

            var directories = System.IO.Directory.GetDirectories(obj.source);
            foreach (var dir in directories)
            {
                bool excluded = obj.exclude.Any(x => dir.EndsWith(x));
                if (!excluded)
                {
                    var name = System.IO.Path.GetFileName(dir);
                    string newPath = System.IO.Path.Combine(obj.target, name);
                    System.IO.Directory.Move(dir, newPath);
                }
            }

            Console.WriteLine("Hello, World!");
        }
    }
}


public class Rootobject
{
    public string source { get; set; }
    public string target { get; set; }
    public string[] exclude { get; set; }
}
