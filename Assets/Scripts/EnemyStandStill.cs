using UnityEngine;
using System.Collections;

public class EnemyStandStill : MonoBehaviour {
    public const int WALK = 1;
    public const int ATTACK = 2;
    public const int IDLE = 3;
    public const int GETHIT = 4;

    public float attackDis;
    public float patrolDis;
    public Vector3 targetPosition;
    public Vector3 startPosition;
    public float Speed = 0;
    public float RotateSpeed = 10;
    public GameObject Bullet;
    public Transform Bow;
    public float attackRate;

    public int state = WALK;
    public bool moveLeft = true;
    private bool canAttack = false;
    private float lastAttackTime = 0;

    public static Transform player = null;


    // Use this for initialization
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case WALK:
                break;
            case ATTACK:
                if (Time.time - lastAttackTime > attackRate)
                {
                    GameObject temp = (GameObject)Instantiate(Bullet, Bow.position, Bullet.transform.rotation);
                    temp.transform.GetComponentInChildren<BulletTest>().shooter = this.transform;
                    temp.transform.GetComponentInChildren<BulletTest>().enemy = player;
                    lastAttackTime = Time.time;
                }
                //temp.transform.parent = this.transform;
                //SetState(IDLE);
                break;
            case IDLE:

                break;
            case GETHIT:

                break;
        }

        //targetPosition.y = transform.position.y;
        //
        //Quaternion rotationTarget = Quaternion.LookRotation((targetPosition - this.transform.position).normalized);
        //transform.rotation = Quaternion.Lerp(this.transform.rotation,rotationTarget,Time.deltaTime * 5);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * Speed);

    }

    public void SetState(int state)
    {
        if (this.state == state)
            return;
        this.state = state;
    }
}
