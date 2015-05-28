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
    class CBFDatabaseServices
    {
        private const string connectString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))
                                              (CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=fckj;Password=fcoracle";

        public ObservableCollection<CBFModels> GetAllCBF()
        {
            OracleConnection con = new OracleConnection(connectString);
            string sql = "SELECT * FROM CBF";
            OracleCommand cmd = new OracleCommand(sql, con);
            ObservableCollection<CBFModels> CBF = new ObservableCollection<CBFModels>();
            try
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CBFModels model = new CBFModels();
                    model.ID = reader["CBFBM"].ToString();
                    model.Name = reader["CBFMC"].ToString();
                    #region 设置证件类型枚举值
                    switch (reader["CBFZJLX"].ToString())
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
                    #region 设置承包方类型
                    switch (reader["CBFLX"].ToString()) 
                    {
                        case "1":
                            model.Type = PropertyCodeEnumModels.CBFType.PeasantHousehold;
                            break;
                        case "2":
                            model.Type = PropertyCodeEnumModels.CBFType.Personal;
                            break;
                        default: 
                            model.Type = PropertyCodeEnumModels.CBFType.WorkUnit;
                            break;
                    }
                    #endregion
                    model.CardNumber = reader["CBFZJHM"].ToString();
                    model.Tel = reader["LXDH"].ToString();
                    model.Address = reader["CBFDZ"].ToString();
                    model.PostCode = reader["YZBM"].ToString();
                    model.Claimsman = reader["CBFDCY"].ToString();
                    model.PublicDate = reader["GSSHRQ"].ToString();
                    model.SurveyDate = reader["CBFDCRQ"].ToString();
                    model.SurveyEvent = reader["CBFDCJS"].ToString();
                    model.PublicCheckPerson = reader["GSSHR"].ToString();
                    model.PublicEvent = reader["GSJS"].ToString();
                    model.PublicEventPerson = reader["GSJSR"].ToString();
                    model.MemberCount = reader["CBFCYSL"].ToString();

                    CBF.Add(model);

                }
                return CBF;
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
        public ObservableCollection<CBF_JTCYModels> GetAllFamily(CBFModels model) 
        {
            OracleConnection con = new OracleConnection(connectString);
            string sql = string.Format("SELECT * FROM CBF_JTCY WHERE CBFBM='{0}'", model.ID);
            OracleCommand cmd = new OracleCommand(sql, con);
            ObservableCollection<CBF_JTCYModels> CBF = new ObservableCollection<CBF_JTCYModels>();
            try 
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    CBF_JTCYModels CBF_JT = new CBF_JTCYModels();
                    CBF_JT.ID = reader["CBFBM"].ToString();
                    CBF_JT.Name = reader["CYXM"].ToString();
                    CBF_JT.Sex = reader["CYXB"].ToString();
                    #region 设置证件类型枚举值
                    switch (reader["CYZJLX"].ToString())
                    {
                        case "1":
                            CBF_JT.CertificateType = "身份证";
                            break;
                        case "2":
                            CBF_JT.CertificateType ="军官证";
                            break;
                        case "3":
                            CBF_JT.CertificateType ="行政企事业单位机构代码证或法人代码证";
                            break;
                        case "4":
                            CBF_JT.CertificateType = "户口簿";
                            break;
                        case "5":
                            CBF_JT.CertificateType = "护照";
                            break;
                        default:
                            CBF_JT.CertificateType = "其他";
                            break;
                    }
                    #endregion
                    CBF_JT.CardNumber = reader["CYZJHM"].ToString();
                    CBF_JT.RelationShip = reader["YHZGX"].ToString();
                    CBF_JT.Note = reader["CYBZ"].ToString();
                    CBF_JT.IsShared = reader["SFGYR"].ToString();
                    CBF.Add(CBF_JT);
                }
                return CBF;
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
        /// 新建承包方
        /// </summary>
        public void CreateCBF(CBFModels model) 
        {
            OracleConnection con = new OracleConnection(connectString);
            string sql = string.Format("insert into CBF(CBFBM,CBFLX,CBFMC,CBFZJLX,CBFZJHM,CBFDZ,YZBM,LXDH,CBFCYSL,CBFDCRQ,CBFDCY,CBFDCJS,GSJS,GSJSR,GSSHRQ,GSSHR) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',to_date('{9}','YYYYMMDD'),'{10}','{11}','{12}','{13}',to_date('{14}','YYYYMMDD'),'{15}')", model.ID, model.Type, model.Name, model.CertificateType, model.CardNumber, model.Address, model.PostCode, model.Tel, model.MemberCount, model.SurveyDate, model.Claimsman, model.SurveyEvent, model.PublicEvent, model.PublicEventPerson, model.PublicDate, model.PublicCheckPerson);
            OracleCommand cmd = new OracleCommand(sql, con);
            int count = model.Family.Count();
            
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i < count; i++)
                    {
                        string _familysql = string.Format("insert into CBF_JTCY(CBFBM,CYXM,CYXB,CYZJLX,CYZJHM,YHZGX,CYBZ,SFGYR) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", model.Family[i].ID, model.Family[i].Name, model.Family[i].Sex, model.Family[i].CertificateType, model.Family[i].CardNumber, model.Family[i].RelationShip, model.Family[i].Note, model.Family[i].IsShared);
                        OracleCommand _familycmd = new OracleCommand(_familysql, con);
                        _familycmd.ExecuteNonQuery();
                    }

                }
                catch
                {
                    MessageBox.Show("添加失败");
                }
                finally
                {
                    con.Close();
                }
        }

        public void DeleteCBF(CBFModels model) 
        {
            OracleConnection con = new OracleConnection(connectString);
            string sql = string.Format("delete from CBF where CBFBM='{0}'", model.ID);
            string sql2 = string.Format("delete from CBF_JTCY where CBFBM='{0}'", model.ID);
            OracleCommand cmd = new OracleCommand(sql, con);
            OracleCommand cmd2 = new OracleCommand(sql2, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
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
