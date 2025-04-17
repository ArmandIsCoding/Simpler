using Microsoft.Extensions.AI;
using System.Text;
using System.Net;
using Cognitiva.AI.Simpler.Dto;

namespace Cognitiva.AI.Simpler
{
    public class AICore
    {
        public async Task<string> Extract(string html, List<Link> links)
        {
            IChatClient client = new OllamaChatClient(new Uri("http://localhost:11434/"), "llama3.2");

            string prompt = $"""
                Analiza el siguiente contenido extraído de una página web. El contenido puede incluir noticias, artículos, listas o información diversa:

                '{html}'

                Quiero que lo resumas en un lenguaje claro y accesible, como si se lo explicaras a alguien sin conocimientos previos sobre el tema.

                ✅ Reglas:
                - Organiza la respuesta en formato **HTML simple**.
                - Usa **títulos (H1)** para el tema principal.
                - Usa **subtítulos (H2, H3)** para secciones y subsecciones.
                - Usa **párrafos (P)** para explicar cada punto.
                - Si hay listas o eventos, representalos con **listas HTML (<ul>, <li>)**.
                - NO devuelvas texto plano. La salida debe ser HTML bien estructurado y legible.

                💡 Ejemplo de estructura:

                <h1>Resumen del contenido</h1>
                <h2>Sección principal</h2>
                <p>Descripción clara de lo que ocurre...</p>
                <h3>Subtema</h3>
                <ul>
                  <li>Punto relevante</li>
                  <li>Otro punto</li>
                </ul>

                Por favor, responde solo con el HTML.
                """;

            var respuesta = await client.GetResponseAsync(prompt);
            var contenido = respuesta.ToString();

            // Agregar links al final
            var htmlLinks = new StringBuilder();
            if (links != null && links.Count > 0)
            {
                htmlLinks.AppendLine("<hr/><h2>Enlaces relacionados</h2><ul>");
                foreach (var link in links)
                {
                    var texto = string.IsNullOrWhiteSpace(link.text) ? link.href : WebUtility.HtmlEncode(link.text);
                    var href = WebUtility.HtmlEncode(link.href);
                    htmlLinks.AppendLine($"<li><a href=\"{href}\" target=\"_blank\">{texto}</a></li>");
                }
                htmlLinks.AppendLine("</ul>");
            }

            return contenido + htmlLinks.ToString();
        }
    }
}
