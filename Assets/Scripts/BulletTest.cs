using UnityEngine;
using System.Collections;

public class BulletTest : MonoBehaviour {
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
	private Rigidbody myRigid;
    private Vector3 angle;
	public float liveTime;
	private float startTime;
    public bool ifKeepShooting=false;
    float dirEuler;
	public float angleKeepShooting=0;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        myRigid = this.GetComponent<Rigidbody>();
		if (spawnpoint == null)
			spawnpoint = GameObject.FindGameObjectWithTag ("Spawn");
        if (!ifKeepShooting)
        {
            Vector3 enemyPos = enemy.transform.position - shooter.transform.position;
            dirEuler = Mathf.Acos(enemyPos.y / enemyPos.magnitude) * Mathf.Sign(enemyPos.x);
            float delta = dirEuler / 10f;// * Mathf.Sign(enemyPos.x);

            while (enemyPos.x * Mathf.Cos(dirEuler) / Mathf.Sin(dirEuler) + enemyPos.x * enemyPos.x / Mathf.Sin(dirEuler) / Mathf.Sin(dirEuler) * Physics.gravity.y / 2.0f / speed / speed - enemyPos.y < 0 && Mathf.Abs(dirEuler)>0.01f)
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
        else
        {
            dirEuler = angleKeepShooting;
        }
        angle=transform.eulerAngles = new Vector3(0, 0, -dirEuler * Mathf.Rad2Deg);
        myRigid.velocity=oriSpeed = new Vector3 (speed * Mathf.Sin (dirEuler), speed * Mathf.Cos (dirEuler), 0);


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



    void OnCollisionEnter(Collision other) 
	{
		//Debug.Log (other.gameObject.tag +"lala");
		if (other.gameObject.tag == "Player" && myRigid.velocity.magnitude > 1) 
		{
			//player = other.gameObject;
			//if(spawnpoint!=null)
				//spawn = spawnpoint.transform.position;
			HitBox health = other.gameObject.GetComponent<HitBox>();
			if (health != null) health.Damage(1);



		}
		if (other.gameObject.tag == "Shield" && shooter.name != "Shield") {
			//Debug.Log (other.transform.name +"------------hahaha" + shooter.name );
			ShieldTest temp = other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>();
			//other.transform.parent.gameObject.GetComponentInChildren<ShieldTest>().reflectItem = this.transform.parent.gameObject;
			if(temp.shieldEquip)
			{
				//temp.attacker = shooter;
				//temp.canReflect = true;
				//temp.startClock = true;
				transform.GetComponent<CapsuleCollider>().isTrigger = true;
				myRigid.velocity = -oriSpeed;
				transform.GetComponent<CapsuleCollider>().isTrigger = false;
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


	}


}
