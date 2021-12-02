﻿namespace HACC.Logging;

public class CustomLogger : ILogger
{
    private readonly Func<LoggingConfiguration> _getCurrentConfig;
    private readonly string _name;

    public CustomLogger(
        string name,
        Func<LoggingConfiguration> getCurrentConfig)
    {
        (_name, _getCurrentConfig) = (name, getCurrentConfig);
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return default!;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return _getCurrentConfig().LogLevels.ContainsKey(logLevel);
    }

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception exception,
        Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var config = _getCurrentConfig();
        if (config.EventId == 0 || config.EventId == eventId.Id)
        {
            //ConsoleColor originalColor = Console.ForegroundColor;

            //Console.ForegroundColor = config.LogLevels[logLevel];
            //Console.WriteLine($"[{eventId.Id,2}: {logLevel,-12}]");

            //Console.ForegroundColor = originalColor;
            //Console.WriteLine($"     {_name} - {formatter(state, exception)}");
        }
    }
}