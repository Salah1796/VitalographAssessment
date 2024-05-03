using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using VitalographAssessment;
using VitalographAssessment.Helper;
using VitalographAssessment.Helper.Interfaces;
using VitalographAssessment.Interfaces;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

Log.Information("Program started.");

IHost _host = Host.CreateDefaultBuilder()
    .ConfigureServices(ser =>
    {
        ser.AddScoped<ICaesarCipherEncryptionManager, CaesarCipherEncryptionManager>();
        ser.AddScoped<ICaesarCipherEncryptor, CaesarCipherEncryptor>();
    })
    .Build();

ICaesarCipherEncryptionManager caesarCipherEncryption = _host.Services.GetRequiredService<ICaesarCipherEncryptionManager>();
caesarCipherEncryption.Run();
Log.Information("Program finished.");
Log.CloseAndFlush();
