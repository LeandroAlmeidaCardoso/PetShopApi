using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Petshop.Api.Rest.Code;
using Petshop.Enums;
using Platform.Entity.Json;
using System;
using System.IO;
using System.Web.Mvc;

namespace Petshop.Api.Rest.Controllers
{
    public class PetshopController : BaseController
    {
        [HttpPost]
        public JsonResult Execute()
        {
            JsonResult result = new JsonResult();

            try
            {
                Stream stream = this.HttpContext.Request.InputStream;
                StreamReader reader = new StreamReader(stream, Request.ContentEncoding);
                string jsonInput = reader.ReadToEnd();

                JsonBase jsonBase = JsonConvert.DeserializeObject<JsonBase>(jsonInput);

                if (!Enum.TryParse<MethodType>(jsonBase.Method, out MethodType methodType))
                {
                    throw new Exception(string.Format($"Não existe o tipo de função {0} informada", jsonBase.Method));
                }

                var jsonObject = JObject.Parse(jsonInput);

                string[] credentials = ParseAuthHeader(this.HttpContext.Request.Headers["Authorization"]);

                if (credentials is null)
                {
                    throw new Exception("As Credenciais não foram informadas corretamente.");
                }

                MethodHandler.Call(this, methodType, result, jsonInput);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                result.Data = new { Success = "false", Message = message, Validation = GetFieldsErrors(ModelState) };
            }

            result.MaxJsonLength = int.MaxValue;
            return result;
        }

        private void RegisterPet(JsonResult result, string jsonInput)
        {
            JsonRegisterPet jsonRegisterPet = JsonConvert.DeserializeObject<JsonRegisterPet>(jsonInput);
            TryValidateModel(jsonRegisterPet);

            if (!ModelState.IsValid)
                throw new Exception("Informação estão inválidas, veja a propriedade Validation do json para mais detalhes.");
             
            //fazer regra

            result.Data = new { Success = "true", Message = "Pet Registrado!" };
            
        }

        private void RegisterEmployee(JsonResult result, string jsonInput)
        {


            if (!ModelState.IsValid)
                throw new Exception("Informação estão inválidas, veja a propriedade Validation do json para mais detalhes.");

            //fazer regra

            result.Data = new { Success = "true", Message = "Funcionário Registrado!" };
        }

        private void RegisterPetOwner(JsonResult result, string jsonInput)
        {


            if (!ModelState.IsValid)
                throw new Exception("Informação estão inválidas, veja a propriedade Validation do json para mais detalhes.");

            //fazer regra

            result.Data = new { Success = "true", Message = "Cliente Registrado!" };
        }

        private void GetPetOwnerList(JsonResult result, string jsonInput)
        {


            if (!ModelState.IsValid)
                throw new Exception("Informação estão inválidas, veja a propriedade Validation do json para mais detalhes.");

            //fazer regra

            result.Data = new { Success = "true", PetOwner = "Cliente Registrado!" };
        }

    }
}