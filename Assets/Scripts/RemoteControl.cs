using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; 

public class RemoteControl : MonoBehaviour
{

    public VideoPlayer vid; 
    public VideoClip Minions;
    public VideoClip Teletubbies; 
    public VideoClip Barney; 
    public VideoClip currentClip; 

    private int index; 
    private VideoClip[] shows; 
    // Start is called before the first frame update
    void Start()
    {
        index = 1; 
        vid.clip = Teletubbies; 
        currentClip = Teletubbies; 
        shows = new VideoClip[] {Minions, Teletubbies, Barney};
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { 
            if (index > 0) index--; 
            print(index); 
            print (shows[index]); 
            vid.clip = shows[index]; 
            currentClip = shows[index]; 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)){ 
            if (index < 2) index++; 
            print(index); 
            print (shows[index]); 
            vid.clip = shows[index]; 
            currentClip = shows[index]; 
        }
    }
}
