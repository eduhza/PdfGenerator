using Domain.DTOs;

namespace Application.Interfaces;

public interface ITemplateService
{
    Task<string> ProcessarTemplate(string templateNome, FaturaDto dados);
}
