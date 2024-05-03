using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using VitalographAssessment;
using VitalographAssessment.Helper;
using VitalographAssessment.Helper.Interfaces;
using VitalographAssessment.Interfaces;

Log.Logger = new LoggerConfiguration()
       .MinimumLevel.Debug()
       .WriteTo.File("logs/caesarCipher.txt", rollingInterval: RollingInterval.Day)
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
