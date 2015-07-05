using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;

    public Canvas chapMenu;
    public Canvas demoMenu;
    public Canvas chap1Menu;
    public Canvas settingsMenu;



	// Use this for initialization
	void Start ()
	{
	    quitMenu = quitMenu.GetComponent<Canvas>();
	    chapMenu = chapMenu.GetComponent<Canvas>();
	    chap1Menu = chap1Menu.GetComponent<Canvas>();
	    demoMenu = demoMenu.GetComponent<Canvas>();
	    settingsMenu = settingsMenu.GetComponent<Canvas>();
	    startText = startText.GetComponent<Button>();
	    exitText = exitText.GetComponent<Button>();
	    settingsMenu.enabled = false;
	    quitMenu.enabled = false;
	    chapMenu.enabled = false;
	    chap1Menu.enabled = false;
	    demoMenu.enabled = false;

	}

    public void DisableChapMenus()
    {
        chap1Menu.enabled = false;
        demoMenu.enabled = false;
    }

    public void ChapPressed()
    {
        chapMenu.enabled = true;
    }

    public void DemoPressed()
    {
        DisableChapMenus();

        demoMenu.enabled = true;
    }

    public void Chap1Pressed()
    {
        DisableChapMenus();
        chap1Menu.enabled = true;
    }


    public void ExitPressed()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void SettingsPressed()
    {
        settingsMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPressed()
    {
        quitMenu.enabled = false;
        settingsMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartDemo1()
    {
        Application.LoadLevel(1);
    }

    public void StartPlayGround()
    {
        Application.LoadLevel(2);
    }
    public void StartKindergarten()
    {
        Application.LoadLevel(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    // Update is called once per frame
	void Update () {
	
	}
}
