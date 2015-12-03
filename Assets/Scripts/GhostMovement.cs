using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {
	
	public GameObject player;
    public GameObject RemoteCam;
    public GameObject MainCam;
    public bool playerSlowed = false;
	
	public float currentMovementSpeed;
	public float acceleration = 0.5f;
	public float startMovementSpeed = 7f;
	public float maxMovementSpeed = 30f;
	public float movementSpeedX;
    public float mX, mY;
	public float movementSpeedY = 0f;
    private Vector3 velocity;
    void Awake()
    {
        RemoteCam = GameObject.FindGameObjectWithTag("Camera");
        MainCam = GameObject.FindGameObjectWithTag("MainCamera");
        if (RemoteCam != null)
        {
            RemoteCam.transform.position = MainCam.transform.position;
            RemoteCam.transform.parent = this.transform;
        }
    }
	void Start(){
		player.GetComponent<RaycastCharacterController2D>().movement.walkSpeed = startMovementSpeed;
		currentMovementSpeed = startMovementSpeed;
		movementSpeedY = 0f;
		movementSpeedX = currentMovementSpeed;
        velocity = new Vector3(0,0,0);
	}

	// Update is called once per frame
	void LateUpdate () {
		float frameTime = RaycastCharacterController2D.FrameTime;
		transform.position = Vector3.SmoothDamp(transform.position, new Vector3((transform.position.x + Vector3.right.x * movementSpeedX * frameTime), (transform.position.y + Vector3.up.y * movementSpeedY * frameTime), this.transform.position.z), ref velocity, 0.00001f);
        
        //transform.Translate(Vector3.right * movementSpeedX * Time.deltaTime + Vector3.up * movementSpeedY * Time.deltaTime);
		//Check if the player is too behind or ahead of the ghost.  Adjust speed of the player as necessary
		if (!playerSlowed) {
			float diff = this.transform.position.x - player.transform.position.x;
			player.GetComponent<RaycastCharacterController2D> ().movement.walkSpeed = currentMovementSpeed * (1 + Mathf.Clamp(diff, -0.25f, 0.25f));
			/*if (player.transform.position.x < this.transform.position.x - 0.5f) {
				player.GetComponent<RaycastCharacterController2D> ().movement.walkSpeed = currentMovementSpeed * 1.25f;
			} else if (player.transform.position.x > this.transform.position.x + 0.5f) {
				player.GetComponent<RaycastCharacterController2D> ().movement.walkSpeed = currentMovementSpeed * 0.75f;
			} else {
				player.GetComponent<RaycastCharacterController2D> ().movement.walkSpeed = currentMovementSpeed;
			}*/
		}
	}
}
