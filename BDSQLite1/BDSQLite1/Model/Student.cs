using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace BDSQLite1.Model
{
   
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int stdid { get; set; }
        [NotNull]
        public string stdname { get; set; }
        [NotNull]
        public string stdcourse { get; set; }
        public string stdlevel { get; set; }
    }
}
