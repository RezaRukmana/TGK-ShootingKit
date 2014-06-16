using UnityEngine;
using System.Collections;

public class PlayerKey : MonoBehaviour {
	
	public string reloadKey;
	public string jumpKey;
	public string walkKey;
	public string crouchKey;
	public string switchWeaponKey;
	
	private static KeyCode reloadKeyCode;
	private static KeyCode jumpKeyCode;
	private static KeyCode walkKeyCode;
	private static KeyCode crouchKeyCode;
	private static KeyCode switchWeaponKeyCode;

	// Use this for initialization
	void Start () {
		reloadKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), reloadKey) ;
		jumpKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), jumpKey) ;
		walkKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), walkKey) ;
		crouchKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), crouchKey) ;
		switchWeaponKeyCode = (KeyCode) System.Enum.Parse(typeof(KeyCode), switchWeaponKey) ;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public static KeyCode getReloadKeyCode(){
		return reloadKeyCode;
	}
	
	public static KeyCode getJumpKeyCode(){
		return jumpKeyCode;
	}

	public static KeyCode getWalkKeyCode(){
		return walkKeyCode;
	}

	public static KeyCode getCrouchKeyCode(){
		return crouchKeyCode;
	}

	public static KeyCode getSwitchWeaponKeyCode(){
		return switchWeaponKeyCode;
	}
}
