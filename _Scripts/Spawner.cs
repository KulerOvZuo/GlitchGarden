using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpawnContainer{
    public GameObject prefab;
    [HideInInspector]
    public bool canSpawn;

    public void resetTimer(){
        canSpawn = true;
    }      
}

public class Spawner : MonoBehaviour {	

    public SpawnContainer[] prefabs;

    void Start(){
        foreach (SpawnContainer thisAttacker in prefabs){
            Invoke("resetTimer",2f);
        }
    }
	// Update is called once per frame
	void Update () {
        foreach (SpawnContainer thisAttacker in prefabs){
            if(thisAttacker.canSpawn){
                thisAttacker.canSpawn = false;
                Spawn(thisAttacker.prefab);
                Invoke("resetTimer",2f);
            }
        }
	}

    void Spawn(GameObject obj){
        Instantiate(obj,transform.position,Quaternion.identity);
    }
}
