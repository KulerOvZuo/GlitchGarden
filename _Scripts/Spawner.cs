using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpawnContainer{

    public GameObject prefab;
    [HideInInspector]
    public float timeFromLastSpawn;

    private float seenEverySeconds;
    private float randomSpawnTime;

    public void Instantiate(){
        seenEverySeconds = prefab.GetComponent<Attacker>().seenEverySeconds*3f;
        timeFromLastSpawn = 0f;
        randomSpawnTime = Random.Range(seenEverySeconds*0.5f,seenEverySeconds);
    }

    public bool CanSpawn(){
        if(timeFromLastSpawn > randomSpawnTime){
            timeFromLastSpawn = 0f;
            randomSpawnTime = seenEverySeconds*(1 - Random.value*Random.value) + Random.Range(0f,seenEverySeconds*0.5f);
            return true;
        }
        return false;
    }
    public bool CanSpawnUpdateTime(){
        timeFromLastSpawn += Time.deltaTime;
        return CanSpawn();
    }
}

public class Spawner : MonoBehaviour {	

    public SpawnContainer[] prefabs;

   void Start(){
        foreach (SpawnContainer thisAttacker in prefabs){
            thisAttacker.Instantiate();
        }
    }
	// Update is called once per frame
	void Update () {
        foreach (SpawnContainer thisAttacker in prefabs){
            if(thisAttacker.CanSpawnUpdateTime())
                Spawn(thisAttacker.prefab);
        }
	}

    void Spawn(GameObject obj){
        Instantiate(obj,transform.position,Quaternion.identity);
    }
}
