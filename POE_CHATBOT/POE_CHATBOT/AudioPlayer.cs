using System;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;

public class AudioPlayer
{
    // IMPORTS Windows system functions to control volume
    [DllImport("winmm.dll")]
    static extern uint waveOutGetVolume(IntPtr hwo, out uint dwVolume);

    [DllImport("winmm.dll")]
    static extern uint waveOutSetVolume(IntPtr hwo, uint dwVolume);

    public void PlayAudio()
    {
        try
        {
            // AUDIO FILE PATH (location of greeting sound)
            string path = Path.Combine(AppContext.BaseDirectory,
                "C:\\Users\\mthem\\source\\repos\\POE_CHATBOT\\POE_CHATBOT\\Audio\\greeting.wav.wav");

            // CHECK IF AUDIO FILE EXISTS (error handling)
            if (!File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n⚠ Audio file NOT found!");
                Console.ResetColor();
                return;
            }

            // USER FEEDBACK (shows audio is playing)
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n🔊 Playing greeting...");
            Console.ResetColor();

            uint previousVolume = 0;

            try
            {
                // SAVE CURRENT SYSTEM VOLUME
                waveOutGetVolume(IntPtr.Zero, out previousVolume);

                // SET MAX VOLUME for clear audio playback
                uint maxVolume = 0xFFFFu | (0xFFFFu << 16);
                waveOutSetVolume(IntPtr.Zero, maxVolume);
            }
            catch { }

            // PLAY AUDIO FILE (blocking playback)
            using (SoundPlayer player = new SoundPlayer(path))
            {
                player.Load();
                player.PlaySync();
            }

            try
            {
                // RESTORE ORIGINAL VOLUME AFTER PLAYBACK
                waveOutSetVolume(IntPtr.Zero, previousVolume);
            }
            catch { }
        }
        catch (Exception ex)
        {
            // ERROR HANDLING (prevents crash if audio fails)
            Console.WriteLine("Audio error: " + ex.Message);
        }
    }
}