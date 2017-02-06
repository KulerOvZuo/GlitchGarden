using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

    void Awake(){
        //Debug.Log ("music awake " + GetInstanceID());
        if (instance != null && instance != this){
            Destroy(gameObject);
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.Play();
        }     
    }

	void Start(){
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*void OnLevelWasLoaded(int level){
        Debug.Log(level);
        if(!music){
            music = GetComponent<AudioSource>();
            music.enabled = true;
        }
        music.Stop();
        switch(level){
            case 0: music.clip = startClip; break;
            case 1: music.clip = gameClip; break;
            case 2: music.clip = endClip; break;
        }
        music.Play();
    }*/
}
