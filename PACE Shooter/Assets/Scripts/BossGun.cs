﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour {
	public GameObject BossBulletGO;
	private int BossHealth = 6;
	private int BossMultiShot = 4;
	public Animator _ShootAnim;
	private float aka = -0.1f;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireBossBullet", 140/180f, 140/500f);
	}
	private void PlayShootAnim(){
		_ShootAnim.Play ("EnemyShootAnim");
	//	Debug.Log ("Anim Triggered!");
	}
	// Update is called once per frame
	void Update () {
		
	}
	void FireBossBullet()
	{
		PlayShootAnim ();
		if (BossMultiShot > 0) {
			//AudioSource audio = GetComponent<AudioSource> ();
			//audio.Play();
			GameObject playerishere = GameObject.Find ("playerishere");
			GameObject bullet = (GameObject)Instantiate (BossBulletGO);
			bullet.transform.position = transform.position;
			Vector2 direction = playerishere.transform.position - bullet.transform.position;
			bullet.GetComponent<EnemyBullet> ().SetDirection (direction);
			BossMultiShot -= Random.Range(0, 2);
		} else {
			BossMultiShot = Random.Range(0, 4);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if((col.tag == "Bullets")){
			BossHealth -= 1;
			if (BossHealth <= 0) {
				Destroy (gameObject);
			}
		}
	}
}
