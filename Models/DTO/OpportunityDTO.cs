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
        public string OperatingUnitCd { get; set; }
        public string ContractExtensionFl { get; set; }
        public string ServiceGroupNm { get; set; }
        public string ExpectContractSignQtr { get; set; }
        public string ROStageCd { get; set; }
        public string SubCSGNm { get; set; }
        public string CreateUserId { get; set; }
        public bool ArchiveInd { get; set; }
    }
}