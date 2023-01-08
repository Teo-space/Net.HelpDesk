using System.Threading.RateLimiting;
using FluentValidation.AspNetCore;
using FluentValidation;
using HtmlTags;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace HelpDesk;

public class Program
{
    public static void Main(string[] args) => Configuration.Configuration.ConfigureAll(WebApplication.CreateBuilder(args));
}