using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Data;

namespace XamarinCRMAndroid
{
    class BLAccess
    {
        MUISAPI.ws1 objAPI = new MUISAPI.ws1();
        DataSet ds = new DataSet();

        public LoginResponse LoginAPI(string PartnerKey, string Omgevingscode)
        {
            string SessionId = "";
            string Foutmelding = "";
            LoginResponse objResponse = new LoginResponse();
            objResponse.Flag= objAPI.Login(PartnerKey, Omgevingscode, ref SessionId, ref Foutmelding);        
            objResponse.SessionId = SessionId;
            objResponse.Foutmelding = Foutmelding;
            return objResponse;
        }

        internal LogoutResponse LogoutAPI(string PartnerKey, string Omgevingscode, string SessionId)
        {

            string Foutmelding = "";
            LogoutResponse objResponse = new LogoutResponse();
            objResponse.Flag = objAPI.Logout(PartnerKey, Omgevingscode, SessionId, ref Foutmelding);
            objResponse.Foutmelding = Foutmelding;
            return objResponse;
        }

        public CreateStamTabelRecordResponse CreateStamTabelRecord(string PartnerKey, string Omgevingscode, string SessionId, DataSet Stamtabel)
        {
            DataSet Records = new DataSet();
            CreateStamTabelRecordResponse objResponse = new CreateStamTabelRecordResponse();
            string Primarykey = "";
            string Foutmelding = "";
            objResponse.Flag = objAPI.CreateStamTabelRecord(PartnerKey, Omgevingscode, SessionId, Stamtabel, ref Primarykey, ref Foutmelding);
            objResponse.Primarykey = Primarykey;
            objResponse.Foutmelding = Foutmelding;
            return objResponse;
        }

        internal GetStamTableRecordsResponse GetStamTableRecordsAPI(string PartnerKey, string Omgevingscode, string SessionId, DataSet ds_selectie)
        {
            string Foutmelding = "";
            DataSet Records = new DataSet();
            GetStamTableRecordsResponse objResponse = new GetStamTableRecordsResponse();
            objResponse.Flag = objAPI.GetStamtabelRecords(PartnerKey, Omgevingscode, SessionId, ds_selectie, ref Records, ref Foutmelding);
            objResponse.Foutmelding = Foutmelding;
            objResponse.Records = Records;
            return objResponse;
        }
    }
}