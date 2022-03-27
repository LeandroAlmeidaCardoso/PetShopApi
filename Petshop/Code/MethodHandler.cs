using Petshop.Enums;
using System.Reflection;
using System.Web.Mvc;

namespace Petshop.Api.Rest.Code
{
    public class MethodHandler
    {
        public void Call(object caller, MethodType methodType, JsonResult jsonResult, string jsonInput)
        {
            MethodInfo mainControllerMethod = caller.GetType().GetMethod(methodType.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            try
            {
                mainControllerMethod?.Invoke(caller, new object[] { jsonResult, jsonInput });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}