using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {	

    public GameObject projectile;
    private GameObject projectileParent = null;
    private Vector3 gunPosition;
    public const string PROJECTILES_PARENT = "Projectiles";

    void Awake(){
        gunPosition = transform.FindChild("Gun").position;
    }

    void Start(){
        projectileParent = GameObject.Find(PROJECTILES_PARENT);
        if(!projectileParent){
            projectileParent = new GameObject(PROJECTILES_PARENT);
        }
    }

    private void Fire(){
        GameObject newProjectile = Instantiate (projectile,gunPosition,Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
