using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class Subscriber
    {
        [Key]
        [Column(Order = 1)] 
        public int ID { get; set; }
        [DataType(DataType.EmailAddress)]
        [Column(Order = 2)] 
        [Key]
        public string Email { get; set; }
    }
}