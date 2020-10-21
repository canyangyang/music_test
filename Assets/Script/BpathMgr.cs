using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using Newtonsoft.Json;
public class BpathMgr : MonoBehaviour
{
    PathCreator creator;
    [System.Serializable]
    //用结构体代替字典序列化
    public struct bpath
    {
        public int number;
        public GameObject path;
    }
    public bpath[] bpaths;
    public struct bpathdata
    {
        public int number;
        public Vector3[] points;
    }
    public bpathdata[] bpathdatas;
    // Start is called before the first frame update
    void Start()
    {
        bpathdatas = new bpathdata[bpaths.Length];
        //将结构体的数据复制给数据结构体
        for(int i = 0; i < bpaths.Length; i++)
        {
                creator = bpaths[i].path.GetComponent<PathCreator>();
                bpathdatas[i].number = bpaths[i].number;
                Debug.Log(creator.path.NumPoints);
               for(int j = 0; j < creator.path.NumPoints; j++)
            {
                Debug.Log(creator.path.GetPoint(j));
                bpathdatas[i].points[j] = creator.path.GetPoint(j);
            }
            }
        string json =JsonUtility.ToJson(bpathdatas, true);
        Debug.Log(json);
        }
        

    }

    // Update is called once per frame

