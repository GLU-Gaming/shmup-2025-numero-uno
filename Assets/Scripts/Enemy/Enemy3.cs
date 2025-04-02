using UnityEngine;

public class Enemy3 : EnemyBehaviourBase
{
    [SerializeField] private float speed;
    private float movementTimer = 0;
    public float shootTimer = 0;
    public GameObject bulletobj;
    public Transform bulletspawn1;
    public Transform bulletspawn2;

    public new void Start()
    {
        base.Start();
        shoots = true;
    }
    void OnEnable() // put things that are normally in Start here
    {
        movementTimer = 0;
    }

    public override void MoveBehaviour() // set movement code here
    {
        movementTimer += Time.deltaTime;

        
    }
    public override void OnDeath()
    {

    }



    }
