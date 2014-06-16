using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float movementSpeed;
	public float jumpVelocity;
	public float walkSpeed;

	private bool canJump;
	private bool isZoomed;

	private PlayerStats ps;

	// Use this for initialization
	void Start () {
		ps = gameObject.GetComponent<PlayerStats>();
		canJump = false;
		isZoomed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(ps.hp>0){
			moveShooter();
			getKeyInput();

			transform.rotation = Camera.main.transform.rotation;
		}
		else
			onDead();
	}

	void moveShooter(){
		Vector3 moveV = transform.forward*movementSpeed;
		Vector3 moveH = transform.right*movementSpeed;

		moveV *= Input.GetAxis("Vertical");
		moveH *= Input.GetAxis("Horizontal");
		
		Vector3 movement = (moveV+moveH);

		if(Input.GetKey(PlayerKey.getWalkKeyCode()))
			movement *= walkSpeed;

		transform.position += movement;
	}

	void getKeyInput(){		
		if(Input.GetMouseButton(0))
			ps.getCurrentWeapon().shoot();
		if(Input.GetMouseButtonDown(1)&&ps.getCurrentWeapon().enableZoom)
			zoom();
		if(Input.GetKeyDown(PlayerKey.getJumpKeyCode())&&canJump)
			jump();
		if(Input.GetKeyDown(PlayerKey.getSwitchWeaponKeyCode()))
			switchWeapon();
		if(Input.GetKeyDown(KeyCode.Alpha1))
			quickSwitch(0);
		else if(Input.GetKeyDown(KeyCode.Alpha2))
			quickSwitch(1);
		else if(Input.GetKeyDown(KeyCode.Alpha3))
			quickSwitch(2);
		else if(Input.GetKeyDown(KeyCode.Alpha4))
			quickSwitch(3);
		else if(Input.GetKeyDown(KeyCode.Alpha5))
			quickSwitch(4);
	}

	void zoom(){
		if(!isZoomed)
			Camera.main.GetComponent<MyCamera>().zoomVector = new Vector3(ps.getCurrentWeapon().zoomDistance*Camera.main.transform.forward.x,0,ps.getCurrentWeapon().zoomDistance*Camera.main.transform.forward.z);
		else
			Camera.main.GetComponent<MyCamera>().zoomVector = new Vector3(0,0,0);

		isZoomed = !isZoomed;
	}

	void jump(){
		rigidbody.velocity += new Vector3(0,jumpVelocity,0);
	}

	void switchWeapon(){
		ps.switchWeapon();
		if(isZoomed)
			zoom();
	}

	void quickSwitch(int slot){
		if(ps.weaponSlot[slot]!=null)
			ps.setCurrentWeapon(slot);
		if(isZoomed)
			
			zoom();
	}

	void onDead(){
		
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Ground")
			canJump = true;
	}

	void OnCollisionExit(Collision other){
		if(other.gameObject.tag == "Ground")
			canJump = false;
	}
}
