using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {	

    private float currentSpeed;
    [Tooltip ("Average seconds between spawn")]
    public float seenEverySeconds;
    private GameObject currentTarget = null;
    private Animator animator;

    public const string ATTACKERS_PARENT = "Attackers";
    private GameObject attackersParent = null;

    // Use this for self-initialization
	void Awake() {
        attackersParent = GameObject.Find(ATTACKERS_PARENT);
        if(!attackersParent){
            attackersParent = new GameObject(ATTACKERS_PARENT);
        }
        gameObject.transform.parent = attackersParent.transform;

        animator = GetComponent<Animator>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move(){
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }


    public void StrikeCurrentTarget(float dmg){
        if(currentTarget){
            Health health = currentTarget.GetComponent<Health>();
            if(health)
                health.TakeDMG(dmg);
        } else {
            animator.SetBool("isAttacking",false);
        }
    }
    public void SetSpeed(float speed){
        currentSpeed = speed;
    }
    public void Attack (GameObject obj){
        currentTarget = obj;
    }
}
