using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Petshop.Api.Rest.Code
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            MethodHandler = new MethodHandler();
        }
        public MethodHandler MethodHandler { get; private set; }

        protected KeyValuePair<string, List<string>>[] GetFieldsErrors(ModelStateDictionary ModelState)
        {
            Dictionary<string, List<string>> fieldsErrors = new Dictionary<string, List<string>>();
            foreach (string key in ModelState.Keys)
            {
                if (ModelState[key].Errors.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (var error in ModelState[key].Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                    fieldsErrors.Add(key, errors);
                }
                else
                {
                    fieldsErrors.Add(key, new List<string>());
                }
            }
            return fieldsErrors.ToArray();
        }

        protected string[] ParseAuthHeader(string authHeader)
        {
            if (authHeader == null || authHeader.Length == 0 || !authHeader.StartsWith("Basic")) return null;
            string base64Credentials = authHeader.Substring(6);
            string[] credentials = Encoding.ASCII.GetString(Convert.FromBase64String(base64Credentials)).Split(new char[] { ':' });
            if (credentials.Count() != 2 || string.IsNullOrEmpty(credentials[0]) || string.IsNullOrEmpty(credentials[1])) return null;
            return credentials;
        }
    }
}