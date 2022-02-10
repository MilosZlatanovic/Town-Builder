using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesControler : MonoBehaviour
{
    public float treePos;
    // public float treH;
    
    void Start()
    {
        treePos = transform.position.y;
      //  transform.position = new Vector3(transform.position.x, treePos-- , transform.position.z);
    }


    void Update()
    {
        if (transform.position.y < -3.4f)
        {
            transform.DOLocalMoveY(2f, 6f);
        }
       
    }

    public void TreeCating(float cat)
    {
        treePos -=cat;
       
        Debug.Log(treePos);
    }
}
