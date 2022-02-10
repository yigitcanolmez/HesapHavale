using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HesapHavale
{
    class baglanti
    {
        public SqlConnection bgl()
        {

            SqlConnection qwe = new SqlConnection(@"Data Source=DESKTOP-EKQK6BH\SQLEXPRESS;Initial Catalog=DBHesapHavale;Integrated Security=True");

            qwe.Open();
            return qwe;

        }
    }
}
