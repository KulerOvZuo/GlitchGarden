using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarScript : MonoBehaviour {	

    private Text text;
    private int starsAmount;
    public enum Status {SUCCESS, FAILURE};
    // Use this for self-initialization
	void Awake() {
        text = GetComponent<Text>();
        starsAmount = 300;
	} 
    void Start(){
        UpdateDisplay();
    }
    public void AddStars(int amount){
        starsAmount += amount;
        UpdateDisplay();
    }
    public Status SpendStars(int amount){
        if(starsAmount >= amount){
            starsAmount-= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateDisplay(){
        text.text = starsAmount.ToString();
    }
}
