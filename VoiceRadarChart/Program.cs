using ScottPlot;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        string? inputFile = null;
        int frame = -1;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-i" && i + 1 < args.Length)
                inputFile = args[i + 1];
            if (args[i] == "-f" && i + 1 < args.Length)
                frame = int.Parse(args[i + 1]);
        }

        if (inputFile == null || frame < 0)
        {
            Console.WriteLine("Usage: VoiceRadar -i <csv> -f <frame>");
            return;
        }

        var records = Loader.LoadCsv(inputFile);

        if (frame >= records.Count)
        {
            Console.WriteLine($"Frame {frame} not found.");
            return;
        }

        var rec = records[frame];
        double[] values = Formant.ExtractFormants(rec);
        string[] labels = { "F1", "F2", "F3", "F4", "F5" };

        var plt = new Plot();
        RadarChart.DrawRadarChart(plt, labels, values);

        string output = $"formants_frame_{frame}.png";
        plt.SavePng(output, 600, 600);

        Console.WriteLine($"Saved: {output}");
    }
}
