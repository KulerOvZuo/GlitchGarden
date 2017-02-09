using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {	

    private float currentSpeed;
    private GameObject currentTarget = null;
    private Animator animator;

    // Use this for self-initialization
	void Awake() {
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

    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log(collider.name);
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
