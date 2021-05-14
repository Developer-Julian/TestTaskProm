using System;
using System.Collections.Generic;

namespace TestTaskProm.Common.Exceptions
{
    public sealed class ValidationException: Exception
    {
        public ValidationException(string message): base(message)
        {
        }

        public IDictionary<string, string> Details { get; set; } = new Dictionary<string, string>();
    }
}
