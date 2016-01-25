using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using APS.CSharp.SDK.Attributes;

namespace APS.CSharp.VSPlugin
{
    public class Access
    {
        public static Access GetAccess(PropertyInfo property)
        {
            Access access = new Access();

            AccessAttribute accessAttrib = property.GetCustomAttribute<AccessAttribute>();
            if (accessAttrib == null)
                return null;

            access.Admin = accessAttrib.Admin;
            access.Owner = accessAttrib.Owner;
            access.Referrer = accessAttrib.Referrer;

            return access;
        }

        [JsonProperty(PropertyName = "owner", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Owner { get; set; }

        [JsonProperty(PropertyName = "admin", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Admin { get; set; }

        [JsonProperty(PropertyName = "referrer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Referrer { get; set; }

    }
}
