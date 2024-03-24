using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameBehavior : MonoBehaviour
{

    public static GameBehavior Instance; 
    // Start is called before the first frame update
    private void Awake() { 
        if (Instance == null) { 
            Instance = this; 
        } else if (Instance != this) { 
            Destroy(gameObject); 
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sceneToMoveTo() {
        SceneManager.LoadScene("Scene2"); 
    }
}
