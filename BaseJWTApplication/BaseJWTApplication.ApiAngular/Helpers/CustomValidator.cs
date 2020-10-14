﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseJWTApplication.ApiAngular.Helpers
{
    public class CustomValidator
    {
        public static List<string> GetErrorsByModel(ModelStateDictionary modelError)
        {
            var errors = new List<string>();

            var errorList = modelError.Where(t => t.Value.Errors.Count > 0)
                .ToDictionary(
                v => v.Key,
                v => v.Value.Errors.Select(e => e.ErrorMessage).ToArray()[0]);

            foreach (var item in errorList)
            {
                errors.Add(item.Value);
            }

            return errors;
        }

        public static List<string> GetErrorsByIdentityResults(IdentityResult identityResult)
        {
            var errors = new List<string>();

            foreach (var item in identityResult.Errors)
            {
                errors.Add(item.Description);
            }
            return errors;
        }
    }
}
