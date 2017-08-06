using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

class Project
{
    public static string projectPath;
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
        Project.mapPath = Project.projectPath + mapName;
        if (Directory.Exists(Project.projectPath) && !forceMode)
        {
            return false;
        }
        Directory.CreateDirectory(Project.projectPath);
        
        HexMap.generateMap(xSize, ySize);
        MapFile.save(Project.mapPath);
        return true;
    }

    public static List<String> getListProjectNames()
    {
        var list = Directory.GetDirectories(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\MastagaEditor\\").ToList<string>();
        for (int i = 0; i <list.Count; ++i)
        {
            list[i] = list[i].Split('\\').Last<string>();
        }
        return list;
    }
    
    public static void loadProject(string projectName)
    {
        clearProject();
        Project.projectPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\MastagaEditor\\" + projectName + "\\";
        Project.mapName = projectName;
        Project.mapPath = Project.projectPath + projectName;
        MapFile.MapFileOutput output = MapFile.read(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\MastagaEditor\\" + projectName + "\\" + projectName);
        HexMap.loadMap(output.fields, output.xSize,output.ySize);
    }

    public static bool regenMap(int xSize, int ySize, bool forceMode)
    {
        clearProject();
        HexMap.generateMap(xSize, ySize);
        MapFile.save(Project.mapPath);
        return true;
    }

    public static void clearProject()
    {
        fields.Clear();
    }

    public static void saveProject()
    {
        Debug.Log(mapName);
        MapFile.save(Project.mapPath);
    }

    public static void sortFields()
    {
        Project.fields = Project.fields.OrderBy(x => x.x).ThenBy(x => x.y).ToList();
    }
}
