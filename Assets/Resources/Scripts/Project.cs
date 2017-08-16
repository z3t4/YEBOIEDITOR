using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Project
{
    public static string projectPath = "";
    public static string mapName = "map";
    public static char fieldSeparator = '#';

    public static int playerCount;
    public static string mapPath;
    public static List<HexField> fields = new List<HexField>();

    public static bool newProject(string mapName, int xSize, int ySize, int playerCount, bool forceMode)
    {
        clearProject();
        projectPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\MastagaEditor\\";

        projectPath = projectPath + mapName + "\\";
        Project.mapName = mapName;
        Project.playerCount = playerCount;
        mapPath = projectPath + mapName;

        if (Directory.Exists(projectPath) && !forceMode)
        {
            return false;
        }

        HexMap.generateMap(xSize, ySize);
        return true;
    }

    public static void loadProject(string projectName)
    {
        clearProject();
        projectPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\MastagaEditor\\" + projectName + "\\";
        mapName = projectName;
        mapPath = projectPath + projectName;

        ProjectFile.FileOutput projectOutput = ProjectFile.read(mapPath);
        MapFile.MapFileOutput output = MapFile.read(mapPath);

        HexMap.loadMap(output.fields, output.xSize, output.ySize);
    }

    public static List<String> getListProjectNames()
    {
        var list = Directory.GetDirectories(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\MastagaEditor\\").ToList<string>();
        for (int i = 0; i < list.Count; ++i)
        {
            list[i] = list[i].Split('\\').Last<string>();
        }
        return list;
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
        if(projectPath == "")
        {
            return;
        }
        if (!Directory.Exists(projectPath))
        {
            Directory.CreateDirectory(projectPath);
        }
        else
        {
            foreach (string filePath in Directory.GetFiles(projectPath))
            {
                File.Delete(projectPath + filePath);
            }
        }
        MapFile.save(mapPath);
        ProjectFile.save(mapPath, playerCount);
    }

    public static void sortFields()
    {
        Project.fields = Project.fields.OrderBy(x => x.data.x).ThenBy(x => x.data.y).ToList();
    }

}
