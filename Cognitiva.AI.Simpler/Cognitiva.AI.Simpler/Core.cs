namespace Cognitiva.AI.Simpler
{
    using Microsoft.Extensions.DependencyInjection;
    using OllamaClient;
    using OllamaClient.Extensions;

    public class Core
    {
        public async Task Test()
        {
            var serviceProvider = new ServiceCollection()
                .AddOllamaClient()
                .BuildServiceProvider();

            var client = serviceProvider.GetRequiredService<IOllamaHttpClient>();

            var pullResult = client.Pull(new OllamaClient.Models.PullRequest()
            {
                Name = "phi3",
            }, CancellationToken.None);

            Console.WriteLine(pullResult.Status);

            var models = await client.GetModels(CancellationToken.None);

            foreach (var model in models.Models)
            {
                Console.WriteLine(model.Name);
            }

            var result = client.SendChat(new OllamaClient.Models.ChatStreamRequest()
            {
                Model = models.Models[0].Name,
                Messages = new List<OllamaClient.Models.Message>()
                {
                    new OllamaClient.Models.Message()
                    {
                        Content = "Hello, how are you?",
                        Role = "user"
                    }
                }
            }, CancellationToken.None);

            await foreach (var message in result)
            {
                if (message.Message is null) continue;

                Console.Write(message.Message.Content);
            }
        }
    }
}
