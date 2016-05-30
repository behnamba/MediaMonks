using PlanDay.Assignment.Common.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanDay.Assignment.Web.Helper
{
    public class Logger
    {
        public const string FileName = "log.txt";


        public static string ReadLog(IPathMapper pathMapper)
        {
            string path = string.Format("{0}\\{1}", pathMapper.MapPath("~/App_Data"), FileName);

            string content = Common.IO.FileHelper.ReadFile(path);
            Common.IO.FileHelper.Delete(path);
            return content;
        }
    }
}