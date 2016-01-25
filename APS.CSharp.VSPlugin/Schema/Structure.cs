using APS.CSharp.SDK.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APS.CSharp.VSPlugin
{
    public class Structure
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "properties")]
        public Dictionary<string, StructureProperty> Properties { get; set; }

        /// <summary>
        /// Creates one instance of the Relation Object from the PropertyInfo object of the reflected class
        /// </summary>
        /// <param name="propInfo"></param>
        /// <returns></returns>
        public static Structure CreateStructureObject(Type structureType)
        {
            Structure result = new VSPlugin.Structure();

            StructureAttribute structAttribute = structureType.GetCustomAttribute<StructureAttribute>();


            result.Type = structAttribute == null ? "object" : structAttribute.Type;
            result.Properties = new Dictionary<string, StructureProperty>();
            foreach(PropertyInfo pinfo in structureType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
            {
                PropertyAttribute propertyAttribute = pinfo.GetCustomAttribute<PropertyAttribute>();

                string itemsType = "";
                StructureProperty structure = new StructureProperty();
                structure.Required = propertyAttribute == null ? false : propertyAttribute.Required;
                Structure includedStructure;
                structure.Type = Utility.HandleProperty(pinfo, out itemsType, out includedStructure);
                if (!string.IsNullOrEmpty(itemsType))
                {
                    structure.Items = new ArraySchema()
                    {
                        Type = itemsType
                    };
                }
                result.Properties.Add(pinfo.Name, structure);                
            }

            return result;
        }
    }

    public class StructureProperty
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "items", NullValueHandling = NullValueHandling.Ignore)]
        public ArraySchema Items { get; set; }

        /// <summary>
        /// Used for Json.Net conditional serializarion of properties object, so we will not get a properties{} object in the result
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeItems()
        {
            if (Items == null || string.IsNullOrEmpty(Items.Type))
                return false;
            return true;
        }

        [JsonProperty(PropertyName = "required", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Required { get; set; }
    }


}
