using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject start_point;
    public GameObject end_point;
    public GameObject dot_x;
    public new AudioSource audio;
    public float speed;
    public float timePast = 0;
    private Queue<Note> waitForShowNotes;
    private Queue<NoteController> nowOnScreenNotesCtrl;
    // Start is called before the first frame update
    void Start()
    {
        if (start_point == null || end_point == null || dot_x == null || audio == null)
        {
            Debug.Log("Component not set probably");
        }
        Vector2 point = start_point.transform.position;
        dot_x.transform.position = new Vector2(point.x, point.y);
        dot_x.SetActive(false);
        dot_x.GetComponent<NoteController>().parentLine = this;
        var notes = NoteLoader.sort(new NoteLoader((end_point.transform.position - start_point.transform.position).magnitude, speed, audio.clip.frequency, 0.5f).readAll(fs.read(@"\1.txt")));//设置1.txt的绝对位置
        waitForShowNotes = new Queue<Note>(notes);
        nowOnScreenNotesCtrl = new Queue<NoteController>();
        audio.PlayDelayed(10);
    }
    // Update is called once per frame
    void Update()
    {
        while (checkIfNeedPrepare()) ;
    }
    void LateUpdate()
    {
        while (checkIfNeedFinalize()) ;
    }
    /// <summary>
    /// 检查是否有新的Note到达prepare的时间点
    /// </summary>
    /// <returns></returns>
    bool checkIfNeedPrepare()
    {
        if (waitForShowNotes.Count == 0) return false;
        if (waitForShowNotes.Peek().prepareSample <= audio.timeSamples)
        {
            Debug.Log(audio.timeSamples);
            var newNote = getNewNote(waitForShowNotes.Dequeue());
            nowOnScreenNotesCtrl.Enqueue(newNote);
            newNote.gameObject.SetActive(true);
            return true;
        }
        return false;
    }
    /// <summary>
    /// 循环销毁音符
    /// </summary>
    /// <returns>本次销毁是否成功</returns>
    bool checkIfNeedFinalize()
    {
        if (nowOnScreenNotesCtrl.Count == 0) return false;
        if (nowOnScreenNotesCtrl.Peek().readyForFinalize)
        {
            finalizeNote(nowOnScreenNotesCtrl.Dequeue().gameObject);
            return true;
        }
        return false;
    }
    void finalizeNote(GameObject obj)
    {
        GameObject.Destroy(obj);
    }
    NoteController getNewNote(Note note)
    {
        var newObjCtrl = GameObject.Instantiate(dot_x).GetComponent<NoteController>();
        newObjCtrl.note = note;
        newObjCtrl.parentLine = this;
        return newObjCtrl;
    }
}
