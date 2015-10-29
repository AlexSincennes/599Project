using UnityEngine;
using System.Collections;

public class BulletTest_P : MonoBehaviour {
	public Transform shooter;
    //private float dis;
    //private Vector3 targetposion;
    //private bool isLeft = false;
    public int i=0;
	public static GameObject spawnpoint = null;
	public static GameObject player = null;
	public static Vector3 spawn;
	public Transform enemy;
    public float speed=5;
	private Vector3 oriSpeed;
	private Rigidbody2D myRigid;
    private Vector3 angle;
	public float liveTime;
	private float startTime;
    public bool ifKeepShooting=false;
    public bool ifHardCodeAngle = false;
    float dirEuler;
	public float angleKeepShooting=0;
    public float angleHardCode = 0;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        myRigid = this.GetComponent<Rigidbody2D>();

        if (ifKeepShooting)
            dirEuler = angleKeepShooting;
        else if (ifHardCodeAngle)
            dirEuler = angleHardCode;
        else
        {
            Vector3 enemyPos = enemy.transform.position - shooter.transform.position;

            float ymax = -speed * speed / 2 / Physics.gravity.y + Physics.gravity.y * enemyPos.x * enemyPos.x / 2 / speed / speed;
            if (enemyPos.y > ymax)
                dirEuler = Mathf.Sign(enemyPos.x) * Mathf.PI / 4;
            else
            {
                dirEuler = Mathf.Acos(enemyPos.y / enemyPos.magnitude) * Mathf.Sign(enemyPos.x);
                float delta = dirEuler / 10f;// * Mathf.Sign(enemyPos.x);

                while (enemyPos.x * Mathf.Cos(dirEuler) / Mathf.Sin(dirEuler) + enemyPos.x * enemyPos.x / Mathf.Sin(dirEuler) / Mathf.Sin(dirEuler) * Physics.gravity.y / 2.0f / speed / speed - enemyPos.y < 0 && Mathf.Abs(dirEuler) > 0.01f)
                    dirEuler -= delta;

                delta *= 0.5f;
                dirEuler += delta;

                while (true)
                {
                    float temp = enemyPos.x * Mathf.Cos(dirEuler) / Mathf.Sin(dirEuler) + enemyPos.x * enemyPos.x / Mathf.Sin(dirEuler) / Mathf.Sin(dirEuler) * Physics.gravity.y / speed / speed / 2.0f - enemyPos.y;
                    if (Mathf.Abs(temp) < 0.05f)
                        break;
                    delta *= 0.5f;
                    if (temp > 0)
                        dirEuler += delta;
                    else
                        dirEuler -= delta;
                }
            }
        }
        angle=transform.eulerAngles = new Vector3(0, 0, -dirEuler * Mathf.Rad2Deg);
        myRigid.velocity=oriSpeed = new Vector2 (speed * Mathf.Sin (dirEuler), speed * Mathf.Cos (dirEuler));


    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Time.time - startTime > liveTime) 
		{
			Destroy(this.transform.parent.gameObject);
		}
        if (myRigid.velocity.magnitude < 10) return;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Acos(oriSpeed.y/oriSpeed.magnitude) * Mathf.Sign(oriSpeed.x) * Mathf.Rad2Deg);
        oriSpeed = myRigid.velocity;
        transform.eulerAngles = new Vector3(0, 0, -Mathf.Acos(oriSpeed.y / oriSpeed.magnitude) * Mathf.Sign(oriSpeed.x) * Mathf.Rad2Deg);


    }



	void OnCollisionEnter2D(Collision2D other) 
	{
		//Debug.Log (myRigid.velocity.magnitude +"lala");
		if (other.gameObject.tag == "Player" && myRigid.velocity.magnitude > 1 && shooter.name != "Shield") 
		{
			//Debug.Log(shooter.name);
			//player = other.gameObject;
			//if(spawnpoint!=null)
				//spawn = spawnpoint.transform.position;
			//Debug.Log("lala");
			HitBox_2D health = other.gameObject.GetComponent<HitBox_2D>();
			if (health != null) health.Damage(1);



		}
		if (other.gameObject.tag == "Shield" && shooter.name != "Shield") {
			//Debug.Log (other.transform.name +"------------hahaha" + shooter.name );
			ShieldControl2D temp = other.transform.parent.gameObject.GetComponentInChildren<ShieldControl2D>();
			//other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>().reflectItem = this.transform.parent.gameObject;
			if(temp.shieldEquip )
			{
				//temp.attacker = shooter;
				//temp.canReflect = true;
				//temp.startClock = true;
				transform.GetComponent<BoxCollider2D>().isTrigger = true;
				myRigid.velocity = -oriSpeed;
				transform.GetComponent<BoxCollider2D>().isTrigger = false;
				//transform.GetComponent<Rigidbody>().c
				//transform.GetComponent<Rigidbody>().isKinematic = false;
				shooter = other.transform;
			}


			//Destroy(transform.parent.gameObject);
			
		}

		if (other.gameObject.tag == "Enemy" && shooter.name == "Shield") 
		{
			Destroy(other.transform.parent.gameObject);
			Destroy(transform.parent.gameObject);
		}

		if (other.gameObject.tag == "Terrain") 
		{
			transform.GetComponent<Rigidbody2D>().velocity =Vector2.zero;
			transform.GetComponent<Rigidbody2D>().isKinematic = true;
			transform.GetComponent<BoxCollider2D>().enabled = false;
		}
	}


}
