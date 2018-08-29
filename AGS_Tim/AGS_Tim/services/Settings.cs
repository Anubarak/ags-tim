using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AGS_Tim.models;

namespace AGS_Tim.services
{
    class Settings
    {
        public int level;
        

        /// <summary>
        /// initiates the Settings and Loads them from the database
        /// </summary>
        public Settings()
        {
            LoadSettings(); 
        }


        /// <summary>
        /// saves the Settings in the database
        /// </summary>
        public void SaveSettings()
        {
            Setting tempSetting = new Setting();
            tempSetting.id = 1; 
            tempSetting.level = level;
            var tempSettings = Main.db.dbConnection.Update(tempSetting);
        }

        /// <summary>
        /// Loads the Settings from the database
        /// </summary>
        public void LoadSettings()
        {
           var tempSettings = Main.db.dbConnection.Table<Setting>();

            if (tempSettings.Count() == 0)
            {
                level = 1;
                var tempInsert = Main.db.dbConnection.Insert(new Setting() { id = 1, level = 1 });
            }
                
            else
                level =  tempSettings.First(v => v.id == 1).level ;
        }
    }
}
