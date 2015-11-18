using UnityEngine;
using System.Collections;

public class ScoreScreen : MonoBehaviour {
    private GameObject CastUI;
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
    public void Exit()
    {
        Application.Quit();
    }
}
