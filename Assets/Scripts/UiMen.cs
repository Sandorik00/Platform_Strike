using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMen : MonoBehaviour {

	void Start ()
	{
		
	}

	void Update()
	{
		
	}
	public void Click() 
	{
		Application.Quit ();
	}
	public void ClickS()
	{
		SceneManager.LoadScene ("Test_devlvl");
	}
}
