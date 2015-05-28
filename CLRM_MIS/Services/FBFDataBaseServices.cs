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
    class FBFDataBaseServices
    {
        private const string connectString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))
                                              (CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=fckj;Password=fcoracle";

        /// <summary>
        /// 获取所有发包方信息
        /// </summary>
        /// <returns>发包方类List集合</returns>
        public ObservableCollection<FBFModels> GetAllFBF() 
        {
            OracleConnection con = new OracleConnection(connectString);
            string sql="SELECT * FROM FBF";
            OracleCommand cmd = new OracleCommand(sql, con);
            ObservableCollection<FBFModels> FBF = new ObservableCollection<FBFModels>();
            try
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FBFModels model = new FBFModels();
                    model.ID = reader["FBFBM"].ToString();
                    model.Name = reader["FBFMC"].ToString();
                    model.ManagerName = reader["FBFFZRXM"].ToString();
                    #region 设置证件类型枚举值
                    switch (reader["FZRZJLX"].ToString())
                    {
                        case "1":
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.IDCard;
                            break;
                        case "2":
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.OfficerCard;
                            break;
                        case "3":
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.AdminCode;
                            break;
                        case "4":
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.ResidenceBooklet;
                            break;
                        case "5":
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.Passport;
                            break;
                        default:
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.OtherCard;
                            break;
                    }
                    #endregion
                    model.CertificateNumber = reader["FZRZJHM"].ToString();
                    model.Tel = reader["LXDH"].ToString();
                    model.Address = reader["FBFDZ"].ToString();
                    model.PostCode = reader["YZBM"].ToString();
                    model.Claimsman = reader["FBFDCY"].ToString();
                    model.Date = reader["FBFDCRQ"].ToString();
                    model.Event = reader["FBFDCJS"].ToString();

                    FBF.Add(model);

                }
                return FBF;
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
        /// <summary>
        /// 通过ID查找发包方
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>发包方单一</returns>
        public FBFModels GetFBFByID(string ID) 
        {
            OracleConnection con = new OracleConnection(connectString);
            string sql = string.Format("SELECT * FROM FBF WHERE FBFBM='{0}'", ID);
            OracleCommand cmd = new OracleCommand(sql, con);
            FBFModels model = new FBFModels();
            try
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    model.ID = reader["FBFBM"].ToString();
                    model.Name = reader["FBFMC"].ToString();
                    model.ManagerName = reader["FBFFZRXM"].ToString();
                    #region 设置证件枚举
                    switch (reader["FZRZJLX"].ToString())
                    {
                        case "1":
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.IDCard;
                            break;
                        case "2":
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.OfficerCard;
                            break;
                        case "3":
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.AdminCode;
                            break;
                        case "4":
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.ResidenceBooklet;
                            break;
                        case "5":
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.Passport;
                            break;
                        default:
                            model.CertificateType = PropertyCodeEnumModels.CertificateType.OtherCard;
                            break;
                    }
                    #endregion
                    model.CertificateNumber = reader["FZRZJHM"].ToString();
                    model.Tel = reader["LXDH"].ToString();
                    model.Address = reader["FBFDZ"].ToString();
                    model.PostCode = reader["YZBM"].ToString();
                    model.Claimsman = reader["FBFDCY"].ToString();
                    model.Date = reader["FBFDCRQ"].ToString();
                    model.Event = reader["FBFDCJS"].ToString();

                }
                else 
                {
                    MessageBox.Show("没有此发包方");
                    return null;
                }
                return model;
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
        /// <summary>
        /// 删除发包方
        /// </summary>
        /// <param name="ID"></param>
        public void RemoveFBFByID(FBFModels fbf) 
        {
            OracleConnection con = new OracleConnection(connectString);
            string sql = string.Format("DELETE FROM FBF WHERE FBFBM='{0}'", fbf.ID);
            OracleCommand cmd = new OracleCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("删除失败");
            }
            finally 
            {
                con.Close();
            }
        }
    }
}
