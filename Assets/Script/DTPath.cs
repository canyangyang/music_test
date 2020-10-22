using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PathCreation;
using UnityEngine.UIElements;

public class DTPath : MonoBehaviour
{
    public GameObject path;
    public PathCreator creator;
    // Start is called before the first frame update
    void Start()
    {
        
        creator = path.GetComponent<PathCreator>();
        Vector3 deltaPath;
        deltaPath = creator.path.GetPoint(0);
        Vector3[] newpath = new Vector3[creator.path.NumPoints];
        for(int i = 0; i < creator.path.NumPoints; i++)
        {
            newpath[i] = creator.path.GetPoint(i) -deltaPath;
        }
        this.transform.position =this.transform.parent.position;
        this.transform.DOLocalPath(newpath, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
