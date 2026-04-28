using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Hrms.Public.Tests
{
    [DebuggerStepThrough]
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string InputPath { get; set; }
        public string OutputPath { get; set; }

        public DirectoryInfo InputDirectory { get; }
        public DirectoryInfo OutputDirectory { get; }


        public AppSettings()
        {
            ConnectionString ??= string.Empty;
            InputPath ??= string.Empty;
            OutputPath ??= string.Empty;
            BindConfiguration(this);

            InputDirectory = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, InputPath));
            InputDirectory.Create();
            
            OutputDirectory = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, OutputPath));
            OutputDirectory.Create();
        }


        public static T BindConfiguration<T>(T settings, string? sectionName = null) where T : class
        {
            sectionName ??= typeof(T).Name;

            IConfiguration root = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<AppSettings>()
            .Build();

            var section = string.IsNullOrEmpty(sectionName) ? root : root.GetSection(sectionName);
            section?.Bind(settings);
            return settings;
        }

    }
}
