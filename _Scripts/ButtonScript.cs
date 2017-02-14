using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {	

    public static GameObject deffender = null;

    public GameObject prefab;
    private SpriteRenderer sprite;
    private Color defColor = new Color(0.3f,0.3f,0.3f,1f);
    private ButtonScript[] buttonArray;
    
    void Awake(){
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = defColor;
        GetComponentInChildren<Text>().text = prefab.GetComponent<Deffenders>().cost.ToString();
    }

    void Start(){
        buttonArray = GameObject.FindObjectsOfType<ButtonScript>();
    }

    void OnMouseDown(){
        foreach(ButtonScript button in buttonArray){
            button.GetComponent<SpriteRenderer>().color = defColor;
        }
        if(deffender != prefab){ //change deffender
            sprite.color = Color.white;
            deffender = prefab;
        } else { //unclick deffender
            deffender = null;
        }
    }
}
