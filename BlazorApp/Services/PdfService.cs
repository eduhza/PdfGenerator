using System.Net.Http.Headers;

namespace BlazorApp.Services
{
    public class PdfService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<byte[]?> GeneratePdfAsync(string htmlContent)
        {
            using var form = new MultipartFormDataContent();
            var htmlPart = new StringContent(htmlContent);
            htmlPart.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            form.Add(htmlPart, "files", "index.html");

            // Faz a requisição ao Gotenberg
            var uri = new Uri("/forms/chromium/convert/html", UriKind.Relative);
            var response = await _httpClient.PostAsync(uri, form);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }

            return null;
        }
    }
}
