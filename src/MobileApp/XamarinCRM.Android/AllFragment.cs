using Android.OS;
using Android.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data;
using XamarinCRMAndroid.MUISAPI;
using System;

namespace XamarinCRMAndroid
{
    public class AllFragment : Android.Support.V4.App.Fragment, ISupportInitialize
    {
        View view;
        Android.Widget.ListView allList;
        MUISAPI.ws1 objAPI = new ws1();
        DataSet ds;
        string PartnerKey = "abcdefghijklmnopqrstuvwxyz";
        string Omgevingscode = "00000";
        string SessionId = null;
        BLAccess ObjBL = new BLAccess();
        List<Post> items;
        DataSet ds_mutatie = new DataSet();
        DataSet ds_selectie;
        DataTable dt_selectie;

        private LoginResponse Login()
        {

            LoginResponse objResponse = new LoginResponse();
            objResponse = ObjBL.LoginAPI(PartnerKey, Omgevingscode);
            return objResponse;

        }

        private LogoutResponse Logout(string SeesionId)
        {
            LogoutResponse objResponse = new LogoutResponse();
            objResponse = ObjBL.LogoutAPI(PartnerKey, Omgevingscode, SeesionId);
            return objResponse;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Create your fragment here
        }

        public OperationResponse CreateStamTabelRecord(DataSet ds_mutatie)
        {
            OperationResponse obj = new OperationResponse();
            try
            {
                CreateStamTabelRecordResponse objResponse = new CreateStamTabelRecordResponse();
                LoginResponse loginResponse = new LoginResponse();
                loginResponse = Login();
                if (loginResponse.Flag == true)
                {
                    // objResponse = ObjBL.CreateStamTabelRecord(PartnerKey, Omgevingscode, loginResponse.SessionId, ds_mutatie);
                    LogoutResponse logoutResponse = new LogoutResponse();
                    logoutResponse = Logout(loginResponse.SessionId);
                    obj.ResponseCode = 1;
                    obj.ResponseMessage = "Suucess";
                    GetStamTableRecords();
                }
                else
                {
                    obj.ResponseCode = 0;
                    obj.ResponseMessage = "Login Failed.";
                }
            }
            catch
            {
                obj.ResponseCode = 2;
                obj.ResponseMessage = "Bad Request.";
            }
            return obj;

        }

