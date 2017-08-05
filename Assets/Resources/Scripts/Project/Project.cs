using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


class Project
{
    public static string projectPath = "C:\\Users\\jérome\\Documents\\Mastaga\\";
    public static string mapName = "map";
    public static char fieldSeparator = '#';

    public static string mapPath;
    public static List<HexField> fields = new List<HexField>();
        
    public static bool newProject(string projectPath, string mapName,bool forceMode)
    {
        clearProject();

        Project.projectPath = projectPath + mapName + "\\";
        Project.mapName = mapName;
        if (Directory.Exists(Project.projectPath) && !forceMode)
        {
            return false;
        }
        Directory.CreateDirectory(Project.projectPath);

        Project.mapPath = Project.projectPath + mapName;
        MapFile.save();
        return true;
    }

    public static void openProject()
    {
        clearProject();
        fields = MapFile.read();
    }

    public static void clearProject()
    {
        fields.Clear();
    }

    public static void saveProject()
    {
        MapFile.save();
    }

    public static void sortFields()
    {
        Project.fields = Project.fields.OrderBy(x => x.x).ThenBy(x => x.y).ToList();
    }
}
