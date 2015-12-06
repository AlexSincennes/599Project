using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	public GameObject PauseUI;
	private GameObject CastUI;
    private GameObject RUI;
    private GameObject RemoteCam;

	private bool paused = false;
    public bool scoreui = false;
	// Update is called once per frame
    private static bool instance = false;
    private void Awake()
    {
        if (instance == false)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = true;

        }
        else
        {
            DestroyImmediate(this.gameObject);
        }

    }
	void Update () {
		if (CastUI == null)
			CastUI = GameObject.FindGameObjectWithTag ("CastUI");
		if (PauseUI == null)
			PauseUI = GameObject.FindGameObjectWithTag ("PauseUI");
        if (RUI == null)
            RUI = GameObject.FindGameObjectWithTag("RemoteUI");
		if(Input.GetButtonDown("Pause") && !scoreui && Application.loadedLevel != 0){
			paused = !paused;
            PauseSC();
		}
	}

	public void Resume(){
		paused = false;
        PauseSC();
	}

	public void Restart(){
		RemoteCam = GameManagerRG.Instance.RemoteCamera;
        RemoteCam.transform.parent = null;
		Application.LoadLevel (Application.loadedLevel);
        paused = !paused;
        PauseSC();
		if(Application.loadedLevel == 2)
			GameManager.Instance.curTimes++;
	}
	public void Exit(){
		Application.LoadLevel(0);
        paused = !paused;
        PauseSC();
        RUI.GetComponent<Canvas>().enabled = true;
        CastUI.GetComponent<Canvas>().enabled = true;
        CastUI = GameObject.FindGameObjectWithTag("RemoteUI");
        CastUI.GetComponent<PauseMenu>().enabled = false;
        CastUI = GameObject.FindGameObjectWithTag("PauseUI");
        if (CastUI != null)
            CastUI.SetActive(false);
		CastUI = GameManagerRG.Instance.RemoteCamera;
        CastUI.transform.parent = null;
        CastUI.transform.position = new Vector3(0.0f,2.5f,-10.0f);
        CastUI = null;  
	}

    void PauseSC()
    {
        if (paused)
        {
            PauseUI.SetActive(true);
            CastUI.GetComponent<Canvas>().enabled = true;
            RUI.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            PauseUI.SetActive(false);
            RUI.GetComponent<Canvas>().enabled = false;
            CastUI.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1.5f;
        }
    }
}
