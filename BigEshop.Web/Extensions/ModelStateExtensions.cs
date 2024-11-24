using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

namespace BigEshop.Web.Extensions
{
    public static class ModelStateExtensions
    {
        public static string GetModelError(this ModelStateDictionary modelState)
        {
            string errorMessage = string.Empty;
            int row = 1;

            foreach (var item in modelState.Values)
            {
                foreach (var error in item.Errors)
                {
                    errorMessage += $"{row}. {error.ErrorMessage}\n";

                    row++;
                }
            }

            return errorMessage;
            
            //modelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
        }
    }
}
