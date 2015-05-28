using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLRM_MIS.Models;
using Oracle.DataAccess.Client;
using System.Data;
using System.Windows;
using System.Collections.ObjectModel;

namespace CLRM_MIS.Services
{
    class InsertDbTest
    {
        private const string connectString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))
                                              (CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=fckj;Password=fcoracle";

        public void Insert(int i) 
        {
            OracleConnection con = new OracleConnection(connectString);
            try
            {
                
                string sql = "INSERT INTO CBF(CBFBM,CBFLX,CBFMC,CBFZJLX,CBFZJHM,CBFDZ,YZBM,LXDH,CBFCYSL,CBFDCRQ,CBFDCY,CBFDCJS,GSJS,GSJSR,GSSHRQ,GSSHR) VALUES('510008749451" + i.ToString() + "','1','李天天','1','255422154304218851','辽宁省葫芦岛市兴城市四家村2组120号','125105','18242981546',3,to_date('20150420','YYYYMMDD'),'张大壮','承包土地10亩，旱田，种苞米喂驴','公示记事：是什么东西','征哥',to_date('20140501','YYYYMMDD'),'赵征')";
                OracleCommand cmd = new OracleCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { con.Close(); }
            
        }
        public int count;
        public int Count { get; private set; }
        public void CountNum() 
        {
            OracleConnection con = new OracleConnection(connectString);
            try
            {

                string sql = "select count(*) as num from CBF";
                OracleCommand cmd = new OracleCommand(sql, con);
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) 
                {
                    this.Count = int.Parse(reader["num"].ToString());
                }
                
            }
            catch { }
            finally { con.Close(); }
        }
    }
}
