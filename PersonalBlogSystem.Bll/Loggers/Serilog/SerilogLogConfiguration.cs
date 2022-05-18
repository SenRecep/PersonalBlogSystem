using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;

namespace PersonalBlogSystem.Bll.Loggers.Serilog;

public class SerilogLogConfiguration
{
    private const string _template = "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}";
    public static string LogTemplate = _template;
    public static Logger CreateLoggerConfiguration() =>
        new LoggerConfiguration()
             .WriteTo.Console(outputTemplate: LogTemplate, theme: AnsiConsoleTheme.Literate)
             .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day, outputTemplate: LogTemplate)
            .CreateLogger();
}
