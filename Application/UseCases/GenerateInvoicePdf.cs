using Domain.DTOs;
using Shared.Interfaces;

namespace Application.UseCases;

public class GenerateInvoicePdf(
    IPdfService pdfService,
    ITemplateService templateService)
{
    public async Task<byte[]> ExecuteAsync()
    {
        var fatura = new InvoiceDto
        {
            NomeEmpresa = "Minha Empresa LTDA",
            ValorFatura = "R$ 1.299,99",
            DataVencimento = DateTime.UtcNow.AddDays(7).ToString("dd/MM/yyyy")
        };

        var htmlContent = await templateService.ProcessarTemplate("fatura", fatura);
        var pdfBytes = await pdfService.GeneratePdfAsync(htmlContent);

        return pdfBytes;
    }
}
