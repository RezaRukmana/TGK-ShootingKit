using UnityEngine;
using System.Collections;

public class Recoil : MonoBehaviour
{
	float verticalRecoilForce;
	float horizontalRecoilForce;
	float upSpeed;
	float dnSpeed;
	
	private Vector3 ang0;
	private float targetX;
	private float targetY;
	private Vector3 ang = Vector3.zero;
	
	void Start(){
		ang0 = transform.localEulerAngles;
	}

	public void recoil(){
		targetX += verticalRecoilForce;
		targetY += horizontalRecoilForce;
	}
	
	void Update(){ 
		ang.x = Mathf.Lerp(ang.x, targetX, upSpeed * Time.deltaTime);
		ang.y = Mathf.Lerp(ang.y, -targetY, upSpeed * Time.deltaTime);
		transform.localEulerAngles = ang0 - ang;
		targetX = Mathf.Lerp(targetX, 0, dnSpeed * Time.deltaTime);
		targetY = Mathf.Lerp(targetY, 0, dnSpeed * Time.deltaTime);

	}

	public void setRecoil(float vf, float hf, float u, float d){
		verticalRecoilForce = vf;
		horizontalRecoilForce = hf;
		upSpeed = u;
		dnSpeed = d;
	}
}
