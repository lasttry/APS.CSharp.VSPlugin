using APS.CSharp.SDK.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APS.CSharp.VSPlugin
{
    public class Relation
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "collection", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Collection { get; set; }

        [JsonProperty(PropertyName = "required", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Required{ get; set; }

        [JsonProperty(PropertyName = "requirement", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Requirement { get; set; }

        [JsonProperty(PropertyName = "allocate", NullValueHandling = NullValueHandling.Ignore)]
        public string Allocate { get; set; }

        public bool ShouldSerializeAllocate()
        {
            if (Allocate == AllocateEnum.Any.ToString())
                return false;
            return true;
        }

        /// <summary>
        /// Creates one instance of the Relation Object from the PropertyInfo object of the reflected class
        /// </summary>
        /// <param name="propInfo"></param>
        /// <returns></returns>
        public static Relation CreateRelationObject(PropertyInfo propInfo)
        {
            Relation result = new VSPlugin.Relation();

            // get's the Relation Attribute in the class
            RelationAttribute relationAttribute = propInfo.GetCustomAttribute<RelationAttribute>();

            if (relationAttribute== null)
                return result;

            Type elementType = null;
            //we need to discover the id of the relation and if it's a collection
            if (propInfo.PropertyType.IsArray)
            {
                result.Collection = true;

                elementType = propInfo.PropertyType.GetElementType();
            }
            else if(propInfo.PropertyType.IsGenericType && propInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                result.Collection = true;

                elementType = propInfo.PropertyType.GetGenericArguments().Single();
            }
            else
                elementType = propInfo.PropertyType;

            result.Type = GetResourceType(elementType);
            result.Required = relationAttribute.Required;
            result.Requirement = relationAttribute.Requirement;
            result.Allocate = relationAttribute.Allocate.ToString();

            return result;
        }

        public static string GetResourceType(Type t)
        {
            ResourceBaseAttribute propertyResourceAttribute = t.GetCustomAttribute<ResourceBaseAttribute>();
            if (propertyResourceAttribute == null)
                throw new Exception("Invalid relation object in class");
            return propertyResourceAttribute.Id;
        }

    }

}
