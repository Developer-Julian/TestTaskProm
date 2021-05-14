namespace TestTaskProm.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public static class Guard
    {
        public static void ArgumentNotNull(object argument, string argumentName, string message = null)
        {
            if (argument.Equals(null))
            {
                if (string.IsNullOrEmpty(message))
                {
                    throw new ArgumentNullException(argumentName);
                }

                throw new ArgumentNullException(argumentName,message);
            }
        }

        public static void ArgumentNotNullOrEmpty<TArg>(
            IEnumerable<TArg> argumentValue, 
            string argumentName, 
            string message = null)
        {
            ArgumentNotNull(argumentValue, argumentName, message);

            if (!argumentValue.Any())
            {
                throw new ArgumentException(message ?? "Argument must not be empty", argumentName);
            }
        }

        public static void ArgumentPropertyNotNullOrEmpty(
            string propertyValue,
            string argumentName,
            string propertyName)
        {
            ArgumentNotNull(argumentName, nameof(argumentName));
            ArgumentNotNull(propertyName, nameof(propertyName));

            if (string.IsNullOrEmpty(propertyValue))
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "The property {0} must not be null or empty", propertyName),
                    argumentName);
            }
        }
    }
}
