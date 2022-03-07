using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {   
        if(collider.gameObject.tag=="Player")
        {
            Invoke("DestroyPlat",1.8f);
            print("Invoke called");
        }
    }
    void DestroyPlat()
    {
        Rigidbody rb=this.GetComponentInParent<Rigidbody>();
        rb.isKinematic = false;
		Destroy (this.transform.parent.gameObject, 0.5f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
