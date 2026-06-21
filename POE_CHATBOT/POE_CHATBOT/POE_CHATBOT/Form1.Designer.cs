namespace POE_CHATBOT
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // ── Layout Panels & Navigation Components ──────────────
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelContentContainer;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.Panel panelTasks;
        private System.Windows.Forms.Panel panelQuiz;

        // ── Navigation Control Buttons ─────────────────────────
        private System.Windows.Forms.Button btnNavChat;
        private System.Windows.Forms.Button btnNavTasks;
        private System.Windows.Forms.Button btnNavQuiz;
        private System.Windows.Forms.Button btnNavLogs;
        private System.Windows.Forms.Button btnClearChat;
        private System.Windows.Forms.Label lblAppTitle;

        // ── Core Chat Interface Controls ───────────────────────
        private System.Windows.Forms.Label lblAscii;
        private System.Windows.Forms.RichTextBox txtChat;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;

        // ── Task Assistant Controls (Task 1) ───────────────────
        private System.Windows.Forms.Label lblTaskTitle;
        private System.Windows.Forms.TextBox txtTaskTitle;
        private System.Windows.Forms.Label lblTaskDesc;
        private System.Windows.Forms.TextBox txtTaskDesc;
        private System.Windows.Forms.Label lblTaskReminder;
        private System.Windows.Forms.TextBox txtTaskReminder;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Button btnMarkComplete;
        private System.Windows.Forms.Button btnDeleteTask;

        // ── Quiz Game Controls (Task 2) ────────────────────────
        private System.Windows.Forms.Label lblQuizQuestion;
        private System.Windows.Forms.RadioButton rdoOptionA;
        private System.Windows.Forms.RadioButton rdoOptionB;
        private System.Windows.Forms.RadioButton rdoOptionC;
        private System.Windows.Forms.RadioButton rdoOptionD;
        private System.Windows.Forms.Button btnSubmitAnswer;
        private System.Windows.Forms.Label lblQuizFeedback;
        private System.Windows.Forms.Button btnNextQuestion;
        private System.Windows.Forms.Label lblQuizScore;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.btnNavChat = new System.Windows.Forms.Button();
            this.btnNavTasks = new System.Windows.Forms.Button();
            this.btnNavQuiz = new System.Windows.Forms.Button();
            this.btnNavLogs = new System.Windows.Forms.Button();
            this.btnClearChat = new System.Windows.Forms.Button();

            this.panelContentContainer = new System.Windows.Forms.Panel();
            this.panelChat = new System.Windows.Forms.Panel();
            this.panelTasks = new System.Windows.Forms.Panel();
            this.panelQuiz = new System.Windows.Forms.Panel();

            // Chat Setup
            this.lblAscii = new System.Windows.Forms.Label();
            this.txtChat = new System.Windows.Forms.RichTextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();

            // Task Setup
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.txtTaskTitle = new System.Windows.Forms.TextBox();
            this.lblTaskDesc = new System.Windows.Forms.Label();
            this.txtTaskDesc = new System.Windows.Forms.TextBox();
            this.lblTaskReminder = new System.Windows.Forms.Label();
            this.txtTaskReminder = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.btnMarkComplete = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();

            // Quiz Setup
            this.lblQuizQuestion = new System.Windows.Forms.Label();
            this.rdoOptionA = new System.Windows.Forms.RadioButton();
            this.rdoOptionB = new System.Windows.Forms.RadioButton();
            this.rdoOptionC = new System.Windows.Forms.RadioButton();
            this.rdoOptionD = new System.Windows.Forms.RadioButton();
            this.btnSubmitAnswer = new System.Windows.Forms.Button();
            this.lblQuizFeedback = new System.Windows.Forms.Label();
            this.btnNextQuestion = new System.Windows.Forms.Button();
            this.lblQuizScore = new System.Windows.Forms.Label();

            this.panelSidebar.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.panelChat.SuspendLayout();
            this.panelTasks.SuspendLayout();
            this.panelQuiz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();

            // ── Main Form Setup ────────────────────────────────────
            this.Text = "Cyber Sentinel AI Dashboard 🔐";
            this.BackColor = System.Drawing.Color.FromArgb(15, 23, 42); // Modern Slate Dark Background [cite: 9]
            this.ForeColor = System.Drawing.Color.White;
            this.Size = new System.Drawing.Size(1020, 720);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Consolas", 10F);
            this.Load += new System.EventHandler(this.Form1_Load);

            // ── Sidebar Container ──────────────────────────────────
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Width = 220;
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.panelSidebar.Controls.Add(this.lblAppTitle);
            this.panelSidebar.Controls.Add(this.btnNavChat);
            this.panelSidebar.Controls.Add(this.btnNavTasks);
            this.panelSidebar.Controls.Add(this.btnNavQuiz);
            this.panelSidebar.Controls.Add(this.btnNavLogs);
            this.panelSidebar.Controls.Add(this.btnClearChat);

            this.lblAppTitle.Location = new System.Drawing.Point(10, 20);
            this.lblAppTitle.Size = new System.Drawing.Size(200, 40);
            this.lblAppTitle.Text = "SENTINEL AI";
            this.lblAppTitle.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnNavChat.Location = new System.Drawing.Point(15, 90);
            this.btnNavChat.Size = new System.Drawing.Size(190, 40);
            this.btnNavChat.Text = "💬 Chat Panel";
            this.btnNavChat.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnNavChat.ForeColor = System.Drawing.Color.White;
            this.btnNavChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavChat.Click += new System.EventHandler(this.btnNavChat_Click);

            this.btnNavTasks.Location = new System.Drawing.Point(15, 145);
            this.btnNavTasks.Size = new System.Drawing.Size(190, 40);
            this.btnNavTasks.Text = "📋 Tasks Manager";
            this.btnNavTasks.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnNavTasks.ForeColor = System.Drawing.Color.White;
            this.btnNavTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTasks.Click += new System.EventHandler(this.btnNavTasks_Click);

            this.btnNavQuiz.Location = new System.Drawing.Point(15, 200);
            this.btnNavQuiz.Size = new System.Drawing.Size(190, 40);
            this.btnNavQuiz.Text = "🎮 Cyber Quiz Game";
            this.btnNavQuiz.BackColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this.btnNavQuiz.ForeColor = System.Drawing.Color.Black;
            this.btnNavQuiz.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavQuiz.Click += new System.EventHandler(this.btnNavQuiz_Click);

            this.btnNavLogs.Location = new System.Drawing.Point(15, 255);
            this.btnNavLogs.Size = new System.Drawing.Size(190, 40);
            this.btnNavLogs.Text = "📜 Activity Logs";
            this.btnNavLogs.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnNavLogs.ForeColor = System.Drawing.Color.White;
            this.btnNavLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLogs.Click += new System.EventHandler(this.btnNavLogs_Click);

            this.btnClearChat.Location = new System.Drawing.Point(15, 600);
            this.btnClearChat.Size = new System.Drawing.Size(190, 40);
            this.btnClearChat.Text = "✨ Clear Screen";
            this.btnClearChat.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnClearChat.ForeColor = System.Drawing.Color.White;
            this.btnClearChat.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearChat.Click += new System.EventHandler(this.btnClearChat_Click);

            // ── Content Container Wrapper ──────────────────────────
            this.panelContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentContainer.Controls.Add(this.panelChat);
            this.panelContentContainer.Controls.Add(this.panelTasks);
            this.panelContentContainer.Controls.Add(this.panelQuiz);

            // ── PANEL A: CHAT STREAM INTERACTION PANEL ──────────────
            this.panelChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChat.Controls.Add(this.lblAscii);
            this.panelChat.Controls.Add(this.txtChat);
            this.panelChat.Controls.Add(this.txtInput);
            this.panelChat.Controls.Add(this.btnSend);

            this.lblAscii.Location = new System.Drawing.Point(15, 10);
            this.lblAscii.Size = new System.Drawing.Size(750, 110);
            this.lblAscii.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblAscii.ForeColor = System.Drawing.Color.Cyan;
            this.lblAscii.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.txtChat.Location = new System.Drawing.Point(15, 130);
            this.txtChat.Size = new System.Drawing.Size(750, 430);
            this.txtChat.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtChat.ForeColor = System.Drawing.Color.White;
            this.txtChat.ReadOnly = true;
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.txtInput.Location = new System.Drawing.Point(15, 580);
            this.txtInput.Size = new System.Drawing.Size(620, 30);
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtInput.ForeColor = System.Drawing.Color.White;
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);

            this.btnSend.Location = new System.Drawing.Point(645, 576);
            this.btnSend.Size = new System.Drawing.Size(120, 35);
            this.btnSend.Text = "SEND 🔐";
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // ── PANEL B: TASK ASSISTANT MANAGEMENT PANEL ───────────
            this.panelTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTasks.Controls.Add(this.lblTaskTitle);
            this.panelTasks.Controls.Add(this.txtTaskTitle);
            this.panelTasks.Controls.Add(this.lblTaskDesc);
            this.panelTasks.Controls.Add(this.txtTaskDesc);
            this.panelTasks.Controls.Add(this.lblTaskReminder);
            this.panelTasks.Controls.Add(this.txtTaskReminder);
            this.panelTasks.Controls.Add(this.btnAddTask);
            this.panelTasks.Controls.Add(this.dgvTasks);
            this.panelTasks.Controls.Add(this.btnMarkComplete);
            this.panelTasks.Controls.Add(this.btnDeleteTask);

            this.lblTaskTitle.Location = new System.Drawing.Point(20, 20); this.lblTaskTitle.Text = "Task Title:"; this.lblTaskTitle.Size = new System.Drawing.Size(120, 25);
            this.txtTaskTitle.Location = new System.Drawing.Point(140, 18); this.txtTaskTitle.Size = new System.Drawing.Size(220, 25); this.txtTaskTitle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59); this.txtTaskTitle.ForeColor = System.Drawing.Color.White;

            this.lblTaskDesc.Location = new System.Drawing.Point(20, 55); this.lblTaskDesc.Text = "Description:"; this.lblTaskDesc.Size = new System.Drawing.Size(120, 25);
            this.txtTaskDesc.Location = new System.Drawing.Point(140, 53); this.txtTaskDesc.Size = new System.Drawing.Size(220, 25); this.txtTaskDesc.BackColor = System.Drawing.Color.FromArgb(30, 41, 59); this.txtTaskDesc.ForeColor = System.Drawing.Color.White;

            this.lblTaskReminder.Location = new System.Drawing.Point(380, 20); this.lblTaskReminder.Text = "Reminder Date:"; this.lblTaskReminder.Size = new System.Drawing.Size(120, 25);
            this.txtTaskReminder.Location = new System.Drawing.Point(500, 18); this.txtTaskReminder.Size = new System.Drawing.Size(220, 25); this.txtTaskReminder.BackColor = System.Drawing.Color.FromArgb(30, 41, 59); this.txtTaskReminder.ForeColor = System.Drawing.Color.White;

            this.btnAddTask.Location = new System.Drawing.Point(500, 50); this.btnAddTask.Size = new System.Drawing.Size(220, 32);
            this.btnAddTask.Text = "➕ Add Task Item";
            this.btnAddTask.BackColor = System.Drawing.Color.FromArgb(14, 165, 233); this.btnAddTask.ForeColor = System.Drawing.Color.Black;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

            this.dgvTasks.Location = new System.Drawing.Point(20, 100);
            this.dgvTasks.Size = new System.Drawing.Size(740, 440);
            this.dgvTasks.BackgroundColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvTasks.ForeColor = System.Drawing.Color.Black;
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.btnMarkComplete.Location = new System.Drawing.Point(20, 560);
            this.btnMarkComplete.Size = new System.Drawing.Size(200, 40);
            this.btnMarkComplete.Text = "✔ Mark Complete";
            this.btnMarkComplete.BackColor = System.Drawing.Color.LimeGreen;
            this.btnMarkComplete.ForeColor = System.Drawing.Color.Black;
            this.btnMarkComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click);

            this.btnDeleteTask.Location = new System.Drawing.Point(240, 560);
            this.btnDeleteTask.Size = new System.Drawing.Size(200, 40);
            this.btnDeleteTask.Text = "❌ Delete Selected";
            this.btnDeleteTask.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnDeleteTask.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);

            // ── PANEL C: CYBERSECURITY MINI-GAME PANEL ─────────────
            this.panelQuiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuiz.Controls.Add(this.lblQuizQuestion);
            this.panelQuiz.Controls.Add(this.rdoOptionA);
            this.panelQuiz.Controls.Add(this.rdoOptionB);
            this.panelQuiz.Controls.Add(this.rdoOptionC);
            this.panelQuiz.Controls.Add(this.rdoOptionD);
            this.panelQuiz.Controls.Add(this.btnSubmitAnswer);
            this.panelQuiz.Controls.Add(this.lblQuizFeedback);
            this.panelQuiz.Controls.Add(this.btnNextQuestion);
            this.panelQuiz.Controls.Add(this.lblQuizScore);

            this.lblQuizQuestion.Location = new System.Drawing.Point(30, 40);
            this.lblQuizQuestion.Size = new System.Drawing.Size(720, 80);
            this.lblQuizQuestion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuizQuestion.Text = "Question text will appear here...";

            this.rdoOptionA.Location = new System.Drawing.Point(40, 140); this.rdoOptionA.Size = new System.Drawing.Size(680, 35);
            this.rdoOptionB.Location = new System.Drawing.Point(40, 190); this.rdoOptionB.Size = new System.Drawing.Size(680, 35);
            this.rdoOptionC.Location = new System.Drawing.Point(40, 240); this.rdoOptionC.Size = new System.Drawing.Size(680, 35);
            this.rdoOptionD.Location = new System.Drawing.Point(40, 290); this.rdoOptionD.Size = new System.Drawing.Size(680, 35);

            this.btnSubmitAnswer.Location = new System.Drawing.Point(40, 360);
            this.btnSubmitAnswer.Size = new System.Drawing.Size(180, 40);
            this.btnSubmitAnswer.Text = "Submit Answer 🔐";
            this.btnSubmitAnswer.BackColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this.btnSubmitAnswer.ForeColor = System.Drawing.Color.Black;
            this.btnSubmitAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitAnswer.Click += new System.EventHandler(this.btnSubmitAnswer_Click);

            this.btnNextQuestion.Location = new System.Drawing.Point(240, 360);
            this.btnNextQuestion.Size = new System.Drawing.Size(180, 40);
            this.btnNextQuestion.Text = "Next Question ➡";
            this.btnNextQuestion.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnNextQuestion.ForeColor = System.Drawing.Color.White;
            this.btnNextQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextQuestion.Visible = false;
            this.btnNextQuestion.Click += new System.EventHandler(this.btnNextQuestion_Click);

            this.lblQuizFeedback.Location = new System.Drawing.Point(40, 430);
            this.lblQuizFeedback.Size = new System.Drawing.Size(680, 120);
            this.lblQuizFeedback.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Italic);
            this.lblQuizFeedback.Text = "";

            this.lblQuizScore.Location = new System.Drawing.Point(40, 580);
            this.lblQuizScore.Size = new System.Drawing.Size(300, 30);
            this.lblQuizScore.Text = "Score: 0";
            this.lblQuizScore.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblQuizScore.ForeColor = System.Drawing.Color.Cyan;

            // ── Structure Initialization Hooks ──────────────────────
            this.Controls.Add(this.panelContentContainer);
            this.Controls.Add(this.panelSidebar);
            this.panelSidebar.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelChat.ResumeLayout(false);
            this.panelChat.PerformLayout();
            this.panelTasks.ResumeLayout(false);
            this.panelTasks.PerformLayout();
            this.panelQuiz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);
        }
    }
}