﻿using System.Collections;
using UnityEngine;


public class EnemyBullet : MonoBehaviour {

	public float speed;
	Vector2 _direction;
	bool isReady;

	void Awake()
	{
		
		isReady = false;
	}
	// Use this for initialization
	void OnCollisionEnter(Collision coll){
			Destroy(gameObject);
	}

	void OnTriggerEnter(Collider bullet)
	{
		if (bullet.gameObject.tag == "Colliders") {
			DestroyObject (bullet.gameObject);
		}
	}

	void Start () {
		
	}
	
		public void SetDirection(Vector2 direction)
	{
		_direction = direction.normalized;

		isReady = true;
	}


	// Update is called once per frame
	void Update () {

		if (isReady) {
			Vector2 position = transform.position;
			position += _direction * speed * Time.deltaTime;
			transform.position = position;
			}
	}

}
