using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using APS.CSharp.SDK.Attributes;
using APS.CSharp.SDK;

namespace APS.CSharp.VSPlugin
{
    public class Operation
    {
        [JsonProperty(PropertyName = "verb")]
        public string Verb { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        [JsonProperty(PropertyName = "static", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Static { get; set; }

        [JsonProperty(PropertyName = "parameters", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Parameters> Parameters { get; set; }

        [JsonProperty(PropertyName = "response", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Response Response { get; set; }

        public bool ShouldSerializeResponse()
        {
            if (string.IsNullOrEmpty(Response.ContentType) && string.IsNullOrEmpty(Response.Type))
                return false;
            return true;
        }


        [JsonProperty(PropertyName = "errorResponse", NullValueHandling = NullValueHandling.Ignore)]
        public ErrorResponse ErrorResponse { get; set; }


        [JsonProperty(PropertyName = "access", NullValueHandling = NullValueHandling.Ignore)]
        public Access Access { get; set; }

        public static Operation CreateOperationObject(MemberInfo method)
        {
            Operation op = new Operation();

            OperationAttribute operationAttrib = method.GetCustomAttribute<OperationAttribute>();

            if (operationAttrib == null)
                throw new Exception(string.Format("The custom operation '{0}', doesn't contain the OperationAttribute.", method.Name));

            op.Verb = operationAttrib.Verb.ToString();
            op.Static = operationAttrib.Static;
            op.Path = operationAttrib.Path;
            op.Response = new Response();
            op.Response.ContentType = operationAttrib.ResponseContentType;
            op.Response.Type = operationAttrib.ResponseType;

            if (!string.IsNullOrEmpty(operationAttrib.ErrorResponseType))
            {
                op.ErrorResponse = new ErrorResponse();
                op.ErrorResponse.Type = operationAttrib.ErrorResponseType;
                if (!string.IsNullOrEmpty(operationAttrib.ErrorResponseProperties))
                {
                    string[] errorProperties = operationAttrib.ErrorResponseProperties.Split(';');
                    op.ErrorResponse.Properties = new Dictionary<string, string>();
                    foreach(string errorProperty in errorProperties)
                    {
                        if (!string.IsNullOrEmpty(errorProperty))
                        {
                            string[] splitProperty = errorProperty.Split(':');
                            if (splitProperty.Length == 2)
                                op.ErrorResponse.Properties.Add(splitProperty[0], splitProperty[1]);
                        }
                    }
                }
            }

            foreach(ParamAttribute paramAttribute in method.GetCustomAttributes<ParamAttribute>())
            {
                if (op.Parameters == null)
                    op.Parameters = new Dictionary<string, VSPlugin.Parameters>();
                op.Parameters.Add(paramAttribute.Name, new VSPlugin.Parameters()
                {
                    Kind = paramAttribute.Kind.ToStringAPS(),
                    Required = paramAttribute.Required,
                    Type = Utility.ConvertType2APSType(paramAttribute.Type)
                });
            }
            
            return op;
        }
    }

    public class Response
    {
        private string _type;
        private string _contentType;

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type
        {
            get { return _type; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;
                _contentType = string.Empty;
                _type = value;
            }
        }

        [JsonProperty("contentType", NullValueHandling = NullValueHandling.Ignore)]
        public string ContentType
        {
            get { return _contentType; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;
                _type = string.Empty;
                _contentType = value;
            }
        }
    }

    public class Parameters
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("required", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Required { get; set; }
    }

    public class ErrorResponse
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "properties")]
        public Dictionary<string, string> Properties { get; set; }

        public bool ShouldSerializeProperties()
        {
            if (Properties == null || Properties.Count == 0)
                return false;
            return true;
        }
    }

}
