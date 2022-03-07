using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Scaleable,IClickable
{
    // Start is called before the first frame update
    //protected bool ready = false;
    public int row;
	public int col;
    public char rowChess;
	public char colChess;

	//public bool walkable = true;
	/*public bool isReady{
		get{
			return ready;
		}
		set{
			ready=value;
		}
	} */
	public Piece Piece{
		get{
			return piece;
		}
		set{
			piece=value;
		}
	}
	public int gCost;
	public int hCost;
	private Piece piece;
    void Start()
    {
        
    }
    public void HighliteMove()
	{
		if(GetComponent<Renderer>().sharedMaterial!=origMaterial) return;
	    SetMaterial(GameManager.Instance.HighliteMoveMaterial);
	}
	public void HighliteEat()
	{
		if(GetComponent<Renderer>().sharedMaterial!=origMaterial) return;
	    SetMaterial(GameManager.Instance.HighliteEatMaterial);
	}
	public void HighliteCheck()
	{
		if(GetComponent<Renderer>().sharedMaterial!=origMaterial) return;
	    SetMaterial(GameManager.Instance.HighliteCheckMaterial);
	}
    // Update is called once per frame
    public void Clear()
    {
        piece=null;
    }
    public void ScaleIn(float startAfter, float speed, Vector3 finalScale) {
		StartCoroutine(IEScaleIn(startAfter+0.5f,speed,finalScale));
	}
   /* public IEnumerator IEScaleIn(float startAfter, float speed, float endScale) {
		yield return new WaitForSeconds(startAfter);
		ready = false;
		float t = Time.deltaTime * speed;
		float scale = 1f;
		while(t < Mathf.PI / 2) {
			t += Time.deltaTime * speed;
			scale = endScale * Mathf.Sin(t);
			transform.localScale = new Vector3(scale,scale,scale);
			yield return null;
		}
		transform.localScale = new Vector3(endScale, endScale, endScale);
		ready = true;
	} |*/
	public bool Inform<T>(T arg) {
		//TODO
		return true;
	}
    public IEnumerator IEScaleIn(float startAfter, float speed, Vector3 finalScale) {
		yield return new WaitForSeconds(startAfter);
		ready=false;
		float t=Time.deltaTime*speed;
		float scale=1f;
		Vector3 v=finalScale;
		v*=0.639f;
		while(t<Mathf.PI/2)
		{
			t+=Time.deltaTime*speed;
			transform.localScale=t*v;
			yield return null;
		}
		transform.localScale=finalScale;
		ready=true;
	}
}
