using Cognitiva.AI.Simpler.Dto;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cognitiva.AI.Simpler.WinClient
{
    public partial class MainForm : Form
    {
        AICore core = new AICore();

        public MainForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.webView21.Source = new Uri(this.textBox1.Text);
            await webView22.EnsureCoreWebView2Async();
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await webView22.EnsureCoreWebView2Async();
            webView22.NavigateToString("<h1>Cargando resumen...</h1>");

            // Obtenemos el contenido de texto plano y los links
            var script = """
                JSON.stringify({
                    text: document.body.innerText,
                    links: Array.from(document.querySelectorAll("a"))
                        .map(a => ({ text: a.textContent.trim(), href: a.href }))
                })
            """;

            var rawJson = await webView21.ExecuteScriptAsync(script);
            var jsonLimpio = System.Text.Json.JsonSerializer.Deserialize<string>(rawJson);
            var datos = System.Text.Json.JsonSerializer.Deserialize<PaginaExtraida>(jsonLimpio);


            // Limpiar panel2 antes de agregar los nuevos botones
            panel2.Controls.Clear();

            foreach (var link in datos.links.Take(10))
            {
                // Crear un botón para cada link
                Button linkButton = new Button
                {
                    Text = string.IsNullOrWhiteSpace(link.text) ? link.href : link.text,  // Texto del botón es el 'text' del link
                    Width = panel2.Width - 20,  // Ajustar el ancho al tamaño del panel
                    Height = 30,  // Altura estándar para el botón
                    Tag = link.href  // Almacenar el 'href' en el Tag del botón
                    ,
                    Dock = DockStyle.Top
                };

                // Agregar el evento Click al botón
                linkButton.Click += (sender, e) =>
                {
                    // Obtener el 'href' del botón (almacenado en Tag)
                    string url = linkButton.Tag.ToString();

                    // Navegar al link en webView22
                    webView21.NavigateToString(url);
                };

                // Agregar el botón al panel
                panel2.Controls.Add(linkButton);
            }


            // Ejecutamos el resumen con los links
            var resultadoHtml = await core.Extract(datos.text, datos.links);

            webView22.NavigateToString(resultadoHtml);
        }



        private async void button2_Click(object sender, EventArgs e)
        {
        }
    }



}
