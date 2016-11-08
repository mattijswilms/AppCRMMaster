using System.Data;

namespace XamarinCRMAndroid
{
    public class GetStamTableRecordsResponse
    {

        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public bool Flag { get; set; }
        public string Foutmelding { get; set; }
        public DataSet Records { get; set; }
    }
}