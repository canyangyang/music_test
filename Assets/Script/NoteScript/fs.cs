using System;
using UnityEngine;

public static class fs
{
  public static  NoteScript[]  read(string path)
    {
        string[] lines = System.IO.File.ReadAllLines(path);
        NoteScript[] scripts = new NoteScript[lines.Length];
        for(int i = 0; i < lines.Length; i++)
        {
             string[] line = lines[i].Split(',');
            scripts[i] = new NoteScript()
                .setType((NoteType)int.Parse(line[0]))
                .setSample(Int32.Parse(line[1]))
                .setLineNo(Int32.Parse(line[2]));
        }
        return scripts;
    }

}