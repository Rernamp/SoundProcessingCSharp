using System;
using System.Threading;
using NWaves;
using NWaves.Audio;
using NWaves.Signals;
using SoundProcessing;

public class Program {
    public static void Main(string[] args) {
        if (args.Count() != 2) {
            Console.WriteLine("Invalid number arguments");
        }
        string soundFilePath = args[0];
        WaveFile soundFile = Utils.LoadFile(soundFilePath);

        string noiseFilePath = args[1];
        WaveFile noiseFile = Utils.LoadFile(noiseFilePath);

        Console.WriteLine($"Load file {soundFilePath}");
        Utils.PrintFileInfo(soundFile);

        Console.WriteLine("");

        Console.WriteLine($"Load file {noiseFilePath}");
        Utils.PrintFileInfo(noiseFile);


        DiscreteSignal sound = soundFile[0];
        DiscreteSignal noise = noiseFile[0];

        if (noise.Length > sound.Length) {
            noise = noise.First(sound.Length);
        } else {
            sound = sound.First(noise.Length);
        }

        ScottPlot.Plot soundPlot = new();
        soundPlot.Add.Signal(sound.Samples, 1 / (float)sound.SamplingRate);

        ScottPlot.Plot noisePlot = new();
        noisePlot.Add.Signal(noise.Samples, 1 / (float)noise.SamplingRate);

        new Thread(() => ScottPlot.WinForms.FormsPlotViewer.Launch(soundPlot, "Sound signal")).Start();
        new Thread(() => ScottPlot.WinForms.FormsPlotViewer.Launch(noisePlot, "Noise signal")).Start();

        DiscreteSignal soundWithNoise = sound + noise;

        ScottPlot.Plot soundWithNoisePlot = new();
        soundWithNoisePlot.Add.Signal(soundWithNoise.Samples, 1 / (float)soundWithNoise.SamplingRate);

        new Thread(() => ScottPlot.WinForms.FormsPlotViewer.Launch(soundWithNoisePlot, "Sound with noise")).Start();

    }
}