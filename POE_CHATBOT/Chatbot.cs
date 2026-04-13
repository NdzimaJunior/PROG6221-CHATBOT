

public class Chatbot
{
    private User user;
    private AudioPlayer audio;

    private Random rand = new Random();
    private string lastTopic = "";

    public Chatbot()
    {
        user = new User();
        audio = new AudioPlayer();
    }

    public void Start()
    {
        Console.Title = "Cyber Sentinel AI";

        ShowASCII();
        TypeText("Booting system...", ConsoleColor.DarkGray);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nEnter your name: ");
        user.Name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(user.Name)) user.Name = "User";

        TypeText($"\nWelcome, {user.Name} 🔐", ConsoleColor.Green);

        // 🔊 SAME CALL, just moved
        audio.PlayAudio();

        RunMenu();
    }

    private void RunMenu()
    {
        while (true)
        {
            DrawBox("MAIN MENU");

            TypeText("1 → Topics 📚", ConsoleColor.Magenta);
            TypeText("2 → Tips 💡", ConsoleColor.Magenta);
            TypeText("3 → Help ❓", ConsoleColor.Blue);
            TypeText("4 → Exit 🚪", ConsoleColor.Red);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n{user.Name}, choose → ");
            string choice = Console.ReadLine()?.ToLower() ?? "";

            if (choice == "1") Topics();
            else if (choice == "2") Tips();
            else if (choice == "3") Help();
            else if (choice == "4")
            {
                DrawBox("EXIT");
                TypeText($"Goodbye, {user.Name} 🔐", ConsoleColor.Red);
                break;
            }
            else
            {
                TypeText($"{user.Name}, invalid option.", ConsoleColor.DarkRed);
            }
        }
    }

    private void Topics()
    {
        DrawBox("TOPICS");
        Console.WriteLine("• phishing\n• passwords\n• malware\n• wifi");

        while (true)
        {
            Console.Write("\nAsk / more / back / exit → ");
            string input = Console.ReadLine()?.ToLower() ?? "";

            if (input == "back") break;
            if (input == "exit") Environment.Exit(0);

            if (input == "more" && lastTopic != "")
            {
                TypeText($"{user.Name}, here's more about {lastTopic} — always stay updated, threats evolve.", ConsoleColor.DarkCyan);
                continue;
            }

            if (input.Contains("phishing"))
            {
                lastTopic = "phishing";
                TypeText($"{user.Name}, phishing tricks you into trusting fake messages.", ConsoleColor.Green);
            }
            else if (input.Contains("password"))
            {
                lastTopic = "passwords";
                TypeText($"{user.Name}, use strong, unique passwords.", ConsoleColor.Green);
            }
            else
            {
                TypeText($"{user.Name}, try a listed topic.", ConsoleColor.DarkYellow);
            }
        }
    }

    private void Tips()
    {
        DrawBox("TIPS");
        Console.WriteLine("• 2fa\n• updates\n• backups");

        while (true)
        {
            Console.Write("\nAsk / more / back / exit → ");
            string input = Console.ReadLine()?.ToLower() ?? "";

            if (input == "back") break;
            if (input == "exit") Environment.Exit(0);

            if (input.Contains("2fa"))
                TypeText($"{user.Name}, 2FA adds extra protection.", ConsoleColor.Green);
            else
                TypeText($"{user.Name}, try a listed tip.", ConsoleColor.DarkYellow);
        }
    }

    private void Help()
    {
        DrawBox("HELP");
        TypeText("Use menu → ask → type back/exit anytime", ConsoleColor.Blue);
    }

    // ===== YOUR ORIGINAL METHODS (UNCHANGED) =====

    private void TypeText(string text, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(12);
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    private void DrawBox(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n╔════════════════════════════════════╗");
        Console.WriteLine($"║ {title.PadRight(34)} ║");
        Console.WriteLine("╚════════════════════════════════════╝");
        Console.ResetColor();
    }

    private void ShowASCII()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
 ██████╗██╗   ██╗██████╗ ███████╗██████╗ 
██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝
██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
╚██████╗   ██║   ██████╔╝███████╗██║  ██║
 ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝

   🔐 CYBER SENTINEL AI 🤖
");
        Console.ResetColor();
    }
}