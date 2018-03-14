using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GrenadeCounter : MonoBehaviour {

	public static int gCount = 0;
	private static Text _Grenade;
	public static int maxgrenades = 20;
	public string currentscene;
		
	// Use this for initialization
	internal void Start ()
	{
		_Grenade = GetComponent<Text>();
		UpdateGrenade();
		currentscene = SceneManager.GetActiveScene().name;
		if ((currentscene == "LevelOne") || (currentscene == "LevelTwo") || (currentscene == "LevelThree"))
		{
			_Grenade.enabled = false;
		}
		

	}

	public static void AddGrenade (int value)
	{
		gCount += value;
		UpdateGrenade();
	}
	

	public static void UpdateGrenade()
	{
		_Grenade.text = "Nukes: " + gCount;
	}

}
