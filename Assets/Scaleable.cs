using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaleable : MonoBehaviour
{
    protected bool ready=false;
	protected Material origMaterial;
    protected Color origColor;
	protected Color origEmission;
	protected new Renderer renderer;
	public bool IsReady {
		get {
			return ready;
		}

		set {
			ready = value;
		}
	}
    void Start()
    {
        origMaterial=renderer.material;
        origColor=origMaterial.GetColor("_Color");
		origEmission=origMaterial.GetColor("_EmissionColor");
    }
	public void SetMaterialOriginal() {
		SetMaterial(origMaterial);
	}
	public void SetEmission(Color c)
	{
		renderer.material.SetColor("_EmissionColor",c);
	}
	public void SetMaterial(Material m)
	{
		renderer.material=m;
	}
    public void ScaleIn(float startAfter, float speed, Vector3 finalScale) {
		StartCoroutine(IEScaleIn(startAfter+0.5f,speed,finalScale));
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
