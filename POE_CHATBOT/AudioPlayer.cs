using System;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;

public class AudioPlayer
{
    [DllImport("winmm.dll")]
    static extern uint waveOutGetVolume(IntPtr hwo, out uint dwVolume);

    [DllImport("winmm.dll")]
    static extern uint waveOutSetVolume(IntPtr hwo, uint dwVolume);

    public void PlayAudio()
    {
        try
        {
            string path = Path.Combine(AppContext.BaseDirectory,
                "C:\\Users\\mthem\\source\\repos\\POE_CHATBOT\\POE_CHATBOT\\Audio\\greeting.wav.wav");

            if (!File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n⚠ Audio file NOT found!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n🔊 Playing greeting...");
            Console.ResetColor();

            uint previousVolume = 0;

            try
            {
                waveOutGetVolume(IntPtr.Zero, out previousVolume);
                uint maxVolume = 0xFFFFu | (0xFFFFu << 16);
                waveOutSetVolume(IntPtr.Zero, maxVolume);
            }
            catch { }

            using (SoundPlayer player = new SoundPlayer(path))
            {
                player.Load();
                player.PlaySync();
            }

            try
            {
                waveOutSetVolume(IntPtr.Zero, previousVolume);
            }
            catch { }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Audio error: " + ex.Message);
        }
    }
}