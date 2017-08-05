using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class ProjectFile
    {

        public static void save()
        {
            string path = Project.mapPath + ".project";
            using (StreamWriter sw = File.CreateText(path))
            {
                
            }
        }

        public static void read()
        {
            
        }
    }
}
