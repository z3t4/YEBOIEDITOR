using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class MapFile
    {
        public static void save()
        {
            string path = Project.mapPath + ".map";
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (HexField field in Project.fields)
                {
                    sw.WriteLine(
                        field.x.ToString() + Project.fieldSeparator + 
                        field.y.ToString() + Project.fieldSeparator + 
                        (int)field.field);
                }
            }
        }

        public static List<HexField> read()
        {
            List<HexField> fields = new List<HexField>();
            string[] lines = File.ReadAllLines(Project.projectPath + Project.mapName + ".map");
            foreach (var line in lines)
            {
                var splits = line.Split(Project.fieldSeparator);
                fields.Add(new HexField(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2])));
            }
            return fields;
        }
    }
}
