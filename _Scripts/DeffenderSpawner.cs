using UnityEngine;
using System.Collections;

public class DeffenderSpawner : MonoBehaviour {	

    private StarScript starDisplay;

    void Start(){
        starDisplay = GameObject.FindObjectOfType<StarScript>();
    }

    void OnMouseDown(){
        GameObject deffender = ButtonScript.deffender;
        if(deffender){
            if(starDisplay.SpendStars(deffender.GetComponent<Deffenders>().cost) == StarScript.Status.SUCCESS)
                Instantiate(ButtonScript.deffender,SnapToWorldPoint(),Quaternion.identity);
        }
    }

    Vector3 SnapToWorldPoint(){
        Vector3 vector = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f))
                            - new Vector3(0.5f,0.5f,10f);
        return new Vector3(Mathf.CeilToInt(vector.x), Mathf.CeilToInt(vector.y),0f);
    }
}
