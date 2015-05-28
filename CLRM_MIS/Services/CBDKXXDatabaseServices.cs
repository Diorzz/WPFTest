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
    class CBDKXXDatabaseServices
    {
        private const string connectString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))
                                              (CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=fckj;Password=fcoracle";

        public string FindDkByCBF(string CBFID) 
        {
            OracleConnection con = new OracleConnection(connectString);
            string sql = string.Format("SELECT DKBM FROM CBDKXX WHERE CBFBM='{0}'", CBFID);
            OracleCommand cmd = new OracleCommand(sql, con);
            try
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["DKBM"].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                MessageBox.Show("系统查询出错");
                return null;
            }
            finally 
            {
                con.Close();
            }
        }

        public ObservableCollection<CBDKXXModels> GetDkByCBF(CBFModels cbf) 
        {
            OracleConnection con = new OracleConnection(connectString);
            string sql = string.Format("SELECT * FROM CBDKXX WHERE CBFBM='{0}'", cbf.ID);
            OracleCommand cmd = new OracleCommand(sql, con);
            try
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                ObservableCollection<CBDKXXModels> DK = new ObservableCollection<CBDKXXModels>();
                while (reader.Read()) 
                {
                    CBDKXXModels model = new CBDKXXModels();
                    model.DKID = reader["DKBM"].ToString();
                    model.CBFID = reader["CBFBM"].ToString();
                    model.FBFID = reader["FBFBM"].ToString();
                    model.GetWay = "其他方式";
                    model.Area = reader["HTMJ"].ToString();
                    model.ContrctID = reader["CBHTBM"].ToString();
                    model.TransContractID = reader["LZHTBM"].ToString();
                    model.RightID = reader["CBJYQZBM"].ToString();

                    DK.Add(model);
                }
                return DK;
            }
            catch
            {
                MessageBox.Show("系统查询出错");
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
