using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extrabehaviour : MonoBehaviour
{
    private PlayerController pcont;
    GameObject player;

    // Start is called before the first frame update

    void Start(){
        //Find the player Onject to get the controller assigned to it to edit its few variables
        player = GameObject.Find("Player");
        // Create an instance of the playercontroller
        pcont = player.GetComponent<PlayerController>();
    }
    int initrot = 0;

    private void Update() {
        if (initrot == 1){
            Vector3 contscale = GameObject.Find("ControlHold").transform.localEulerAngles;
            Quaternion iniScale = Quaternion.Euler (contscale.x, contscale.y, contscale.z);
            Quaternion newScale = Quaternion.Euler (contscale.x, contscale.y, 12);
            GameObject.Find("ControlHold").transform.localRotation = Quaternion.Lerp (iniScale, newScale, 3f * Time.deltaTime);

            if (contscale.z > 10){
                initrot = 3;
                Debug.Log("Stream Closed");
            }else{
                Debug.Log(contscale.z);
            }
        }
        // if (initrot == 2){
            
        //     Vector3 contscale = GameObject.Find("ControlHold").transform.localEulerAngles;
        //     Quaternion iniScale = Quaternion.Euler(contscale.x, contscale.y, z);
        //     Quaternion newScale = Quaternion.Euler(contscale.x, contscale.y, -12);
        //     GameObject.Find("ControlHold").transform.localRotation = Quaternion.Slerp (iniScale, newScale, 8f * Time.deltaTime);

        //     if (contscale.z < -10){
        //         initrot = 3;
        //         Debug.Log("Stream Closed");
        //     }else{
        //         Debug.Log(contscale.z);
        //     }
        // }
        if (initrot == 3 || initrot == 2){
            Vector3 contscale = GameObject.Find("ControlHold").transform.localEulerAngles;

            
            Quaternion iniScale = Quaternion.Euler (contscale.x, contscale.y, contscale.z);
            Quaternion newScale = Quaternion.Euler (contscale.x, contscale.y, 0);
            GameObject.Find("ControlHold").transform.localRotation = Quaternion.Lerp (iniScale, newScale, 3f * Time.deltaTime);

            if (contscale.z > -0.4 && contscale.z < 0.4){
                initrot = 0;
                GameObject.Find("ControlHold").transform.localRotation = Quaternion.Euler (contscale.x, contscale.y, 0);
                Debug.Log("Stream Closed");
            }else{
                Debug.Log(contscale.z);
            }
        }
        
    }
    
    private void OnMouseDown() {
        pcont.clickedActive = true;
        if (transform.name == "Right"){
            pcont.rotation = 1;
            initrot = 1;
        }
        if (transform.name == "Left"){
            pcont.rotation = -1;
            initrot = 2;
        }
    }
    void OnMouseUp(){
        pcont.clickedActive = false;
    }

}
