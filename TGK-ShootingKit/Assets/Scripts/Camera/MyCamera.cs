using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {

	private Transform myTransform;
	public PlayerControl player;

	public float heightFromPlayer;
	public float distanceFromPlayer;

	public Vector3 zoomVector;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.position = player.transform.position + new Vector3(0,heightFromPlayer,distanceFromPlayer)+ zoomVector;
	}
}