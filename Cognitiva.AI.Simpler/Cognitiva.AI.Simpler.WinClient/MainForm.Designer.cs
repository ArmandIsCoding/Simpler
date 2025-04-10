namespace Cognitiva.AI.Simpler.WinClient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            statusStrip1 = new StatusStrip();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            webView22 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView22).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.Location = new Point(805, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 24);
            button1.TabIndex = 0;
            button1.Text = "Fight!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(805, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "http://www.infobae.com/";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 537);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(880, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Left;
            webView21.Location = new Point(0, 24);
            webView21.Name = "webView21";
            webView21.Size = new Size(380, 513);
            webView21.TabIndex = 1;
            webView21.ZoomFactor = 1D;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(880, 24);
            panel1.TabIndex = 4;
            // 
            // webView22
            // 
            webView22.AllowExternalDrop = true;
            webView22.CreationProperties = null;
            webView22.DefaultBackgroundColor = Color.White;
            webView22.Dock = DockStyle.Fill;
            webView22.Location = new Point(380, 24);
            webView22.Name = "webView22";
            webView22.Size = new Size(500, 513);
            webView22.TabIndex = 5;
            webView22.ZoomFactor = 1D;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 559);
            Controls.Add(webView22);
            Controls.Add(webView21);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView22).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private StatusStrip statusStrip1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView22;
    }
}
