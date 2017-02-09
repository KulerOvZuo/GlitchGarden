using UnityEngine;
using System.Collections;

public class DeffenderSpawner : MonoBehaviour {	


    void OnMouseDown(){
        if(ButtonScript.deffender)
            Instantiate(ButtonScript.deffender,SnapToWorldPoint(),Quaternion.identity);
    }

    Vector3 SnapToWorldPoint(){
        Vector3 vector = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)) - new Vector3(0.5f,0.5f,10f);
        return new Vector3(Mathf.CeilToInt(vector.x), Mathf.CeilToInt(vector.y),0f);
    }
}
