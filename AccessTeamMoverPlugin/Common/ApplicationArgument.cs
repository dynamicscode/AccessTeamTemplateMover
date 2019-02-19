﻿using System;

namespace AccessTeamMoverPlugin.Common
{
    [Flags]
    public enum Operation
    {
        Import,
        Export
    }

    public class ApplicationArgument
    {
        public Operation Operation { get; set; }
        public string FileName { get; set; }
        public string ConnectionString { get; set; }
    }
}
