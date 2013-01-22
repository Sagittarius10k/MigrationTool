﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Logging;

namespace MigrationTool.Infrastructure
{
    /// <summary>
    /// A logger that holds on to log entries until a callback delegate is set, then plays back log entries and sends new log entries.
    /// </summary>
    [Export]
    public class CallbackLogger : ILoggerFacade
    {
        private readonly Queue<Tuple<string, Category, Priority>> _savedLogs =
            new Queue<Tuple<string, Category, Priority>>();

        /// <summary>
        /// Gets or sets the callback to receive logs.
        /// </summary>
        /// <value>An Action&lt;string, Category, Priority&gt; callback.</value>
        public Action<string, Category, Priority> Callback { get; set; }

        /// <summary>
        /// Write a new log entry with the specified category and priority.
        /// </summary>
        /// <param name="message">Message body to log.</param>
        /// <param name="category">Category of the entry.</param>
        /// <param name="priority">The priority of the entry.</param>
        public void Log(string message, Category category, Priority priority)
        {
            if (Callback != null)
            {
                Callback(message, category, priority);
            }
            else
            {
                _savedLogs.Enqueue(new Tuple<string, Category, Priority>(message, category, priority));
            }
        }

        /// <summary>
        /// Replays the saved logs if the Callback has been set.
        /// </summary>
        public void ReplaySavedLogs()
        {
            if (Callback == null) return;
            
            while (_savedLogs.Count > 0)
            {
                var log = _savedLogs.Dequeue();
                Callback(log.Item1, log.Item2, log.Item3);
            }
        }
    }
}
