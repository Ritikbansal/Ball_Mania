using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 dir=player.transform.position;
       
        this.transform.position=new Vector3(dir.x,dir.y+2,dir.z-4);
    }
}
