using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Thinktecture.IdentityServer.Core.Administration.Validation;

namespace Thinktecture.IdentityServer.Core.Administration.Extensions
{
    static class ModelStateExtensions
    {
        public static ValidationResult ToValidationResult(this ModelStateDictionary modelState)
        {
            if (modelState == null || modelState.IsValid) return ValidationResult.SuccessResult;

            var query1 =
                from item in modelState
                where
                    item.Value.Errors.Any() &&
                    String.IsNullOrWhiteSpace(item.Key)
                from error in item.Value.Errors
                select new ValidationMessage
                {
                    Message = error.ErrorMessage
                };

            var query2 =
                from item in modelState
                where
                    item.Value.Errors.Any() &&
                    !String.IsNullOrWhiteSpace(item.Key)
                from error in item.Value.Errors
                select new FieldValidationMessage
                {
                    Field = item.Key,
                    Message = error.ErrorMessage
                };

            return new ValidationResult { Errors = query1.Union(query2).ToArray() };
        }
    }
}
