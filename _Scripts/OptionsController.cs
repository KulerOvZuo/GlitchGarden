using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {	

    public Slider volume;
    public Slider difficulty;
    public LevelManager levelManager;

    private MusicManager musicManager;
    
    // Use this for self-initialization
	void Awake() {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volume.value = PlayerPrefsManager.GetMasterVolume();
        difficulty.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.SetVolume(volume.value);
	}

    
    public void SetDefaults(){
        volume.value = PlayerPrefsManager.MASTER_VOLUME_DEF;
        difficulty.value = PlayerPrefsManager.DIFFICULTY_DEF;
    }
    public void SaveAndExit(){
        PlayerPrefsManager.SetMasterVolume(volume.value);
        PlayerPrefsManager.SetDifficulty(difficulty.value);
        levelManager.LoadLevel("01a_Start");
    }
}
