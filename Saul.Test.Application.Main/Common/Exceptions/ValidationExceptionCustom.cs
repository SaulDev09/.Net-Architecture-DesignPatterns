using Saul.Test.Transversal.Common;
using System;
using System.Collections.Generic;

namespace Saul.Test.Application.UseCases.Common.Exceptions
{
    public class ValidationExceptionCustom : Exception
    {
        public ValidationExceptionCustom() : base("One or moew validations failures")
        {
            Errors = new List<BaseError>();
        }

        public ValidationExceptionCustom(IEnumerable<BaseError>? errors) : this()
        {
            Errors = errors;
        }

        public IEnumerable<BaseError>? Errors { get; }
    }
}
