using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public float hp;
	public Armor armor;
	private Weapon currentWeapon;
	public Weapon[] weaponSlot = new Weapon[5];

	private float damageReduction;

	private int weaponCounter;

	// Use this for initialization
	void Start () {
		if(armor!=null){
			armor = (Armor)Instantiate(armor);
			armor.transform.position = gameObject.transform.position;
			armor.transform.parent = gameObject.transform;
			damageReduction = armor.armorReduction;
		}
		else
			damageReduction = 0;

		for(int i=0;i<5;i++){
			if(weaponSlot[i]!=null){
				weaponSlot[i] = (Weapon)Instantiate(weaponSlot[i]);
				weaponSlot[i].transform.position = gameObject.transform.position;
				weaponSlot[i].transform.parent = gameObject.transform;
			}
		}

		setCurrentWeapon(0);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Bullet")
			hp -= other.gameObject.GetComponent<Bullet>().damage*(1-damageReduction);
	}

	public Weapon getCurrentWeapon(){
		return currentWeapon;
	}

	public void setCurrentWeapon(int slot){
		currentWeapon = weaponSlot[slot];
		weaponCounter = slot;
	}

	public void switchWeapon(){
		weaponCounter++;
		if(weaponCounter==weaponSlot.Length)
			weaponCounter=0;
		setCurrentWeapon(weaponCounter);
	}
}
