using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	public Bullet projectile;

	private float cooldownCount;
	public float cooldownTime;

	public int currentAmmoInMagazine;
	public int magazineSize;
	public int totalAmmo;

	private float reloadCount;
	public float reloadTime;
	private bool isReloading;

	private Recoil recoilComponent;
	public float verticalRecoilForce = 2.5f;
	public float horizontalRecoilForce = 2.5f;
	public float recoilUpSpeed = 9;
	public float recoilDownSpeed = 15;

	public bool enableZoom;
	public float zoomDistance;

	// Use this for initialization
	void Start () {
		cooldownCount = 0;
		reloadCount = 0;
		currentAmmoInMagazine = magazineSize;
		isReloading = false;

		recoilComponent = Camera.main.GetComponent<Recoil>();
	}
	
	// Update is called once per frame
	void Update () {
		cooldownCount -= Time.deltaTime;

		if(Input.GetKeyDown(PlayerKey.getReloadKeyCode())&&!isReloading&&currentAmmoInMagazine<magazineSize&&totalAmmo>0){
			reloadInit();
		}

		if(isReloading){
			reloading();
		}
	}

	public void shoot(){
		if(cooldownCount<=0&&currentAmmoInMagazine>0&&!isReloading){
			projectile.direction = Camera.main.transform.forward;
			Instantiate(projectile, Camera.main.transform.position + Camera.main.transform.forward, Quaternion.identity);
			currentAmmoInMagazine--;
			cooldownCount = cooldownTime;
			recoilComponent.setRecoil(verticalRecoilForce, horizontalRecoilForce, recoilUpSpeed, recoilDownSpeed);
			recoilComponent.recoil();
		}
	}

	void reloadInit(){
		reloadCount = reloadTime;
		isReloading = true;
	}

	void reloading(){
		reloadCount -= Time.deltaTime;
		if(reloadCount<=0){
			isReloading = false;
			if(totalAmmo >= magazineSize){
				totalAmmo -= magazineSize-currentAmmoInMagazine;
				currentAmmoInMagazine = magazineSize;
			}
			else{
				currentAmmoInMagazine = totalAmmo;
				totalAmmo = 0;
			}
		}
	}
}
