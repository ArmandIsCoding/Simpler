using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OllamaClient;
using Microsoft.Extensions.DependencyInjection;
using OllamaClient.Extensions;

namespace Cognitiva.AI.Simpler.WinClient
{
    public partial class MainForm : Form
    {
        private readonly OllamaHttpClient _ollamaService;

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

            var serviceProvider = new ServiceCollection()
                  .AddOllamaClient()
                  .BuildServiceProvider();

            var client = serviceProvider.GetRequiredService<IOllamaHttpClient>();

            var pullResult = client.Pull(new OllamaClient.Models.PullRequest()
            {
                Name = "phi3",
            }, CancellationToken.None);

            Console.WriteLine(pullResult.Status);

            var models = (client.GetModels(CancellationToken.None)).Result;

            foreach (var model in models.Models)
            {
                Console.WriteLine(model.Name);
            }

            var result = client.SendChat(new OllamaClient.Models.ChatStreamRequest()
            {
                Model = models.Models[0].Name,
                Messages = new List<OllamaClient.Models.Message>() { new OllamaClient.Models.Message() {
                        Content = "Hello, how are you?",
                        Role = "user"
                    }
                }
            }, CancellationToken.None);

            foreach (var message in result)
            {
                if (message.Message is null) continue;

                Console.Write(message.Message.Content);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
