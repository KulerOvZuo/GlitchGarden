using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {	

    const string MASTER_VOLUME_KEY = "master_volume";
    public const float MASTER_VOLUME_DEF = 0.6f;
    const string DIFFICULTY_KEY = "difficulty";
    public const float DIFFICULTY_DEF = 2f;
    const string LEVEL_KEY = "level_unlocked_"; //level_unlocked_2

    public static void SetMasterVolume(float volume){
        if(volume >= 0f && volume <= 1f)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else Debug.LogError("Master volume out of range");
    }
    public static float GetMasterVolume(){
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level){
        if(level < SceneManager.sceneCountInBuildSettings)
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //use 1 for true
        else Debug.LogError("Trying to unlock unexisted level");
    }
    public static bool IsLevelUnlocked(int level){
        if(level < SceneManager.sceneCountInBuildSettings){
            if(PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1)
                return true;
        } else {
            Debug.LogError("Level doesn't exist");
        }
        return false;
    }

    public static void SetDifficulty(float diff){
        if(diff >= 1f && diff <= 3f)
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        else Debug.LogError("Difficulty out of range");
    }
    public static float GetDifficulty(){
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
