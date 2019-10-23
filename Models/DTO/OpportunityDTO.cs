using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api_Demo.Models.DTO
{
    public class OpportunityDTO
    {
        public string OpportunityId { get; set; }
        public string OpportunityNm { get; set; }
        public string ROStageCd { get; set; }
        public Nullable<System.DateTime> InitGoLiveDt { get; set; }
        public string SubCSGNm { get; set; }
        public System.DateTime CreateDttm { get; set; }
        public string UpdateUserId { get; set; }
        public System.DateTime UpdateDttm { get; set; }

    }
}