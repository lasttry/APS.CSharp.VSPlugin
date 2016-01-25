using APS.CSharp.SDK.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APS.CSharp.VSPlugin
{
    public class ArraySchema
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }

    public class Property
    {
        public static Property CreatePropertyObject(PropertyInfo propInfo, out Dictionary<string, Structure> structures)
        { 
            structures = new Dictionary<string, Structure>();

            Property result = new VSPlugin.Property();

            string itemsType = "";
            Structure structure = null;

            // we need to verify if we have a structure in this property
            StructureAttribute structureAttribute = propInfo.GetCustomAttribute<StructureAttribute>();
            if (structureAttribute != null)
                result.Type = structureAttribute.Type;
            else
                result.Type = Utility.HandleProperty(propInfo, out itemsType, out structure);

            if (!string.IsNullOrEmpty(itemsType))
            {
                result.Items = new ArraySchema();
                result.Items.Type = itemsType;
            }
            if (structure != null)
                structures.Add(propInfo.PropertyType.Name, structure);

            PropertyAttribute propAttrib = propInfo.GetCustomAttribute<PropertyAttribute>();
            if (propAttrib == null)
                return result;

            result.Description = propAttrib.Description;
            result.Required = propAttrib.Required;
            result.Readonly = propAttrib.ReadOnly;
            result.Final = propAttrib.Final;
            result.Encrypted = propAttrib.Encrypted;
            result.Unit = propAttrib.Unit;
            result.Default = propAttrib.Default;
            result.Format = propAttrib.Format;
            result.Pattern = propAttrib.Pattern;
            result.Title = propAttrib.Title;
            result.Headline = propAttrib.Headline;
            result.MinLength = propAttrib.MinLength;
            result.MaxLength = propAttrib.MaxLength;
            result.MinItems = propAttrib.MinItems;
            result.MaxItems = propAttrib.MaxItems;
            result.UniqueItems = propAttrib.UniqueItems;
            result.EnumValues = propAttrib.Enum;
            result.EnumTitles = propAttrib.EnumTitles;

            result.Access = Access.GetAccess(propInfo);

            return result;
        }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "items", NullValueHandling = NullValueHandling.Ignore)]
        public ArraySchema Items { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "required", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Required { get; set; }

        [JsonProperty(PropertyName = "readonly", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Readonly { get; set; }

        [JsonProperty(PropertyName = "final", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Final { get; set; }

        [JsonProperty(PropertyName = "encrypted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Encrypted { get; set; }

        [JsonProperty(PropertyName = "unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty(PropertyName = "default", NullValueHandling = NullValueHandling.Ignore)]
        public object Default { get; set; }

        [JsonProperty(PropertyName = "format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }

        [JsonProperty(PropertyName = "pattern", NullValueHandling = NullValueHandling.Ignore)]
        public string Pattern { get; set; }

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "headline", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Headline { get; set; }

        private int _minLength = -1;
        [DefaultValue(-1)]
        [JsonProperty(PropertyName = "minLength", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MinLength
        {
            get { return _minLength; }
            set { _minLength = value; }
        }
        private int _maxLength = -1;
        [DefaultValue(-1)]
        [JsonProperty(PropertyName = "maxLength", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MaxLength { get { return _maxLength; } set { _maxLength = value; } }

        private int _minItems = -1;
        [DefaultValue(-1)]
        [JsonProperty(PropertyName = "minItems", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MinItems{ get { return _minItems; } set { _minItems = value; } }

        private int _maxItems = -1;
        [DefaultValue(-1)]
        [JsonProperty(PropertyName = "maxItems", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int MaxItems { get { return _maxItems; } set { _maxItems = value; } }

        [JsonProperty(PropertyName = "uniqueItems", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool UniqueItems { get; set; }

        [JsonProperty(PropertyName = "enum", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> EnumValues { get; set; }

        [JsonProperty(PropertyName = "enumTitles", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> EnumTitles { get; set; }

        [JsonProperty(PropertyName = "access", NullValueHandling = NullValueHandling.Ignore)]
        public Access Access { get; set; }
    }
}
