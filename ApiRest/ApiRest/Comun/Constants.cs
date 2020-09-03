using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRest.Comun
{
    public static class Constants
    {
        public static string BaseAddress = "http://186.68.44.11:9090";
        //public static string TodoItemsUrl = BaseAddress + "/apiresttest/api/{0}/{1}/{2}";
        public static string TodoItemsUrl = BaseAddress + "/apiresttest/api/TodoItems/{0}";
    }
}
