using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {	

    private LevelManager levelManager;

    void Start(){
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.layer == 8)
            levelManager.LoadLevel("03b_Lose");
        else
            Destroy (collider.gameObject);
    }
}
