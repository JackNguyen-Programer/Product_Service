//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBH_PHONE_SERVICE.Models
{
    using System;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    
    [DataContract(IsReference = true)]
    [KnownType(typeof(user))]
    
    public partial class role
    {
        public role()
        {
            this.users = new HashSet<user>();
        }
    
    	[DataMember]
        public int id { get; set; }
    	[DataMember]
        public string name { get; set; }
    	[DataMember]
        public byte add_role { get; set; }
    	[DataMember]
        public byte read_role { get; set; }
    	[DataMember]
        public byte delete_role { get; set; }
    	[DataMember]
        public byte update_role { get; set; }
    	[DataMember]
        public string describe { get; set; }
    
    	[DataMember]
        public virtual ICollection<user> users { get; set; }
    }
}