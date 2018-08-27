
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;



namespace AGS_Tim.services
{
    class Database
    {
        private SQLiteConnection dbConnection;  
        public  Database() {
          dbConnection = new SQLiteConnection("Data Source=TIM.db;Version=3;"); 
        }

        public void OpenDatabase()
        {
            try
            {
                dbConnection.Open();
            }
            catch (Exception ex)
            {
            }

        }


        public int Execute()
        {
            try
            {
           
            }
            catch (Exception ex)
            {

            }

            return 0;
        }

        
    }
}
