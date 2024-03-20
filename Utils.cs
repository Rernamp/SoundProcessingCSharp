using NWaves;
using NWaves.Audio;
using ScottPlot.Plottables;

namespace SoundProcessing {
    internal class Utils {
        public static WaveFile LoadFile(string filePath) {
            WaveFile waveFile;

            if (System.IO.Path.GetExtension(filePath) != ".wav") {
                throw new ArgumentException($"Don`t supported extension file: {filePath}. Supported only wav file");
            }
            using (var stream = new FileStream(filePath, FileMode.Open)) {
                waveFile = new WaveFile(stream);
            }

            return waveFile;
        }

        public static void PrintFileInfo(WaveFile file) {
            Console.WriteLine($"ChannelCount: {file.WaveFmt.ChannelCount}");
            Console.WriteLine($"SamplingRate : {file.WaveFmt.SamplingRate}");
            Console.WriteLine($"SampleCount: {file.Signals[0].Length}");
        }
    }
}
