using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


class ProjectFile
{
    const float version = 1f;

    public class FileOutput
    {
        public bool deltaVersion = false;
        public int version;
        public int playerCount;
    }

    public static void save(string dir,int playerCount)
    {
        string path = dir + ".pro";
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine(version.ToString());
            sw.WriteLine(playerCount.ToString());
        }
    }

    public static FileOutput read(string dir)
    {
        FileOutput output = new FileOutput();
        string[] lines = File.ReadAllLines(dir + ".pro");
        output.version = int.Parse(lines[0]);
        output.playerCount = int.Parse(lines[1]);

        if(output.version != ProjectFile.version) output.deltaVersion = true;
        
        return output;
    }
}