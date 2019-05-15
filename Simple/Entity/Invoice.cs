using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Simple.Entity.Base;

namespace Simple.Entity
{
    public class Invoice:BaseEntity
    {
        public Guid CustomerId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Customer Customer { get; set; }
    }
}
