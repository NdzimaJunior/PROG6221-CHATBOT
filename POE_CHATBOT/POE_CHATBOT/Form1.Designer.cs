namespace POE_CHATBOT
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // ── Controls ───────────────────────────────────────────
        private System.Windows.Forms.Label lblAscii;
        private System.Windows.Forms.RichTextBox txtChat;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAscii = new System.Windows.Forms.Label();
            this.txtChat = new System.Windows.Forms.RichTextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ── Form ───────────────────────────────────────────
            this.Text = "Cyber Sentinel AI 🔐";
            this.BackColor = System.Drawing.Color.FromArgb(10, 10, 30);   // dark navy
            this.ForeColor = System.Drawing.Color.Cyan;
            this.Size = new System.Drawing.Size(860, 680);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Consolas", 10F);
            this.Load += new System.EventHandler(this.Form1_Load);

            // ── ASCII Header Label ─────────────────────────────
            this.lblAscii.Location = new System.Drawing.Point(10, 10);
            this.lblAscii.Size = new System.Drawing.Size(820, 140);
            this.lblAscii.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblAscii.ForeColor = System.Drawing.Color.Cyan;
            this.lblAscii.BackColor = System.Drawing.Color.Transparent;
            this.lblAscii.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── Chat Display (RichTextBox) ─────────────────────
            this.txtChat.Location = new System.Drawing.Point(10, 160);
            this.txtChat.Size = new System.Drawing.Size(820, 400);
            this.txtChat.BackColor = System.Drawing.Color.FromArgb(15, 15, 40);
            this.txtChat.ForeColor = System.Drawing.Color.White;
            this.txtChat.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtChat.ReadOnly = true;
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

            // ── Input TextBox ──────────────────────────────────
            this.txtInput.Location = new System.Drawing.Point(10, 575);
            this.txtInput.Size = new System.Drawing.Size(700, 30);
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(20, 20, 50);
            this.txtInput.ForeColor = System.Drawing.Color.White;
            this.txtInput.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);

            // ── Send Button ────────────────────────────────────
            this.btnSend.Location = new System.Drawing.Point(720, 572);
            this.btnSend.Size = new System.Drawing.Size(110, 35);
            this.btnSend.Text = "SEND 🔐";
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(0, 180, 180);
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // ── Add controls to form ───────────────────────────
            this.Controls.Add(this.lblAscii);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnSend);

            this.ResumeLayout(false);
        }
    }
}