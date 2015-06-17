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

         public static void clickButtonByTextOCR(RemoteWebDriver wd , String text, TestContext context)
         {

             Console.WriteLine(" ***  =>  " );
             String   command = "mobile:button-text:click";
             Dictionary<string, string> param = new Dictionary<string, string>();
             param.Add("label", "Advance");
             param.Add("timeout", "30");
              string result = (string)wd.ExecuteScript(command, param);
             Console.WriteLine(" result =>  " + result);
        }
        

        public static void swipeUp(RemoteWebDriver wd , String text, TestContext context)
         {
             command = "mobile:touch:swipe";
             param = new Dictionary<string, string>();
             param.Add("start", "50%,85%");
             param.Add("end", "50%,10%");
             result = (string)wd.ExecuteScript(command, param);
         }
         
         public static void swipeDown(RemoteWebDriver wd , String text, TestContext context)
         {
             command = "mobile:touch:swipe";
             param = new Dictionary<string, string>();
             param.Add("start", "50%,15%");
             param.Add("end", "50%,80%");
             result = (string)wd.ExecuteScript(command, param);
         }
        
        public static void buttonClick(RemoteWebDriver wd , String text, TestContext context)
        {
             command = "mobile:button-text:click";
             param = new Dictionary<string, string>();
             param.Add("label", text);
             param.Add("timeout", "30");

             result = (string)wd.ExecuteScript(command, param);
        }
    
        public static void vnetwork(RemoteWebDriver wd ,TestContext context)
         {
             command = "mobile:vnetwork:start";
             param = new Dictionary<string, string>();
             param.Add("profile", "4g_lte_poor");

            result = (string)wd.ExecuteScript(command, param);
        }

     }
}
