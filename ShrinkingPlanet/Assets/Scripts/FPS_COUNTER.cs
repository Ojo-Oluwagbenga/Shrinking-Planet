using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_COUNTER : MonoBehaviour {
   
    // Set the number of seconds it takes to reset the value on the screen
    public float interv = 0.5f; 

    float addeds = 0.0f;
    int num_of_frames = 0;
    float time_remain; 
    float fps_value;

    //Create an instance of the display on the UI
    GUIStyle textStyle = new GUIStyle();


    void Start()
    {
        time_remain = interv;

        textStyle.fontStyle = FontStyle.Bold;
        textStyle.normal.textColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        time_remain -= Time.deltaTime;
        addeds += Time.timeScale / Time.deltaTime;
        ++num_of_frames;

        // This is called when the interval ends i.e reaches 0 as shown
        if (time_remain <= 0.0){
            fps_value = (addeds / num_of_frames);
            time_remain = interv;
            addeds = 0.0f;
            num_of_frames = 0;
        }
    }

    void OnGUI()
    {
        //This will display the fps_value in approx of 2 decimal places
        GUI.Label(new Rect(5, 5, 100, 25), (fps_value).ToString("F2") + "FPS", textStyle);
    }
}