using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Diagnostics.Eventing.Reader;

public class DTPathMove : MonoBehaviour
{
    public GameObject item;
    public Vector3[] pathpoints;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        item.transform.DOPath(pathpoints, 10f, DG.Tweening.PathType.CatmullRom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
