using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Web_Api_Demo.Repositories.DB;
using Web_Api_Demo.Repositories.Interface;

namespace Web_Api_Demo.Repositories
{
    public class OpportunityRepositories : IOpportunityRepositories
    {
        private ROTest context = new ROTest();
        public bool AddOpportunity(DB.Opportunity opp)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder(@"insert into ro.Opportunity(OpportunityId,OpportunityNm,
                                                                              OperatingUnitCd,ROStageCd,
                                                                              ContractExtensionFl,ServiceGroupNm,
                                                                              SubCSGNm,ExpectContractSignQtr,
                                                                              CreateUserId,CreateDttm,UpdateDttm,
                                                                              ArchiveInd)
                                                   values(@OpportunityId,@OpportunityNm,@OperatingUnitCd,@ROStageCd,
                                                          @ContractExtensionFl,@ServiceGroupNm,@SubCSGNm,@ExpectContractSignQtr,
                                                          @CreateUserId,getdate(),getdate(),@ArchiveInd)");
            try
            {
                result = context.Database.ExecuteSqlCommand(sb.ToString(),
                new SqlParameter("@OpportunityId", opp.OpportunityId),
                new SqlParameter("@OpportunityNm", opp.OpportunityNm),
                new SqlParameter("@OperatingUnitCd", opp.OperatingUnitCd),
                new SqlParameter("@ROStageCd", opp.ROStageCd),
                new SqlParameter("@ContractExtensionFl", opp.ContractExtensionFl),
                new SqlParameter("@ServiceGroupNm", opp.ServiceGroupNm),
                new SqlParameter("@SubCSGNm", opp.SubCSGNm),
                new SqlParameter("@ExpectContractSignQtr", opp.ExpectContractSignQtr),
                new SqlParameter("@CreateUserId", opp.CreateUserId),
                new SqlParameter("@ArchiveInd", opp.ArchiveInd));
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
            if (result > 0)
            {

                return true;
            }
            return false;
        }

        public bool DeleteOpportunities(string OppId)
        {
            StringBuilder sb = new StringBuilder(@"delete from ro.Opportunity 
                                                   where OpportunityId = @OpportunityId");
            var result = context.Database.ExecuteSqlCommand(sb.ToString(),
                new SqlParameter("@OpportunityId", OppId));
            if (result > 0)
            {
                context.SaveChanges();
                return true;
            }
            return false;

        }

        public List<Opportunity> GetNewAddOpportunity()
        {
            StringBuilder sb = new StringBuilder(@"select top (1) * from ro.Opportunity order by CreateDttm desc");
            return context.Database.SqlQuery<Opportunity>(sb.ToString()).ToList();
        }

        public List<DB.Opportunity> GetOpportunities()
        {
            StringBuilder sb = new StringBuilder("SELECT * FROM [ro].[Opportunity]");
            var result = context.Database.SqlQuery<DB.Opportunity>(sb.ToString()).ToList();
            return result;
        }

        public List<Opportunity> GetOpportunityByNm(string OppNm)
        {
            StringBuilder sb = new StringBuilder(@"SELECT [OpportunityId],[OpportunityNm] 
                                                   FROM [ro].[Opportunity] 
                                                   WHERE [OpportunityNm] LIKE %@OpportunityNm%");
            return context.Database.SqlQuery<Opportunity>(sb.ToString(),
                new SqlParameter("@OpportunityNm", OppNm)).ToList();
        }

        public List<string> GetOpportunityNm(string OppId)
        {
            StringBuilder sb = new StringBuilder(@"SELECT [OpportunityNm] 
                                                   FROM [ro].[Opportunity] 
                                                   WHERE [OpportunityId] = @OpportunityId");
            return context.Database.SqlQuery<string>(sb.ToString(),
                new SqlParameter("@OpportunityId", OppId)).ToList();
        }

        public bool UpdateOpportunity(Opportunity opp)
        {
            StringBuilder sb1 = new StringBuilder(@"update ro.Opportunity set 
                                                    OpportunityNm = @OpportunityNm,
                                                    OperatingUnitCd = @OperatingUnitCd,
                                                    ROStageCd = @ROStageCd,
                                                    ContractExtensionFl = @ContractExtensionFl,
                                                    ServiceGroupNm = @ServiceGroupNm,
                                                    SubCSGNm = @SubCSGNm,
                                                    ExpectContractSignQtr = @ExpectContractSignQtr,
                                                    CreateUserId = @CreateUserId,
                                                    UpdateDttm = getdate(),
                                                    ArchiveInd = @ArchiveInd 
                                                    where OpportunityId = @OpportunityId");
            var result = context.Database.ExecuteSqlCommand(sb1.ToString(),
                new SqlParameter("@OpportunityId", opp.OpportunityId),
                new SqlParameter("@OpportunityNm", opp.OpportunityNm),
                new SqlParameter("@OperatingUnitCd", opp.OperatingUnitCd),
                new SqlParameter("@ROStageCd", opp.ROStageCd),
                new SqlParameter("@ContractExtensionFl", opp.ContractExtensionFl),
                new SqlParameter("@ServiceGroupNm", opp.ServiceGroupNm),
                new SqlParameter("@SubCSGNm", opp.SubCSGNm),
                new SqlParameter("@ExpectContractSignQtr", opp.ExpectContractSignQtr),
                new SqlParameter("@CreateUserId", opp.CreateUserId),
                new SqlParameter("@ArchiveInd", opp.ArchiveInd));
            if (result > 0)
            {

                return true;
            }
            return false;
        }


    }
}