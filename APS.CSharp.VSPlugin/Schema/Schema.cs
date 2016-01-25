using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.CSharp.VSPlugin
{
    public class Schema
    {
        private Dictionary<string, Property> _properties;
        private Dictionary<string, Relation> _relations;
        private Dictionary<string, Structure> _structures;

        [JsonProperty(PropertyName = "apsVersion", Required = Required.Always)]
        public string ApsVersion { get; set; }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "implements", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Implements { get; set; }

        [JsonProperty(PropertyName = "access", NullValueHandling = NullValueHandling.Ignore)]
        public Access Access { get; set; }

        [JsonProperty(PropertyName = "properties", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Property> Properties
        {
            get
            {
                if (_properties == null)
                    _properties = new Dictionary<string, Property>();
                return _properties;
            }
            set { _properties = value; }
        }

        /// <summary>
        /// Used for Json.Net conditional serializarion of properties object, so we will not get a properties{} object in the result
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeProperties()
        {
            if (Properties == null || Properties.Count == 0)
                return false;
            return true;
        }


        [JsonProperty(PropertyName = "operations", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Operation> Operations { get; set; }

        [JsonProperty(PropertyName = "structures", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Structure> Structures
        {
            get
            {
                if (_structures == null)
                    _structures = new Dictionary<string, Structure>();
                return _structures;
            }
            set{ _structures = value; }
        }

        /// <summary>
        /// Used for Json.Net conditional serializarion of Structures object, so we will not get a structures{} object in the result
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeStructures()
        {
            if (Structures == null || Structures.Count == 0)
                return false;
            return true;
        }

        [JsonProperty(PropertyName = "relations", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Relation> Relations
        {
            get
            {
                if (_relations == null)
                    _relations = new Dictionary<string, Relation>();
                return _relations;
            }
            set { _relations = value; }
        }

        /// <summary>
        /// Used for Json.Net conditional serializarion of relations object, so we will not get a relations{} object in the result
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeRelations()
        {
            if (Relations == null || Relations.Count == 0)
                return false;
            return true;
        }


    }

}
