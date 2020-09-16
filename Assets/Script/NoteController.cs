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
    float timePast = 0;
    float speed;
    void Start()
    {
        speed = parentLine.speed;
        startPointPos = parentLine.start_point.transform.position;
        endPointPos = parentLine.end_point.transform.position;
        startSample = note.showSample;
        endSample = note.establishSample;
        audio = parentLine.audio;
    }
    void Update()
    {
        if(audio.timeSamples>startSample && audio.timeSamples < endSample)
        {
        gameObject.transform.position = (endPointPos - startPointPos).normalized * timePast * speed;
            timePast += Time.deltaTime;
        }
        else
        {
            if (audio.timeSamples > endSample) { readyForFinalize = true; gameObject.SetActive(false); }
        }
    }
}
