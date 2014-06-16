using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public float speed;
	public Vector3 direction;
	public float damage;

	public bool destroyOnCollision;
	public float lifeTime;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = direction * speed;
	}
	
	// Update is called once per frame
	void Update () {
		updateLifeTime();
	}

	void updateLifeTime(){
		lifeTime -= Time.deltaTime;
		if(lifeTime<=0)
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision other){
		if(destroyOnCollision)
			Destroy(this.gameObject);
	}
}
