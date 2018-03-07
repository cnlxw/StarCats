﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class PlayerSector : MonoBehaviour {

	private float radius = 8.75f;
	private float tiltAngle;
	private static float speed = 0.2f;
	private static float initialSpeed;
	private Rigidbody2D rb;
	private static string inputName;

	private float maxX = 5.5f;
	private float minX = -5.5f;

	
	public GameObject shot;
	public Transform shotSpawn;
	public static float fireRate;
	private float nextFire;
	public static float initialFireRate;
	
	//new additions
	public static GameObject slow;
    public static GameObject reverse;
    public GameObject grenade;
	
	public GameObject radialtrap;
	public bool canSetTrap;
	
	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D>();
		initialSpeed = speed;
		tiltAngle = 0f;
		inputName = "Horizontal";
		canSetTrap = true;
		fireRate = 0.2f;
		initialFireRate = fireRate;
		reverse = GameObject.FindGameObjectWithTag("ReverseEffect");
		slow = GameObject.FindGameObjectWithTag("SlowEffect");
		DeactivateEffects();


	}
	
	static void DeactivateEffects()
	{
		slow.SetActive(false);
		reverse.SetActive(false);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Input.GetAxis("Trigger") > 0.9 && Time.fixedTime > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
		
		if (Input.GetAxis("LeftTrigger") > 0.9 && Time.fixedTime > nextFire && GrenadeCounter.gCount > 0)
		{
			nextFire = Time.time + fireRate;
			Instantiate(grenade, shotSpawn.position, shotSpawn.rotation);
			GrenadeCounter.AddGrenade(-1);
			
		}
		
		
		if (Input.GetButtonDown("CreateTrap") && canSetTrap && TrapCounter.trapCount > 0)
		{
			Vector2 butt = new Vector2(0, 0);
			Instantiate(radialtrap,butt,Quaternion.identity);
			//StartCoroutine(ActivateTrap());
			TrapCounter.AddTrap(-1);
		}
		
		float horizontal = Input.GetAxis(inputName); //"Horizontal");	
		Vector2 movement = new Vector2(horizontal, 0.0f);
		var angle = ((horizontal * speed / (2 * radius * Mathf.PI))) * 2 * Mathf.PI;
		var toDegree = 360f / (2 * Mathf.PI);
		tiltAngle += angle;
		var xPos = Mathf.Sin(tiltAngle) * radius;
		var yPos = -11f + Mathf.Cos(tiltAngle) * radius;
		if (xPos > minX && xPos < maxX)
		{
			transform.position = new Vector3(xPos, yPos, 0f);
			transform.Rotate (-Vector3.forward * angle * toDegree);
		}
		
		
		

		if (inputName == "FlippedHorizontal")
		{
			StartCoroutine(NormalInput());
		}

		if (speed < initialSpeed)
		{
			StartCoroutine(NormalSpeed());
		}

		

	}
	
	IEnumerator ActivateTrap()
	{
		yield return new WaitForSeconds(0.5f);
		canSetTrap = false;
	}
	
	IEnumerator NormalInput()
	{
		//reverse.SetActive(true);
		yield return new WaitForSeconds(5);
		inputName = "Horizontal";
		reverse.SetActive(false);

	}
	
	public static void FlipInput()
	{
		inputName = "FlippedHorizontal";

	}
	public static void SpeedUp()
	{
		speed = initialSpeed * 1.8f;
		fireRate = 0.12f;
	}

	public static void SlowDown()
	{
		speed = initialSpeed * 0.2f;
		fireRate = initialFireRate;
	}

	IEnumerator NormalSpeed()
	{
		//slow.SetActive(true);
		yield return new WaitForSeconds(5);
		speed = initialSpeed;
		fireRate = initialFireRate;
		slow.SetActive(false);
	}

	
}
