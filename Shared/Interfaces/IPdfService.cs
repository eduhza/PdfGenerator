namespace Shared.Interfaces;

public interface IPdfService
{
    Task<byte[]> GeneratePdfAsync(string htmlContent);
}
