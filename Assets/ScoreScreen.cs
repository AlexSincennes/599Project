using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour {
    private GameObject CastUI;
	private SpawnScript spawner;

	void Start(){
		spawner = GameObject.FindGameObjectWithTag ("Spawner").GetComponent<SpawnScript>();
	}

    public void MainMenu()
    {
        CastUI = GameObject.FindGameObjectWithTag("CastUI");
        if (CastUI != null)
            CastUI.GetComponent<PauseMenu>().enabled = false;
        CastUI = GameObject.FindGameObjectWithTag("PauseUI");
        if (CastUI != null)
            CastUI.SetActive(false);
        CastUI = GameObject.FindGameObjectWithTag("Camera");
        if (CastUI != null)
            CastUI.GetComponent<EndlessRunnerCameraMovement>().enabled = false;
        Application.LoadLevel(0);

    }

	public void Restart(){
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
