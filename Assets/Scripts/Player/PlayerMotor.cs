using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller; 
    private Vector3 playerVelocity; 
    private bool isGrounded; 

    public GameObject TV; 
    public float speed = 5f; 
    public float gravity = -9.8f; 
    public float jumpHeight = 3f;

    public static int goodCharCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
        goodCharCounter = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded; 
    }

    public void OnCollisionEnter(Collision col) { 
        if (col.gameObject.tag == "TV") { 
            print(TV.GetComponent<RemoteControl>().currentClip); 
            switch (TV.GetComponent<RemoteControl>().currentClip.name) { 
                case "Teletubbies": 
                    SceneManager.LoadScene("EvilTeletubbiesForest"); 
                    break; 
                case "Minions": 
                    SceneManager.LoadScene("EvilMinionMap"); 
                    break; 
                case "Barney": 
                    SceneManager.LoadScene("EvilBarney"); 
                    break; 
            }
        } 
    }

    public void ProcessMove(Vector2 input) { 
        Vector3 moveDirection = Vector3.zero; 
        moveDirection.x = input.x; 
        moveDirection.z = input.y; 
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime); 
        playerVelocity.y += gravity * Time.deltaTime; 
        if (isGrounded && playerVelocity.y < 0) { 
            playerVelocity.y = -2f; 
        }
        controller.Move(playerVelocity * Time.deltaTime); 
    }
    public void Jump () { 
        if (isGrounded) { 
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);  
        }
    }

}
