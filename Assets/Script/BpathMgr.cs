using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using Newtonsoft.Json;
public class BpathMgr : MonoBehaviour
{
    public string dicname;
    PathCreator creator;
    [System.Serializable]
    public struct bpath
    {
        public int number;
        public GameObject path;
    }
    public bpath[] bpaths;
    // Start is called before the first frame update
    void Start()
    {
        
        Bpath newbpath = new Bpath();
        newbpath.name = dicname;
        newbpath.dic = new Dictionary<int, Vector3[]>();
        for(int i = 0; i < bpaths.Length; i++)
        {
            if (!newbpath.dic.ContainsKey(bpaths[i].number))
            {
                creator = bpaths[i].path.GetComponent<PathCreator>();
                Debug.Log(creator.path.NumPoints);
                Vector3[] points = creator.path.localPoints;
                newbpath.dic.Add(bpaths[i].number, points);
            }
        }
        string json = JsonConvert.SerializeObject(newbpath);
        Debug.Log(json);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
