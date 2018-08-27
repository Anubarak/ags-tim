using SqlKata;
using SqlKata.Execution;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AGS_Tim.services
{
    class Database
    {
        public  Database() {

            var connection = new SqlConnection(Path.Combine(Environment.CurrentDirectory, "TIM.db"));
            var compiler = new MySqlCompiler();
            var db = new QueryFactory(connection, compiler);
           
        }

        
    }
}
