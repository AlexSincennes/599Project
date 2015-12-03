using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour {
    private GameObject CastUI;
	private SpawnScript spawner;
    private GameObject RemoteCam;
	void Start(){
		spawner = GameObject.FindGameObjectWithTag ("Spawner").GetComponent<SpawnScript>();
        RemoteCam = GameObject.FindGameObjectWithTag("Camera");
	}

    public void MainMenu()
    {

		CastUI = GameObject.FindGameObjectWithTag("RemoteUI");
        if (CastUI != null)
        {
            CastUI.GetComponent<Canvas>().enabled = false;
            CastUI.GetComponent<PauseMenu>().enabled = false;
            CastUI.GetComponent<PauseMenu>().scoreui = false;
        }
		CastUI = GameObject.FindGameObjectWithTag("CastUI");
        if (CastUI != null) {
			CastUI.GetComponent<Canvas> ().enabled = true;
		}
        CastUI = GameObject.FindGameObjectWithTag("PauseUI");
        if (CastUI != null)
            CastUI.SetActive(false);
        CastUI = GameObject.FindGameObjectWithTag("Camera");
        if (CastUI != null)
        {
            CastUI.transform.parent = null;
            CastUI.transform.position = new Vector3(0.0f, 2.5f, -10.0f);
        }
        Application.LoadLevel(0);

    }

	public void Restart(){
        CastUI = GameObject.FindGameObjectWithTag("RemoteUI");
        if (CastUI != null)
        {
            CastUI.GetComponent<PauseMenu>().scoreui = false;
		}
        CastUI = GameObject.FindGameObjectWithTag("PauseUI");
        if (CastUI != null)
            CastUI.SetActive(false);

        CastUI = GameObject.FindGameObjectWithTag("Camera");
        if (CastUI != null)
        {
            CastUI.transform.parent = null;
            CastUI.transform.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        }
		if (spawner != null && Application.loadedLevel == 2) {
			if (spawner.isStarted ()) {
				Application.LoadLevel (1);
			} else {
				Application.LoadLevel (Application.loadedLevel);
			}
		} else {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

    public void Exit()
    {
        Application.Quit();
    }
}
