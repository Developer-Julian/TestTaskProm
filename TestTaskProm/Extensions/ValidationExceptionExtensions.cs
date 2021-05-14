using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskProm.Common;
using TestTaskProm.Common.Exceptions;

namespace TestTaskProm.Web.Extensions
{
    internal static class ValidationExceptionExtensions
    {
        public static ValidationProblemDetails ToValidationProblemDetails(this ValidationException exception)
        {
            Guard.ArgumentNotNull(exception, nameof(exception));

            var validationProblem = new ValidationProblemDetails
            {
                Type = "validation-error",
                Title = exception.Message
            };

            foreach (var (key, value) in exception.Details)
            {
                validationProblem.Errors.Add(key, new[] { value });
            }

            return validationProblem;
        }
    }
}
