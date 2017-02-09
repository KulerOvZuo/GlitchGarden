using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {	

    public float speed, dmg;

	// Update is called once per frame
	void Update () {
        transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider){
        GameObject obj = collider.gameObject;
        if(obj.GetComponent<Attacker>()){
           Health health = obj.GetComponent<Health>();
            if(health){
                health.TakeDMG(dmg);
                Destroy (gameObject);
            }
        }
    }
    
}
