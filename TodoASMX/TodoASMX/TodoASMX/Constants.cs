using System;
using System.Collections.Generic;
using System.Text;

namespace TodoASMX
{
    public partial class Constants
    {
        //URL del asmx
        public static string SoapUrl
        {
            get
            {
                var defaultUrl = "http://186.68.44.11:9090/asmxservices/TodoServices.asmx";

                return defaultUrl;

            }
        }
    }
}
