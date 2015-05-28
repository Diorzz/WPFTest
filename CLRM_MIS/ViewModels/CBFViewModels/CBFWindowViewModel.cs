using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using CLRM_MIS.Models;
using System.Collections.ObjectModel;
using CLRM_MIS.Services;
using CLRM_MIS.Common.DateConvert;

namespace CLRM_MIS.ViewModels.CBFViewModels
{
    class CBFWindowViewModel:ViewModelBase
    {
        //RadioButton命令
        public ICommand RadioButtonSelected { get; private set; }
        public ICommand AddFamily { get; private set; }
        public ICommand FamilyDelete { get; private set; }
        public ICommand Submit { get; private set; }
        public CBFWindowViewModel()
        {
            RadioButtonSelected = new DelegateCommand<RadioButton>(OnRadioButtondExecuted);
            AddFamily = new DelegateCommand<ListBox>(OnAddFamilyExecute);
            FamilyCollection = new ObservableCollection<CBF_JTCYModels>();
            FamilyDelete = new DelegateCommand<CBF_JTCYModels>(OnFamilyDeleteExecuted);
            Submit = new DelegateCommand(OnSubmitExcuted);
        }

        private void OnSubmitExcuted() 
        {
            FormatDate fd = new FormatDate();
            if (CBFBM != null & CBFLX != null & CBFDB != null & CardType != null & CardID != null & Address != null & PostCode != null & Tel != null & FamilyCount != null & CBFDCRQ != null & CBFDCY != null & CBFDCJS != null & GSJS != null & GSJSR != null & GSSHRQ != null & GSSHR != null)
            {
                CBFModels _CBF = new CBFModels();
                _CBF.ID = CBFBM;
                _CBF.Name = CBFDB;
                _CBF.CardNumber = CardID;
                _CBF.Address = Address;
                // _CBF.CertificateType = CBFLX;
                _CBF.Claimsman = CBFDCY;
                _CBF.MemberCount = FamilyCount;
                _CBF.PublicEvent = GSJS;
                _CBF.PublicEventPerson = GSJSR;
                _CBF.SurveyDate = fd.GetFormatedDate(CBFDCRQ);
                _CBF.SurveyEvent = CBFDCJS;
                _CBF.PublicCheckPerson = GSSHR;
                _CBF.Tel = Tel;
                _CBF.PublicDate = fd.GetFormatedDate(GSSHRQ);
                _CBF.PostCode = PostCode;
                _CBF.Family = FamilyCollection;

                CBFDatabaseServices db = new CBFDatabaseServices();
                db.CreateCBF(_CBF);
                CBFBM = null;
                CBFDB = null;
                CardID = null;
                Address = null;
                CBFDCY = null;
                FamilyCount = null;
                GSJS = null;
                GSJSR = null;
                CBFDCRQ = null;
                CBFDCJS = null;
                GSSHR = null;
                Tel = null;
                GSSHRQ = null;
                PostCode = null;
                FamilyCollection = null;
            }
            else 
            {
                MessageBox.Show("表单数据未填写完整或格式不正确，请检查后再试");
            }
        }
        /// <summary>
        /// 添加承包方家庭成员
        /// </summary>
        public void OnFamilyDeleteExecuted(CBF_JTCYModels model) 
        {
            FamilyCollection.Remove(model);
        }
        private void OnAddFamilyExecute(ListBox list) 
        {
            if (FamilyName != null & FamilyCardID != null & FamilyMark != null & FamilyRelationship != null&CBFBM!=null)
            {
                CBF_JTCYModels Family = new CBF_JTCYModels();
                Family.ID = CBFBM;
                Family.Name = FamilyName;
                if (FamilySex == "男")
                {
                    Family.Sex = "1";
                }
                else 
                {
                    Family.Sex = "2";
                }
                
               // Family.CertificateType = PropertyCodeEnumModels.CertificateType.IDCard;
                #region 设置证件类型枚举值
                switch (CardType)
                {
                    case "身份证":
                        Family.CertificateType = "1";
                        break;
                    case "军官证":
                        Family.CertificateType = "2";
                        break;
                    case "行政企事业单位机构代码证或法人代码证":
                        Family.CertificateType = "3";
                        break;
                    case "户口簿":
                        Family.CertificateType = "4";
                        break;
                    case "护照":
                        Family.CertificateType = "5";
                        break;
                    default:
                        Family.CertificateType = "其他";
                        break;
                }
                #endregion
                //Family.CertificateType = CardType;
                Family.CardNumber = FamilyCardID;
                Family.RelationShip = FamilyRelationship;
                Family.Note = FamilyMark;
                Family.IsShared = SFGYR;

                FamilyCollection.Add(Family);
                FamilyCardID = null;
                FamilyMark = null;
                FamilyName = null;
                FamilySex = null;
                FamilyRelationship = null;
                
            }
            else 
            {
                MessageBox.Show("天剑出错，请检查表单数据的完整性与正确性");
            }
        }
        /// <summary>
        /// 验证表单的RadioButton
        /// </summary>
        /// <param name="radiobutton">相应RadioButoon的示例</param>
        public void OnRadioButtondExecuted(RadioButton radiobutton)
        {
            if ((radiobutton.Content).ToString() == "有" && radiobutton.Name == "YWCBHEY" && radiobutton.IsChecked == true) 
            {
                this.HasContract = true;
            }
            if ((radiobutton.Content).ToString() == "无" && radiobutton.Name == "YWCBHEN" && radiobutton.IsChecked == true)
            {
                this.HasContract = false;
            }
            if ((radiobutton.Content).ToString() == "有" && radiobutton.Name == "YWJYQZY" && radiobutton.IsChecked == true) 
            {
                this.HasJYQZ = true;
            }
            if ((radiobutton.Content).ToString() == "无" && radiobutton.Name == "YWJYQZN" && radiobutton.IsChecked == true)
            {
                this.HasJYQZ = false;
            }
            if ((radiobutton.Content).ToString() == "家庭承包" && radiobutton.Name == "JTCB" && radiobutton.IsChecked == true)
            {
                this.TDHDFS = "家庭承包";
            }
            if ((radiobutton.Content).ToString() == "竞标" && radiobutton.Name == "JB" && radiobutton.IsChecked == true)
            {
                this.TDHDFS = "竞标";
            }
            if ((radiobutton.Content).ToString() == "公开协商" && radiobutton.Name == "GKXS" && radiobutton.IsChecked == true)
            {
                this.TDHDFS = "公开协商";
            }
            if ((radiobutton.Content).ToString() == "拍卖" && radiobutton.Name == "PM" && radiobutton.IsChecked == true)
            {
                this.TDHDFS = "拍卖";
            }
            if ((radiobutton.Content).ToString() == "转让" && radiobutton.Name == "ZR" && radiobutton.IsChecked == true)
            {
                this.TDHDFS = "转让";
            }
            if ((radiobutton.Content).ToString() == "互换" && radiobutton.Name == "HH" && radiobutton.IsChecked == true)
            {
                this.TDHDFS = "互换";
            }
            if ((radiobutton.Content).ToString() == "其他" && radiobutton.Name == "QTT" && radiobutton.IsChecked == true)
            {
                this.TDHDFS = "其他";
            }
            if ((radiobutton.Content).ToString() == "身份证" && radiobutton.Name == "SFZ" && radiobutton.IsChecked == true)
            {
                this.CardType = "身份证";
            }
            if ((radiobutton.Content).ToString() == "军官证" && radiobutton.Name == "JGZ" && radiobutton.IsChecked == true)
            {
                this.CardType = "军官证";
            }
            if ((radiobutton.Content).ToString() == "护照" && radiobutton.Name == "HZ" && radiobutton.IsChecked == true)
            {
                this.CardType = "护照";
            }
            if ((radiobutton.Content).ToString() == "是" && radiobutton.Name == "SFGYRY" && radiobutton.IsChecked == true)
            {
                this.SFGYR = "1";
            }
            if ((radiobutton.Content).ToString() == "否" && radiobutton.Name == "SFGYRN" && radiobutton.IsChecked == true)
            {
                this.SFGYR = "2";
            }
            if ((radiobutton.Content).ToString() == "农户" && radiobutton.Name == "CBFLXN" && radiobutton.IsChecked == true)
            {
                this.CBFLX = "农户";
            }
            if ((radiobutton.Content).ToString() == "单位" && radiobutton.Name == "CBFLXD" && radiobutton.IsChecked == true)
            {
                this.CBFLX = "单位";
            }
            if ((radiobutton.Content).ToString() == "个人" && radiobutton.Name == "CBFLXG" && radiobutton.IsChecked == true)
            {
                this.CBFLX = "个人";
            }
        }
        //承包方编码
        public string CBFBM 
        {
            get { return GetProperty(() => CBFBM); }
            set { SetProperty(() => CBFBM, value); }
        }
        //承包方类型
        public string CBFLX 
        {
            get { return GetProperty(() => CBFLX); }
            set { SetProperty(() => CBFLX, value); }
        }
        //承包方成员数量
        public string CYSL 
        {
            get { return GetProperty(() => CYSL); }
            set { SetProperty(() => CYSL, value); }
        }
        //承包方调查日期
        public string CBFDCRQ 
        {
            get { return GetProperty(() => CBFDCRQ); }
            set { SetProperty(() => CBFDCRQ, value); }
        }
        //承包方调查员
        public string CBFDCY 
        {
            get { return GetProperty(() => CBFDCY); }
            set { SetProperty(() => CBFDCY, value); }
        }
        //承包方调查记事
        public string CBFDCJS 
        {
            get { return GetProperty(() => CBFDCJS); }
            set { SetProperty(() => CBFDCJS, value); }
        }
        //公示记事
        public string GSJS 
        {
            get { return GetProperty(() => GSJS); }
            set { SetProperty(() => GSJS, value); }
        }
        //公示记事人
        public string GSJSR 
        {
            get { return GetProperty(() => GSJSR); }
            set { SetProperty(() => GSJSR, value); }
        }
        //公示审核日期
        public string GSSHRQ 
        {
            get { return GetProperty(() => GSSHRQ); }
            set { SetProperty(() => GSSHRQ, value); }
        }
        //公示审核人
        public string GSSHR 
        {
            get { return GetProperty(() => GSSHR); }
            set { SetProperty(() => GSSHR, value); }
        }
        //发包方编码
        public string FBFBM
        {
            get { return GetProperty(() => FBFBM); }
            set { SetProperty(() => FBFBM, value); }
        }
        //承包方代表
        public string CBFDB
        {
            get { return GetProperty(() => CBFDB); }
            set { SetProperty(() => CBFDB, value); }
        }
        //联系电话
        public string Tel
        {
            get { return GetProperty(() => Tel); }
            set { SetProperty(() => Tel, value); }
        }
        //承包方地址
        public string Address
        {
            get { return GetProperty(() => Address); }
            set { SetProperty(() => Address, value); }
        }
        //邮政编码
        public string PostCode
        {
            get { return GetProperty(() => PostCode); }
            set { SetProperty(() => PostCode, value); }
        }
        //证件编号
        public string CardID
        {
            get { return GetProperty(() => CardID); }
            set { SetProperty(() => CardID, value); }
        }
        //是否有合同
        public bool HasContract
        {
            get { return GetProperty(() => HasContract); }
            set { SetProperty(() => HasContract, value); }
        }
        //是否有经营权证
        public bool HasJYQZ 
        {
            get { return GetProperty(() => HasJYQZ); }
            set { SetProperty(() => HasJYQZ, value); }
        }
        //土地获得方式
        public string TDHDFS 
        {
            get { return GetProperty(() => TDHDFS); }
            set { SetProperty(() => TDHDFS,value); }
        }
        //承包方证件类型
        public string CardType 
        {
            get { return GetProperty(() => CardType); }
            set { SetProperty(() => CardType, value); }
        }
        //合同编码
        public string ContractID 
        {
            get { return GetProperty(() => ContractID); }
            set { SetProperty(() => ContractID, value); }
        }
        //经营权证编号
        public string JYQZID
        {
            get { return GetProperty(() => JYQZID); }
            set { SetProperty(() => JYQZID, value); }
        }
        //承包期限
        public string CBQX
        {
            get { return GetProperty(() => CBQX); }
            set { SetProperty(() => CBQX, value); }
        }
        //家庭成员总数
        public string FamilyCount
        {
            get { return GetProperty(() => FamilyCount); }
            set { SetProperty(() => FamilyCount, value); }
        }

        public ObservableCollection<CBF_JTCYModels> FamilyCollection 
        {
            get { return GetProperty(() => FamilyCollection); }
            set { SetProperty(() => FamilyCollection, value); }
        }
        public string FamilyName
        {
            get { return GetProperty(() => FamilyName); }
            set { SetProperty(() => FamilyName, value); }
        }
        public string FamilyRelationship
        {
            get { return GetProperty(() => FamilyRelationship); }
            set { SetProperty(() => FamilyRelationship, value); }
        }
        public string FamilyCardID
        {
            get { return GetProperty(() => FamilyCardID); }
            set { SetProperty(() => FamilyCardID, value); }
        }
        public string FamilyMark
        {
            get { return GetProperty(() => FamilyMark); }
            set { SetProperty(() => FamilyMark, value); }
        }
        public string FamilySex
        {
            get { return GetProperty(() => FamilySex); }
            set { SetProperty(() => FamilySex, value); }
        }
        public string SFGYR 
        {
            get { return GetProperty(() => SFGYR); }
            set { SetProperty(() => SFGYR, value); }
        }
    
    }
}
