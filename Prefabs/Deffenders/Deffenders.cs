using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Health))]
public class Deffenders : MonoBehaviour {

    public const string DEFFENDERS_PARENT = "Deffenders";
    private GameObject deffendersParent = null;
    public int cost;

    private StarScript starDisplay;
	// Use this for self-initialization
	void Awake() {
        deffendersParent = GameObject.Find(DEFFENDERS_PARENT);
        if(!deffendersParent){
            deffendersParent = new GameObject(DEFFENDERS_PARENT);
        }
        gameObject.transform.parent = deffendersParent.transform;
	}
	
	// Use this for initialization
	void Start () {
        starDisplay = GameObject.FindObjectOfType<StarScript>();
	}


    public void AddStart(int amount){
        starDisplay.AddStars(amount);
    }

}