        public OperationResponse GetStamTableRecords()
        {
            OperationResponse obj = new OperationResponse();
            try
            {
                char TAB = (char)9;
                ds = new DataSet();
                ds_selectie = new DataSet();
                dt_selectie = new DataTable();
                /*   dt_selectie.Rows.Add();
                   dt_selectie.Columns.Add("TABLE", typeof(System.String));
                   dt_selectie.Rows[0]["TABLE"] = "DEB";
                   dt_selectie.Columns.Add("SELECTFIELDS", typeof(System.String));
                   dt_selectie.Rows[0]["SELECTFIELDS"] = "*";
                   dt_selectie.Columns.Add("WHEREFIELDS", typeof(System.String));
                   dt_selectie.Rows[0]["WHEREFIELDS"] = "NR";
                   dt_selectie.Columns.Add("WHEREOPERATORS", typeof(System.String));
                   dt_selectie.Rows[0]["WHEREOPERATORS"] = "=";
                   dt_selectie.Columns.Add("WHEREVALUES", typeof(System.String));
                   dt_selectie.Rows[0]["WHEREVALUES"] = "1000";
                   dt_selectie.Columns.Add("ORDERBY", typeof(System.String));
                   dt_selectie.Rows[0]["ORDERBY"] = "NR";
                   dt_selectie.Columns.Add("MAXRESULT", typeof(System.Int32));
                   dt_selectie.Rows[0]["MAXRESULT"] = 0;
                   dt_selectie.Columns.Add("PAGESIZE", typeof(System.Int32));
                   dt_selectie.Rows[0]["PAGESIZE"] = 20;
                   dt_selectie.Columns.Add("SELECTPAGE", typeof(System.Int32));
                   dt_selectie.Rows[0]["SELECTPAGE"] = 1;
                   ds_selectie.Tables.Add(dt_selectie);*/

                DataTable dt = new DataTable();
                DataRow dr = null;

                dt.Columns.Add(new DataColumn("TABLE", typeof(string)));
                dt.Columns.Add(new DataColumn("SELECTFIELDS", typeof(string)));//for TextBox value   
                dt.Columns.Add(new DataColumn("WHEREFIELDS", typeof(string)));//for TextBox value   
                dt.Columns.Add(new DataColumn("WHEREOPERATORS", typeof(string)));
                dt.Columns.Add(new DataColumn("WHEREVALUES", typeof(string)));
                dt.Columns.Add(new DataColumn("ORDERBY", typeof(string)));
                dt.Columns.Add(new DataColumn("MAXRESULT", typeof(int)));
                dt.Columns.Add(new DataColumn("PAGESIZE", typeof(int)));
                dt.Columns.Add(new DataColumn("SELECTPAGE", typeof(int)));

            dr = dt.NewRow();

                dr["TABLE"] = "DEB";
                dr["SELECTFIELDS"] = "*";
                dr["WHEREFIELDS"] = "NR";
                dr["WHEREOPERATORS"] = "=";
                dr["WHEREVALUES"] = "1000";
                dr["ORDERBY"] = "NR";
                dr["MAXRESULT"] = 0;
                dr["PAGESIZE"] = 20;
                dr["SELECTPAGE"] = 1;
                dt.Rows.Add(dr);
                ds_selectie.Tables.Add(dt);

                int count = dt.Columns.Count;



                GetStamTableRecordsResponse objResponse = new GetStamTableRecordsResponse();
                LoginResponse loginResponse = new LoginResponse();
                loginResponse = Login();
                if (loginResponse.Flag == true)
                {
                    objResponse = ObjBL.GetStamTableRecordsAPI(PartnerKey, Omgevingscode, loginResponse.SessionId, ds_selectie);
                    string ans = objResponse.Records.ToString();
                    LogoutResponse logoutResponse = new LogoutResponse();
                    logoutResponse = Logout(loginResponse.SessionId);
                    // ContactOpetaionCRM crm = new ContactOpetaionCRM();
                    // obj = crm.AddContact(objResponse.Records);
                }
                else
                {
                    obj.ResponseCode = 0;
                    obj.ResponseMessage = "Login Failed.";
                }
            }
            catch
            {
                obj.ResponseCode = 2;
                obj.ResponseMessage = "Bad Request.";
            }
            return obj;
        }

      void ISupportInitialize.BeginInit()
           {
               ds_selectie = new DataSet();
               dt_selectie = new DataTable();
        
           }  

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);


            view = inflater.Inflate(Resource.Layout.AllFragmentLayout, container, false);
            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            CreateStamTabelRecord(ds_mutatie);

            allList = view.FindViewById<Android.Widget.ListView>(Resource.Id.ListView);
            items = new List<Post>();

            for (int i = 0; i < 3; i++)
            {
                Post postitem = new Post();
                /*  postitem.setInvoice("1");
                  postitem.getinvoice();
                  postitem.setname("saumya");
                  postitem.getname();
                  postitem.setnumber("12345");
                  postitem.getnumber();
                  postitem.setaddress("aaa");
                  postitem.getaddress();
                 */

                postitem.name = "saumya" + i;
                postitem.invoicdid = "" + i;
                postitem.Phonenumber = "12345";
                postitem.address = "address " + i;
                items.Add(postitem);

            }
            allList.Adapter = new CusotmListAdapter(this.Activity, items);

        }

        public void EndInit()
        {
            throw new NotImplementedException();
        }
    }

}

