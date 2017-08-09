using System.Collections.Generic;
using System.IO;

class MapFile
{
    public class MapFileOutput
    {
        public int xSize, ySize;
        public List<HexField.Data> fields = new List<HexField.Data>();
    }
    
    public static void save(string dir)
    {
        string path = dir + ".map";
        using (StreamWriter sw = File.CreateText(path))
        {
            int xSize = Project.fields[Project.fields.Count-1].data.x;
            int ySize = Project.fields[Project.fields.Count - 1].data.y;
            sw.WriteLine(xSize.ToString() + Project.fieldSeparator +
                ySize.ToString());
            foreach (HexField field in Project.fields)
            {
                sw.WriteLine(
                    field.data.x.ToString() + Project.fieldSeparator + 
                    field.data.y.ToString() + Project.fieldSeparator + 
                    field.data.field + Project.fieldSeparator + 
                    field.data.playerControl);
            }
        }
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
                output.fields.Add(new HexField.Data {
                    x = int.Parse(splits[0]),
                    y = int.Parse(splits[1]),
                    field = (HexField.FieldType)int.Parse(splits[2]),
                    playerControl = int.Parse(splits[3])
                });
            }
            lineCount++;
        }
        return output;
    }
}
