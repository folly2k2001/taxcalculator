using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;
using TaxCalculationUI.Contracts;
using TaxCalculationUI.Services;

namespace TaxCalculationUI
{
    public class Program
    {
        //public static IConfiguration Configuration { get; }
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient();


            builder.Services.AddBlazoredToast();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddScoped<ICalculatedTaxService, CalculatedTaxService>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            await builder.Build().RunAsync();
        }
    }
}