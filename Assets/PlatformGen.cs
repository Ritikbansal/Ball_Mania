using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 lastPos;
    static int count=0,i=0;
    public GameObject platform1;
     public GameObject platform2;
      public GameObject gem;
     //GameObject plat[count];
    void Start()
    {
       InvokeRepeating("spawn",1.0f,0.27f);
       lastPos=new Vector3(1.5f,0,1.5f);
    }
    void spawnZ()
    {
        GameObject _platform=Instantiate(platform1) as GameObject;
        //plat[count]=_platform;
        _platform.transform.position=lastPos+new Vector3(0,0,1);
        lastPos=_platform.transform.position;
        count++;
    }
    void spawnX()
    {
        GameObject _platform=Instantiate(platform2) as GameObject;
       // plat[count]=_platform;
        _platform.transform.position=lastPos+new Vector3(1,0,0);
        lastPos=_platform.transform.position;
         count++;
    }
    void spawnGem()
    {
        GameObject g=Instantiate(gem) as GameObject;
        g.transform.position=lastPos+new Vector3(0f,0.9f,0f);
    }
    // Update is called once per frame
    void spawn()
    {   print("called"+i);
        int rnd=Random.Range(0,4);
     //  if(count<99)
        if(rnd%2==0) spawnZ(); else spawnX();
        if(rnd==0) spawnGem();
    }
    void Update()
    {
        
    }
}
