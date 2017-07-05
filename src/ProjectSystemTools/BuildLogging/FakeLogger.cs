﻿using Microsoft.Build.Framework;

namespace Microsoft.VisualStudio.ProjectSystem.Tools.BuildLogging
{
    internal sealed class FakeLogger : ILogger, IBuild
    {
        private IBuildManager _buildManager;

        public LoggerVerbosity Verbosity { get => LoggerVerbosity.Quiet; set { } }

        public ConfiguredProject ConfiguredProject { get; }

        public string Parameters { get => null; set { } }

        public FakeLogger(IBuildManager buildManager, ConfiguredProject configuredProject)
        {
            _buildManager = buildManager;
            ConfiguredProject = configuredProject;
        }

        public void Initialize(IEventSource eventSource)
        {
            _buildManager.NotifyBuildStarted(this);
        }

        public void Shutdown()
        {
            _buildManager.NotifyBuildEnded(this);
        }
    }
}
