using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpawnContainer{

    public GameObject prefab;
    [HideInInspector]
    public float timeFromLastSpawn;

    public float seenEverySeconds;
    private float randomSpawnTime;

    public void Instantiate(){
        switch((int)PlayerPrefsManager.GetDifficulty()){
        case 1:
            seenEverySeconds = prefab.GetComponent<Attacker>().seenEverySeconds*3f;
            break;
        case 2:
            seenEverySeconds = prefab.GetComponent<Attacker>().seenEverySeconds*2.7f;
            break;
        case 3:
            seenEverySeconds = prefab.GetComponent<Attacker>().seenEverySeconds*2.4f;
            break;
        }
        timeFromLastSpawn = 0f;
        randomSpawnTime = Random.Range(seenEverySeconds*1.5f,seenEverySeconds*2f);
    }

    public bool CanSpawn(){
        if(timeFromLastSpawn > randomSpawnTime){
            timeFromLastSpawn = 0f;
            seenEverySeconds *= 0.95f;
            if(seenEverySeconds < 2f)
                seenEverySeconds = 2f;
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
