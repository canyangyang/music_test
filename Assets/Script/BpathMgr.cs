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
        public Vector3[] points;
    }
    public bpath[] bpaths;
  
 
    // Start is called before the first frame update
    void Start()
    {
        
        //将结构体的数据复制给数据结构体
        for(int i = 0; i < bpaths.Length; i++)
        {
                creator = bpaths[i].path.GetComponent<PathCreator>();
                bpaths[i].points = creator.path.localPoints;
                Debug.Log(creator.path.NumPoints);
            }
        string json =JsonUtility.ToJson(bpaths, true);
        Debug.Log(json);
        }
        

    }

    // Update is called once per frame

