using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemRotate : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem ps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(90,45,60)*Time.deltaTime);
    }
    void OnTriggerEnter(Collider collider)
    {
      //  if(ps!=null) ps.Play();
        
        if(collider.tag=="Player")
        {   
            Destroy(gameObject);
        }
    }
}
