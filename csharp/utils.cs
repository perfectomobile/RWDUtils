using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using OpenQA.Selenium.Remote;
namespace UnitTestProject2
{
    class testsUtils
    {
         public static void DownloadReport(String rep, String host, String password, String user, TestContext context, String format = "pdf")
         {

             String prefix = rep.Replace(":", "_");
             prefix = prefix.Replace("/", "_");
             prefix = prefix.Replace(".xml", "");
              String cmd = "https://" + host + "/services/reports/" + rep + "?operation=download&user=" + user + "&password=" + password + "&format=" + format;
                 using (WebClient Client = new WebClient())
                {
                    string name = "c:\\test\\repC##_" + prefix + "." + format;
                    Client.DownloadFile(cmd, @name);
                    context.AddResultFile(name);

                }

         }

         public static void manageCerAndroid(RemoteWebDriver wd , String device, TestContext context)
         {

             Console.WriteLine(" ***  =>  " );
             String   command = "mobile:button-text:click";
             Dictionary<string, string> param = new Dictionary<string, string>();
             param.Add("DUT", device);
             param.Add("label", "Advance");
             param.Add("timeout", "30");

             Console.WriteLine(" ***  => 2 ");
             string result = (string)wd.ExecuteScript(command, param);
             Console.WriteLine(" result =>  " + result);

             command = "mobile:touch:swipe";
             param = new Dictionary<string, string>();
             param.Add("DUT", device);
             param.Add("start", "50%,85%");
             param.Add("end", "50%,10%");
             result = (string)wd.ExecuteScript(command, param);


             command = "mobile:button-text:click";
             param = new Dictionary<string, string>();
             param.Add("DUT", device);
             param.Add("label", "unsafe");
             param.Add("timeout", "30");

             result = (string)wd.ExecuteScript(command, param);


             command = "mobile:vnetwork:start";
             param = new Dictionary<string, string>();
             param.Add("profile", "4g_lte_poor");

            result = (string)wd.ExecuteScript(command, param);
 
 
         }

     }
}
