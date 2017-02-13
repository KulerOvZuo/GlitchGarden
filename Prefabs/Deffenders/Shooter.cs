using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {	

    public GameObject projectile;
    private GameObject projectileParent = null;
    private Vector3 gunPosition;
    private Animator anim;
    public const string PROJECTILES_PARENT = "Projectiles";

    void Awake(){
        gunPosition = transform.FindChild("Gun").position;
        anim = GetComponent<Animator>();
    }

    void Start(){
        projectileParent = GameObject.Find(PROJECTILES_PARENT);
        if(!projectileParent){
            projectileParent = new GameObject(PROJECTILES_PARENT);
        }
    }

    void Update(){
        if(IsAttackerAheadInLine()){
            anim.SetBool("isAttacking", true);
        } else {
            anim.SetBool("isAttacking", false);
        }
    }

    private void Fire(){
        GameObject newProjectile = Instantiate (projectile,gunPosition,Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
    bool IsAttackerAheadInLine(){        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 15f, 1 << 8);
        if(hit.collider != null)
            return true;
        return false;
    }
}
