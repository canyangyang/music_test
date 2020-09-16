
using System;
using System.Collections.Generic;
using UnityEngine;

public class NoteLoader {
   public readonly long shiftSample;
    public readonly float distance;
    public readonly float speed;
    public readonly int sampleRate;
    public readonly float prepareRate;
    public readonly long prepareSample;
   public NoteLoader(float distance,float speed,int sampleRate, float prepareRate)
    {
        this.speed = speed;
        this.sampleRate = sampleRate;
        this.prepareRate = prepareRate;
        shiftSample =(long) (distance / speed * sampleRate);
        prepareSample =(long) Mathf.Floor(shiftSample * prepareRate);
    }
    public long shift(long establishTime)
    {
        return establishTime - shiftSample;
    }
    public long shiftPrepare(long establishTime)
    {
        return establishTime - shiftSample-prepareSample;
    }
    public Note read(NoteScript script)
    {
        return new Note().setEstablishSample(script.sample)
            .setLineNo(script.lineNo).
            setType(script.type)
            .setShowSample(shift(script.sample))
            .setPrepareSample(shiftPrepare(script.sample));
    }
    public Note[] readAll(NoteScript[] scripts)
    {
        var length = scripts.Length;
        Note[] array = new Note[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = read(scripts[i]);
        }
        return array;
    }
    public static Note[] sort(Note[] notes)
    {
        Note[] array=new Note[notes.Length];
        notes.CopyTo(array,0);
        Array.Sort(array);
        return array;
    }
    public Queue<Note> enqueue(Note[] notes)
    {
        return new Queue<Note>(notes);
    }
}