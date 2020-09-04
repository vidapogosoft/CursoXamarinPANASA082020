using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRest.Comun
{
    public static class Constants
    {
        public static string BaseAddress = "http://192.168.0.127";
        //public static string TodoItemsUrl = BaseAddress + "/apiresttest/api/{0}/{1}/{2}";
        public static string TodoItemsUrl = BaseAddress + "/todoitems/api/TodoItems/{0}";

        public static string TodoItemsUrlA = BaseAddress + "/todoitems/api/Caja/{0}";
        public static string TodoItemsUrlB = BaseAddress + "/todoitems/api/Bodega/{0}";
        public static string TodoItemsUrlC = BaseAddress + "/todoitems/api/Inventario/{0}/{1}/{2}";

    }
}
