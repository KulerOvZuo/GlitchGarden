using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {	

    private float currentSpeed;
    private GameObject currentTarget = null;

    // Use this for self-initialization
	void Awake() {
	
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
        Debug.Log(name + " causeed dmg " + dmg);
    }
    public void SetSpeed(float speed){
        currentSpeed = speed;
    }
    public void Attack (GameObject obj){
        currentTarget = obj;

    }
}
