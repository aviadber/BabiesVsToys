using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndLevelMenu : MonoBehaviour {



	public Button exitText;
	


	// Use this for initialization
	void Start () {
		exitText = exitText.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void ExitPressed()
	{
		Application.LoadLevel (0);
	}
}
