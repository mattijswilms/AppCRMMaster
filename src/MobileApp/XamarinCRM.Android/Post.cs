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

namespace XamarinCRMAndroid
{
  public  class Post
    {
        public string invoicdid { get; set; }
        public string name { get; set; }
        public string Phonenumber { get; set; }
        public string address { get; set; }

        public void setInvoice(string invoice)
        {
            invoicdid = invoice;
           // return invoicdid;
        }

        public string getinvoice()
        {
           return invoicdid;
        }

        public void setname(string Name)
        {
            name = Name;
        }

        public string getname()
        {
            return name;
        }

        public void setnumber(string number)
        {
            Phonenumber = number;
        }

        public string getnumber()
        {
            return Phonenumber;
        }

        public void setaddress(string Address)
        {
            address = Address;
        }

        public string getaddress()
        {
            return address;
        }
    }
}