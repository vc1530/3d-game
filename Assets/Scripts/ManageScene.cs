using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{

    FadeInOut fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    }
    //}

    public IEnumerator ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("EndScreen");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DoExitGame()
    {
        Application.Quit();
        //Debug.Log("Quit Game");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        if (sceneName == "EndScreen")
        {
            StartCoroutine(ChangeScene());
        }
        //Debug.Log("Loaded Scene: " + sceneName);
    }

}
