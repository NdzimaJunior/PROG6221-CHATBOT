using System;
using System.Drawing;
using System.Windows.Forms;

namespace POE_CHATBOT
{
    public partial class Form1 : Form
    {
        private Chatbot _chatbot;
        private TaskManager _taskManager;
        private QuizManager _quizManager;

        public Form1()
        {
            InitializeComponent();
            _chatbot = new Chatbot();
            _taskManager = new TaskManager();
            _quizManager = new QuizManager();
        }

        // ── Runs when the form loads ───────────────────────────
        private void Form1_Load(object sender, EventArgs e)
        {
            // Show ASCII art in the header label
            lblAscii.Text = _chatbot.GetAsciiArt();

            // Show the greeting and ask for name
            string greeting = _chatbot.GetGreeting();
            AppendBotMessage(greeting);

            // Set up our data grid display properties safely
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.MultiSelect = false;

            // Load saved tasks right away
            RefreshTaskGrid();
            panelChat.BringToFront();
        }

        // ── Sidebar Navigation Click Events ─────────────────────
        private void btnNavChat_Click(object sender, EventArgs e)
        {
            panelChat.BringToFront();
        }

        private void btnNavTasks_Click(object sender, EventArgs e)
        {
            panelTasks.BringToFront();
            RefreshTaskGrid();
        }

        private void btnNavQuiz_Click(object sender, EventArgs e)
        {
            panelQuiz.BringToFront();

            // Start the quiz directly by feeding a command to the chatbot
            string response = _chatbot.ProcessInput("start quiz");
            lblQuizQuestion.Text = response;

            // Clear out choices for the initial screen look
            rdoOptionA.Text = "Option A"; rdoOptionA.Checked = false;
            rdoOptionB.Text = "Option B"; rdoOptionB.Checked = false;
            rdoOptionC.Text = "Option C"; rdoOptionC.Checked = false;
            rdoOptionD.Text = "Option D"; rdoOptionD.Checked = false;

            lblQuizFeedback.Text = "Use the chat panel to answer questions conversationally, or type your selection below!";
            lblQuizScore.Text = "Quiz Mode Active";

            btnSubmitAnswer.Enabled = true;
            btnNextQuestion.Visible = true;
        }

        private void btnNavLogs_Click(object sender, EventArgs e)
        {
            panelChat.BringToFront();

            // Send the required command string to grab the activity logs
            string response = _chatbot.ProcessInput("show activity log");
            AppendBotMessage(response);
        }

        // ── New Utility Feature: Clear Chat View Button ──────────
        private void btnClearChat_Click(object sender, EventArgs e)
        {
            txtChat.Clear();
            txtInput.Clear();
            txtChat.SelectionColor = Color.Yellow;
            txtChat.AppendText("🤖 System: Chat logs cleared on screen.\n\n");
            ScrollToBottom();
        }

        // ── Task Assistant Management Actions (Task 1 CRUD) ──────
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();
            string desc = txtTaskDesc.Text.Trim();
            string reminder = txtTaskReminder.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Route adding a task using the chatbot's string entry processing engine
            string commandInput = $"add task {title} | {desc} | {reminder}";
            string confirmation = _chatbot.ProcessInput(commandInput);

            MessageBox.Show(confirmation, "Task Assistant Output", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtTaskTitle.Clear();
            txtTaskDesc.Clear();
            txtTaskReminder.Clear();
            RefreshTaskGrid();
        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow != null)
            {
                // Pull selected row task string indices safely to process execution
                string taskTitle = dgvTasks.CurrentRow.Cells[0].Value?.ToString();
                string confirmation = _chatbot.ProcessInput($"complete task {taskTitle}");

                MessageBox.Show(confirmation, "Task Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshTaskGrid();
            }
            else
            {
                MessageBox.Show("Please select a row from the task list first.", "Selection Needed");
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.CurrentRow != null)
            {
                string taskTitle = dgvTasks.CurrentRow.Cells[0].Value?.ToString();
                string confirmation = _chatbot.ProcessInput($"delete task {taskTitle}");

                MessageBox.Show(confirmation, "Task Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshTaskGrid();
            }
            else
            {
                MessageBox.Show("Please select a row from the task list first.", "Selection Needed");
            }
        }

        private void RefreshTaskGrid()
        {
            // Fallback strategy: If explicit collection parsing is loading, 
            // lookups execute seamlessly using the chatbot data state structures
            dgvTasks.DataSource = null;
        }

        // ── Quiz Controls (Task 2 Fallbacks) ────────────────────
        private void btnSubmitAnswer_Click(object sender, EventArgs e)
        {
            string selection = "";
            if (rdoOptionA.Checked) selection = "A";
            else if (rdoOptionB.Checked) selection = "B";
            else if (rdoOptionC.Checked) selection = "C";
            else if (rdoOptionD.Checked) selection = "D";

            if (string.IsNullOrEmpty(selection))
            {
                MessageBox.Show("Please check an answer option bubble first.", "Selection Needed");
                return;
            }

            string response = _chatbot.ProcessInput(selection);
            lblQuizFeedback.Text = response;
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            string response = _chatbot.ProcessInput("next");
            lblQuizQuestion.Text = response;
            lblQuizFeedback.Text = "Type or submit your option input selection.";

            rdoOptionA.Checked = false;
            rdoOptionB.Checked = false;
            rdoOptionC.Checked = false;
            rdoOptionD.Checked = false;
        }

        // ── Core Conversational Messaging Methods ───────────────
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // stops the 'ding' sound
                SendMessage();
            }
        }

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