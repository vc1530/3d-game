using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] public int _charInTotal = 0;
    public float SceneChangeWaitTime = 2f;

    public string nextSceneName;
    private bool _sceneLoading = false;
    void Start()
    {
        var charList = GameObject.FindGameObjectsWithTag("EvilCharacter");
        foreach (var evilChar in charList)
        {
            print(evilChar.name);
        }
        _charInTotal = charList.Length;
        Debug.Log(_charInTotal);
        
        if (nextSceneName == "")
        {
            Debug.LogWarning("The next scene name is empty on " + gameObject.name);
        }
    }
    void Update()
    {
        if (PlayerMotor.goodCharCounter == _charInTotal && !_sceneLoading)
        {
            _sceneLoading = true;
            StartCoroutine(WaitAndChangeScene());
            Debug.Log("All GOOD");
        }
    }

    private IEnumerator WaitAndChangeScene()
    {
        yield return new WaitForSeconds(SceneChangeWaitTime);
        SceneManager.LoadScene(nextSceneName);
    }
}
