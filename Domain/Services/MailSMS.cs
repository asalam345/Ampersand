using Domain.Handlers;
using RapidFireLib.Lib.Core;
using RapidFireLib.Models.Messaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class MailSMS
    {
        public async Task<bool> SendMail(string mailTo, string subject, string body, RapidFire rf, bool isSignature = true)
        {
            string signature = isSignature ? EmailSignature() : string.Empty;
            EmailParams emailParams = new EmailParams();
            emailParams.To = mailTo;
            emailParams.Subject = subject;
            emailParams.Body = body + signature;

            try
            {
                var result = await rf.Messaging.Email.Send(emailParams);
                return result.Successful;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public string EmailSignature()
        {
            string signature = "";
            signature += "<br /><span style=\"font-family:Arial;font-size:12px;\"><b>" + "GlideGo SERVICE" +
                "</b>|<span style=\"color: red;\"> Save the Children in Bangladesh</span> | " +
                "<br />House CWN (A) 35, Road 43, Gulshan 2, Dhaka 1212, Bangladesh <br />";
            signature += " https://bangladesh.savethechildren.net/<br />";
            signature += @"Tel: +88-02-882 8081, Ext. 1065 | Fax: +88-02-881 2523 <br /></span>";
            return signature;
        }
        public async Task<bool> SendSMS(List<string> sendToList, string sMessage)
        {
            string responseString = "";
            try
            {

                NewSMSAPI data = new NewSMSAPI()
                {
                    username = "savechild_v2",
                    password = "Good4BL@SMS1!@#",
                    apicode = "5",
                    msisdn = sendToList,
                    countrycode = "880",
                    cli = "8801969977776",
                    messagetype = "1",
                    message = sMessage.Replace('#', ':'),
                    clienttransid = Guid.NewGuid().ToString().Replace("-", ""),
                    bill_msisdn = "8801969977776",
                    tran_type = "T",
                    request_type = "S",
                    rn_code = "91"
                };

                ApiService apiService = new ApiService();
                var result = await apiService.PostDataAsync("https://corpsms.banglalink.net/bl/api/v1/smsapigw/", data, null, null, 3, 2, true);

                if (result.IsSuccessStatusCode)
                {
                    responseString = await result.Content.ReadAsStringAsync();
                    return true;
                }
                else
                {
                    responseString = $"Error: {result.StatusCode}";
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

    }
    public class NewSMSAPI
    {
        public string username { get; set; }
        public string password { get; set; }
        public string apicode { get; set; }
        public string countrycode { get; set; }
        public string cli { get; set; }
        public string messagetype { get; set; }
        public string message { get; set; }
        public string clienttransid { get; set; }
        public string bill_msisdn { get; set; }
        public string tran_type { get; set; }
        public string request_type { get; set; }
        public string rn_code { get; set; }
        public List<string> msisdn { get; set; }
    }
}
