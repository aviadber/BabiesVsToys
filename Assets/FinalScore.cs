using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
	public Text score;
	// Use this for initialization
	void Start () {
		score.text= GameManager.getScore ().ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
