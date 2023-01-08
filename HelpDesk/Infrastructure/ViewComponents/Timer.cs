using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.ViewComponents;

public class Timer : ViewComponent
{
    public record Parametr(bool includeSeconds);

    public string Invoke(Parametr p)
    {
        if (p.includeSeconds)
        {
            return $"Текущее время: {DateTime.Now.ToString("hh:mm:ss")}";
        }
        else
        {
            return $"Текущее время: {DateTime.Now.ToString("hh:mm")}";
        }
    }

}
