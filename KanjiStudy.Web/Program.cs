using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using KanjiStudy.SRS;
using KanjiStudy.Web.Helpers;

namespace KanjiStudy.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<StudyConfig>();
            builder.Services.AddScoped<LocalStore>();
            builder.Services.AddScoped<CanvasHelper>();
            builder.Services.AddScoped<RtkImportHelper>();
            builder.Services.AddScoped<StudySession>();
            await builder.Build().RunAsync();
        }
    }
}
