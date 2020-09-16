
using System;

public class Note : IComparable
{
    public NoteType type;
    /// <summary>
    /// 应该被点按的时间点
    /// </summary>
    public long establishSample;
    /// <summary>
    /// NoteGameObject应该出现的时间点
    /// </summary>
    public long showSample;
    /// <summary>
    /// NoteController应该在这个时间点创建完成
    /// </summary>
    public long prepareSample;
    public int lineNo;
    public Note setType(NoteType type)
    {
        this.type = type;
        return this;
    }
    public Note setLineNo(int lineNo)
    {
        this.lineNo = lineNo;
        return this;
    }
    public Note setEstablishSample(long establishSample)
    {
        this.establishSample = establishSample;
        return this;
    }
    public Note setShowSample
        (long showSample)
    {
        this.showSample = showSample;
        return this;
    }
    public Note setPrepareSample(long prepareSample)
    {
        this.prepareSample = prepareSample;
        return this;
    }

    public int CompareTo(object obj)
    {
        if (obj is Note note)
        {
            return (int)(this.prepareSample-note.prepareSample);
        }
        else
        {
            throw new ArgumentException();
        }
    }
}
