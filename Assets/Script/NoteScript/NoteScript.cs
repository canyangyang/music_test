/*
 示例
type:int,NoteType
time:long,sample time
lineNo:int

//File Start
1,1919,1 \/r
1,114514,1 \/r
 */
public class NoteScript {
  public  NoteType type;
    public long sample;
    public int lineNo;
    public NoteScript setType(NoteType type)
    {
        this.type = type;
        return this;
    }
    public NoteScript setLineNo(int lineNo)
    {
        this.lineNo = lineNo;
        return this;
    }
    public NoteScript setSample(long sample)
    {
        this.sample = sample;
        return this;
    }
}
public enum NoteType
{
    click,press
}