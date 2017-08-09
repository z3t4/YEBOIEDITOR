using System.Collections.Generic;
using System.IO;

class MapFile
{
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
                if(Project.fields[Project.fields.Count -1] == field)
                {
                    sw.Write(writeString(field.data));
                    break;
                }
                sw.WriteLine(writeString(field.data));
            }
        }
    }

    private static string writeString(HexField.Data data)
    {
        return data.x.ToString() + Project.fieldSeparator +
                    data.y.ToString() + Project.fieldSeparator +
                    (int)data.field + Project.fieldSeparator +
                    data.playerControl.ToString();
    }

    public class MapFileOutput
    {
        public int xSize, ySize;
        public List<HexField.Data> fields = new List<HexField.Data>();
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
