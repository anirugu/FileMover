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
