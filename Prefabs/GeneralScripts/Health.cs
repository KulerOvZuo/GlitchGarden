using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float HP;

    public void TakeDMG(float dmg){
        HP -= dmg;
        if(HP <= 0)
           Die();
    }
    public void Die(){
        Destroy (gameObject);
    }
}
