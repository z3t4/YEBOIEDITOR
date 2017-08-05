using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

class Project
{
    public static string projectPath = "C:\\Users\\jérome\\Documents\\Mastaga\\";
    public static string mapName = "map";
    public static char fieldSeparator = '#';

    public static string mapPath;
    public static List<HexField> fields = new List<HexField>();

    public static bool newProject(string mapName, int xSize, int ySize, bool forceMode)
    {
        clearProject();
        Project.projectPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\MastagaEditor\\";
        if (!Directory.Exists(Project.projectPath))
        {
            Directory.CreateDirectory(Project.projectPath);
        }
        Project.projectPath = Project.projectPath + mapName + "\\";
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

    private void checkFolderMastaga()
    {
        if (!Directory.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "MastagaEditor\\"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "MastagaEditor\\");
        }
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
