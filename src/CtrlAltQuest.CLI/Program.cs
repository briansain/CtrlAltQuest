using CommandLine;
using CtrlAltQuest.CLI;

Parser.Default.ParseArguments<Options>(args)
.WithParsed(o =>
{
    if (o.LoadData)
    {
        Console.WriteLine($"Starting to load data from {o.FileLocation}");
        var loadData = new LoadData(o.FileLocation);
        loadData.Start().Wait();
    }
    else
    {
        Console.WriteLine($"Current Arguments: -v {o.LoadData}");
        Console.WriteLine("Quick Start Example!");
    }
    Console.WriteLine("END");
});

public class Options
{
    [Option('l', "loadData", Required = false, HelpText = "Loads Data into Redis")]
    public bool LoadData { get; set; }
    [Option("fileLocation")]
    public string FileLocation { get; set; } = string.Empty;
}
