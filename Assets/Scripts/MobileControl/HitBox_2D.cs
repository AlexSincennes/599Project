using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// A hit box takes damage and passes it to a health component for processing.
/// This allows you to easily move the damage points or alternatively attach
/// them to transforms.
///
///	A hit box can also be used to collect items. Although at the moment the collect method
/// doesn't do anything. You could sue this to grant powers, increment counters, etc.
/// </summary>
public class HitBox_2D : MonoBehaviour {
    private Text Score;
    private GameObject ScoreScreen;
    private GameObject BashPlane;
    private GameObject PauseUI;
	//public SimpleHealth simplehealth;
	//public BashManager bashManager;

	public virtual void Damage(int amount) {
        Time.timeScale = 0;
        Score = GameObject.Find("Canvas").transform.FindChild("ScoreScreen").transform.FindChild("HighScore").GetComponent<Text>();
		ScoreScreen = GameObject.Find("Canvas").transform.FindChild("ScoreScreen").gameObject;
		ScoreScreen.SetActive (true);

        ScoreScreen = GameObject.FindGameObjectWithTag("RemoteUI");
		if(ScoreScreen != null)
        	ScoreScreen.GetComponent<Canvas>().enabled = true;

        BashPlane = GameObject.Find("ScoreCalculator");
        int curmeter = BashPlane.GetComponent<BashManager>().curMeter;
        if(curmeter > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore",curmeter);
        Score.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
		Score = GameObject.Find("ScoreScreen/YourScore").GetComponent<Text>();
		Score.text = "Your Score : " + curmeter.ToString();
        PauseUI = GameObject.FindGameObjectWithTag("RemoteUI");
        if (PauseUI != null)
        {
            PauseUI.GetComponent<PauseMenu>().scoreui = true;
        }
		//Application.LoadLevel(Application.loadedLevel);
		//GameManager.Instance.deathPos = transform.parent.position;
		//if(Application.loadedLevel == 2)
		//GameManager.Instance.curTimes++;

		//GameManager.Instance.player.GetComponent<RaycastCharacterController>().Stun (1f);
	}

	public virtual void Collect (Collectable2D collectable) {
		//Debug.Log ("Collect "+ collectable.transform.parent.name+" !!!!!!!!!!");
		//bashManager.UpdateBashMeter (10.0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log (other.gameObject.tag );
		if (other.gameObject.tag == "Enemy") 
		{
			Application.LoadLevel(Application.loadedLevel);
			//GameManager.Instance.deathPos = transform.parent.position;
			//if(Application.loadedLevel == 2)
			//GameManager.Instance.curTimes++;

			//GameManager.Instance.player.GetComponent<RaycastCharacterController>().Stun (1f);
		}
		
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log (other.gameObject.tag );
	}

	public void Die()
	{
        Time.timeScale = 0;
		Score = GameObject.Find("Canvas").transform.FindChild("ScoreScreen").transform.FindChild("HighScore").GetComponent<Text>();
		ScoreScreen = GameObject.Find("Canvas").transform.FindChild("ScoreScreen").gameObject;
		ScoreScreen.SetActive (true);

        ScoreScreen = GameObject.FindGameObjectWithTag("RemoteUI");
		if(ScoreScreen != null)
        	ScoreScreen.GetComponent<Canvas>().enabled = true;
        BashPlane = GameObject.Find("ScoreCalculator");
        int curmeter = BashPlane.GetComponent<BashManager>().curMeter;
        if (curmeter > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", curmeter);
        Score.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
		Score = GameObject.Find("ScoreScreen/YourScore").GetComponent<Text>();
		Score.text = "Your Score : " + curmeter.ToString ();
        PauseUI = GameObject.FindGameObjectWithTag("CastUI");
        if (PauseUI != null)
        {
            PauseUI.GetComponent<PauseMenu>().scoreui = true;
        }
	}


}
