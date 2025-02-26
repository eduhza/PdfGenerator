using Domain.DTOs;

namespace Shared.Interfaces;

public interface ITemplateService
{
    Task<string> ProcessarTemplate(string templateNome, InvoiceDto dados);
}
