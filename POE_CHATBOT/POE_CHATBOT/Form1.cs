using System;
using System.Drawing;
using System.Windows.Forms;

namespace POE_CHATBOT
{
    public partial class Form1 : Form
    {
        private Chatbot _chatbot;

        public Form1()
        {
            InitializeComponent();
            _chatbot = new Chatbot();
        }

        // ── Runs when the form loads ───────────────────────────
        private void Form1_Load(object sender, EventArgs e)
        {
            // Show ASCII art in the header label
            lblAscii.Text = _chatbot.GetAsciiArt();

            // Show the greeting and ask for name
            string greeting = _chatbot.GetGreeting();
            AppendBotMessage(greeting);
        }

        // ── Send button click ──────────────────────────────────
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        // ── Press Enter to send ────────────────────────────────
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // stops the 'ding' sound
                SendMessage();
            }
        }

        // ── Core send logic ────────────────────────────────────
        private void SendMessage()
        {
            string userInput = txtInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
                return;

            AppendUserMessage(userInput);
            txtInput.Clear();

            string botResponse = _chatbot.ProcessInput(userInput);
            AppendBotMessage(botResponse);
        }

        // ── Append user message to chat display ────────────────
        private void AppendUserMessage(string message)
        {
            txtChat.SelectionColor = Color.Cyan;
            txtChat.AppendText($"You: {message}\n\n");
            ScrollToBottom();
        }

        // ── Append bot message to chat display ─────────────────
        private void AppendBotMessage(string message)
        {
            txtChat.SelectionColor = Color.LimeGreen;
            txtChat.AppendText($"🤖 Sentinel: {message}\n\n");
            txtChat.SelectionColor = Color.White;
            ScrollToBottom();
        }

        // ── Keep chat scrolled to latest message ───────────────
        private void ScrollToBottom()
        {
            txtChat.SelectionStart = txtChat.Text.Length;
            txtChat.ScrollToCaret();
        }
    }
}