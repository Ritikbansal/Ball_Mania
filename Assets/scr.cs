using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    // Start is called before the first frame update
    //float f=0.06f;
    bool ready=false;
    void Start()
    {
        StartCoroutine(IEScaleIn(0.43f,0.53f,new Vector3(1.0f,1.0f,1.0f)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator IEScaleIn(float startAfter, float speed, Vector3 endScales) {
		yield return new WaitForSeconds(startAfter);
		ready = false;
		float t = Time.deltaTime * speed;
		print("t1 "+t);
		float scale = 1f;
        Vector3 e=endScales;
        endScales*=0.6369f;
		while(t < Mathf.PI / 2) {
			t += Time.deltaTime * speed;
			print("t2 "+t);
			transform.localScale = endScales * t;
			print("transform.localScale "+transform.localScale);
			print("endScale "+endScales);
			yield return null;
		}
        print("scccc"+scale);
		transform.localScale = e * scale;
		ready = true;
		print("ended");
	}
}
