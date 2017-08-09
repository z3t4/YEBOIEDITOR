using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


class ProjectFile
{
    const string version = "1";

    public class FileOutput
    {
        public bool deltaVersion = false;
        public string version;
        public int playerCount;
    }

    public static void save(string dir,int playerCount)
    {
        string path = dir + ".pro";
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine(version);
            sw.WriteLine(playerCount);
        }
    }

    public static FileOutput read(string dir)
    {
        FileOutput output = new FileOutput();
        string[] lines = File.ReadAllLines(dir + ".pro");
        output.version = lines[0];
        output.playerCount = int.Parse(lines[1]);

        if(output.version != version) output.deltaVersion = true;
        
        return output;
    }
}