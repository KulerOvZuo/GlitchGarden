using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {	

    public float timeToWin = 100f;
    private float secondsFromStart = 0f;
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;
    // Use this for self-initialization
	void Awake() {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("Win");
        if(!winLabel)
            Debug.LogWarning("No win label");
        else
            winLabel.SetActive(false); 
	}
	
	// Update is called once per frame
	void Update () {
        secondsFromStart += Time.deltaTime;
        slider.value = secondsFromStart/timeToWin;
        if(secondsFromStart >= timeToWin && !isEndOfLevel){ 
            EndLevel();
        }
	}
    void EndLevel(){        
        isEndOfLevel = true;
        DestroyAllUnneseccaryObjects();
        audioSource.Play();
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Shredder")){
            obj.SetActive(false);
        }
        winLabel.SetActive(true);
        Invoke("LoadNextLevel",4f);
    }
    void DestroyAllUnneseccaryObjects(){
        Destroy(GameObject.Find(Shooter.PROJECTILES_PARENT));
        Destroy(GameObject.Find(Attacker.ATTACKERS_PARENT));
        Destroy(GameObject.Find(Deffenders.DEFFENDERS_PARENT));
    }
    void LoadNextLevel(){
        levelManager.LoadNextLevel();
    }
}
