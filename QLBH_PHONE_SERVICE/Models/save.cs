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
    [KnownType(typeof(product))]
    [KnownType(typeof(save_date))]
    
    public partial class save
    {
        public save()
        {
            this.products = new HashSet<product>();
            this.save_date = new HashSet<save_date>();
        }
    
    	[DataMember]
        public int id { get; set; }
    	[DataMember]
        public string name { get; set; }
    	[DataMember]
        public int percent_save { get; set; }
    	[DataMember]
        public string content_save { get; set; }
    	[DataMember]
        public string image { get; set; }
    
    	[DataMember]
        public virtual ICollection<product> products { get; set; }
    	[DataMember]
        public virtual ICollection<save_date> save_date { get; set; }
    }
}
