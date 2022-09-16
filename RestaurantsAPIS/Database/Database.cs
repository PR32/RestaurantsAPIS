using Microsoft.AspNetCore.Http;
using System;
using System.Configuration;
//using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


/// <summary>
/// Summary description for Database
/// </summary>
/// 
namespace RestaurantsAPIS.Database
{
    public class Database
    {
        //public string strConnectForLogin { get; set; }
        //private readonly ILoginService _loginService;
        //private IConfiguration _configuration;
        public Database(
            //ILoginService loginService
            //, IConfiguration configuration
            )
        {
            //_loginService = loginService;
            //_configuration = configuration;
            //strConnectForLogin = Convert.ToString(Startup.MasterDBConnectionString);
        }

        //public SqlConnection Getconnection()
        //{
        //    //string strConnection = strConnectForLogin;
        //    string strSession = Convert.ToString(APISession.Client_ID);

        //    if (!string.IsNullOrEmpty(strSession))
        //    {
        //        string connClientDb = string.Empty;
        //        var Client_Details = _loginService.Get_Client_DB_Detail(APISession.Client_ID);
        //        if (Client_Details != null)
        //        {
        //            string[] stArrDBConn = new string[]
        //            {
        //                    Client_Details.nvarServer_Name,
        //                    Client_Details.nvarDatabase_Name,
        //                    Client_Details.nvarDBUser_Name,
        //                    Client_Details.nvarDBPassword
        //            };
        //            connClientDb = string.Format(_configuration["ConnectionStrings:CLIENTDB"], stArrDBConn);
        //            Startup.ClientDBConnectionString = connClientDb;
        //        }

        //        //SqlConnection conn = new SqlConnection(strConnectForLogin);
        //        //Cloud_Client_Details Cloud_Client_Details = new Cloud_Client_Details();
        //        //var ClientStore = Cloud_Client_Details.GetDataBaseInfoUsingClientIDForConn(Convert.ToString(strSession), conn);
        //        //if (ClientStore != null)
        //        //{
        //        //    StringBuilder strCon = new StringBuilder();
        //        //    strCon.Append("data source=");
        //        //    strCon.Append(ClientStore.nvarServer_Name);
        //        //    strCon.Append(";initial catalog=");
        //        //    strCon.Append(ClientStore.nvarDatabase_Name);
        //        //    strCon.Append(";persist security info=True;user id=");
        //        //    strCon.Append(ClientStore.nvarDBUser_Name);
        //        //    strCon.Append(";password=");
        //        //    strCon.Append(Cryptography.DecryptionWithStaticKey(ClientStore.nvarDBPassword));
        //        //    strCon.Append(";MultipleActiveResultSets=False;");
        //        //    //ErrorLogger.WriteOtherLog("Connection String: -" + Convert.ToString(strCon));
        //        //    strConnection = strCon.ToString();
        //        //}
        //    }
        //    SqlConnection sqlConnection = new SqlConnection(Startup.ClientDBConnectionString);
        //    return sqlConnection;
        //}

        //public SqlConnection GetconnectionForLogin()
        //{
        //    SqlConnection sqlConnection = new SqlConnection(strConnectForLogin);
        //    return sqlConnection;
        //}

        
    }
}

