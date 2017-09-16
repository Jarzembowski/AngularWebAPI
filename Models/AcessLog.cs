using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPIAngular.Models
{
    public class AcessLog
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public DateTime AcessDate { get; set; }

        /*
            Relacionamento 0-1---N com a classe Subscriber
            Cada AcessLog só pode pertencer a 1 ou 0 subscriber
        */
        //Foreign Key
        public int? SubscriberId { get; set; }        

        //Navigation property
        public virtual Subscriber Subscriber { get; set; }
        

    }
}