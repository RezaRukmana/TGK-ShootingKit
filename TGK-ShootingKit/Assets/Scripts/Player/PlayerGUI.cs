using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	private PlayerStats ps;

	GUIStyle style1 = new GUIStyle();
	
	// Use this for initialization
	void Start () {
		ps = GetComponent<PlayerStats>();

		style1.fontSize = 24;
		style1.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label(new Rect(Screen.width-135, 15, 150, 100), "HP : "+(int)ps.hp, style1);
		if(ps.armor!=null)
			GUI.Label(new Rect(Screen.width-135, 45, 150, 100), "Armor : "+(int)ps.armor.armorPoint, style1);
		if(ps.getCurrentWeapon()!=null){
			GUI.Label(new Rect(0, Screen.height-60, 150, 100), "Ammo : "+ps.getCurrentWeapon().currentAmmoInMagazine+"/"+ps.getCurrentWeapon().magazineSize, style1);
			GUI.Label(new Rect(0, Screen.height-30, 150, 100), "Total Ammo : "+ps.getCurrentWeapon().totalAmmo, style1);
		}
	}
}
