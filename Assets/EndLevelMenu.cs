using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndLevelMenu : MonoBehaviour {



	public Button exitText;
	


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}

	public void ExitPressed()
	{
		Application.LoadLevel (0);
	}
}
