using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BoardControl : MonoBehaviour
{
    
    public int initPanelOpen = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if (initPanelOpen == 2){
            Vector3 contscale = GameObject.Find("PanelHold").transform.localScale;
            Vector3 iniScale = new Vector3 (contscale.x, contscale.y, contscale.z);
            Vector3 newScale = new Vector3 (1.8f, contscale.y, contscale.z);
            GameObject.Find("PanelHold").transform.localScale = Vector3.Lerp (iniScale, newScale, 2.5f * Time.deltaTime);

            if (contscale.x > 1.5){
                initPanelOpen = 1;
            }
        }

        //Ths is the game over!
        if (initPanelOpen == 3){
            Vector3 contscale = GameObject.Find("PanelHold").transform.localScale;
            Vector3 iniScale = new Vector3 (contscale.x, contscale.y, contscale.z);
            Vector3 newScale = new Vector3 (0, contscale.y, contscale.z);
            GameObject.Find("PanelHold").transform.localScale = Vector3.Lerp (iniScale, newScale, 3.5f * Time.deltaTime);

            if (contscale.x < 0.3){
                initPanelOpen = 1;
                GameObject.Find("PanelHold").transform.localScale = new Vector3 (0, contscale.y, contscale.z);
                GameManager.instance.Restart();
            }
        }

        if (Input.GetMouseButtonDown(0)){
        
            RaycastHit hit = new RaycastHit();
            var mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            
            LayerMask mask = LayerMask.GetMask("Control");
            if (Physics.Raycast(ray, out hit, 100000.0f)){
                if (hit.transform != null){
                    string clickedName = hit.transform.gameObject.name;
                    if (clickedName == "pcover"){
                        initPanelOpen = 3;
                    }
                    if (clickedName == "hcover"){
                        SceneManager.LoadScene("Menu");
                    }
                }
            }
        }
        
    }
}
