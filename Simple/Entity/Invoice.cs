using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Simple.Entity
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Customer Customer { get; set; }
    }
}
