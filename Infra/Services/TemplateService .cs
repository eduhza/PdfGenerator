using Domain.DTOs;
using HandlebarsDotNet;
using Shared.Interfaces;

namespace Application.Services;

public class TemplateService : ITemplateService
{
    private readonly string _caminhoTemplates;

    public TemplateService()
    {
        _caminhoTemplates = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");
    }

    public async Task<string> ProcessarTemplate(string templateNome, InvoiceDto dados)
    {
        string caminhoArquivo = Path.Combine(_caminhoTemplates, $"{templateNome}.html");

        if (!File.Exists(caminhoArquivo))
            throw new FileNotFoundException($"Template {templateNome} não encontrado!");

        string templateHtml = await File.ReadAllTextAsync(caminhoArquivo);

        var templateCompilado = Handlebars.Compile(templateHtml);
        var faturaHtml = templateCompilado(dados);
        return faturaHtml;
    }
}
