using System.Collections.Generic;
using System.IO;

class MapFile
{
    public static void save(string dir)
    {
        string path = dir + ".map";
        using (StreamWriter sw = File.CreateText(path))
        {
            int xSize = Project.fields[Project.fields.Count-1].x;
            int ySize = Project.fields[Project.fields.Count - 1].y;
            sw.WriteLine(xSize.ToString() + Project.fieldSeparator +
                ySize.ToString());
            foreach (HexField field in Project.fields)
            {
                sw.WriteLine(
                    field.x.ToString() + Project.fieldSeparator + 
                    field.y.ToString() + Project.fieldSeparator + 
                    (int)field.field);
            }
        }
    }

    public class MapFileOutput
    {
        public int xSize, ySize;
        public List<HexField> fields = new List<HexField>();
    }

    public static MapFileOutput read(string dir)
    {
        MapFileOutput output = new MapFileOutput();
        string[] lines = File.ReadAllLines(dir + ".map");
        int lineCount = 0;
        foreach (var line in lines)
        {
            var splits = line.Split(Project.fieldSeparator);
            if (lineCount == 0)
            {
                output.xSize = int.Parse(splits[0]);
                output.ySize = int.Parse(splits[1]);
            }
            else
            {
                output.fields.Add(new HexField(int.Parse(splits[0]), int.Parse(splits[1]), int.Parse(splits[2])));
            }
            lineCount++;
        }
        return output;
    }
}
