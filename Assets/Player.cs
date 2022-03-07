using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=3f;
    bool isMovingRight=false;
    bool isMoving=false;
    Rigidbody rb;
    ParticleSystem ps;
    void Start()
    {
        rb=this.GetComponent<Rigidbody>();
        ps=ps=GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-5)
        {
            SceneManager.LoadScene(0);
        }
       if(isMoving) transform.Rotate(new Vector3(90,45,60)*Time.deltaTime);
        if(Input.GetMouseButtonDown(0))
        {   isMoving=true;
            ChangeDirection();
        }
        	if (Physics.Raycast (this.transform.position, Vector3.down * 2) == false) {
			FallDown ();
		}
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Gem")
        {
            if(ps!=null) ps.Play();
        }
    }
    void FallDown()
    {
        rb.velocity=new Vector3(0f,-3f,0f);
    }
    void ChangeDirection()
    {
       if(isMovingRight)
       {
           isMovingRight=!isMovingRight;
           rb.velocity=new Vector3(0f,0f,speed);
       }else{
            isMovingRight=!isMovingRight;
           rb.velocity=new Vector3(speed,0f,0f);
       }
    }
}
