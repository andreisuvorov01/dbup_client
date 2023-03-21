using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolClassDb.DB
{
    public static class DbStorage
    {
       public static UPDBEntities DB_S { get; set; } = new UPDBEntities();
    }
}
