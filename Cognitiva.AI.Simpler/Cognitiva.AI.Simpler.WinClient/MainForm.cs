using System;

namespace Cognitiva.AI.Simpler.WinClient
{

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.webView21.Source = new Uri(this.textBox1.Text);
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webView21.Source = new Uri(this.textBox1.Text);
        }
    }
}
