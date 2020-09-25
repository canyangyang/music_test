using System;
using System.Numerics;
using UnityEngine;

public class NoteController:UnityEngine.MonoBehaviour{
   public Line parentLine;
    UnityEngine.Vector2 startPointPos;
    UnityEngine.Vector2 endPointPos;
    new AudioSource audio;
   public Note note;
    public bool readyForFinalize=false;
    float startSample;
    float endSample;
    float speed;
    UnityEngine.Vector2 unit;
    void Start()
    {
        speed = parentLine.speed;
        startPointPos = parentLine.start_point.transform.position;
        endPointPos = parentLine.end_point.transform.position;
        startSample = note.showSample;
        endSample = note.establishSample;
        audio = parentLine.audio;
        unit = (endPointPos - startPointPos).normalized;
    }
    void Update()
    {
        if(audio.timeSamples>startSample && audio.timeSamples < endSample)
        {
        gameObject.transform.position =(unit * (audio.timeSamples-startSample)/ audio.clip.frequency * speed)+startPointPos;
        }
        else
        {
            if (audio.timeSamples > endSample) { readyForFinalize = true; gameObject.SetActive(false); }
        }
    }
}
