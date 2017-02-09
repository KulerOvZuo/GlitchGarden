﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Attacker attackerScript;
    private Animator animator;
	// Use this for self-initialization
	void Awake() {
        attackerScript = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider){
        GameObject obj = collider.gameObject;
        if(obj.GetComponent<Deffenders>()){
           if(obj.GetComponent<Stone>())
                Jump();
           else{
                animator.SetBool("isAttacking",true);
                attackerScript.Attack(obj);
           }
        }
    }
    void Jump(){
        animator.SetTrigger("Jump");
    }
}
