using UnityEngine;
using UnityEditor;

public class GoodCharacter : MonoBehaviour
{
    public GameObject evilCharacter; 
    public LayerMask groundLayer;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            // Move the character to the point where the ray hit the ground.
            transform.position = hit.point;
        }
    }

    void OnCollisionEnter(Collision col) { 
        if (col.gameObject.CompareTag("EvilCharacter")) { 
            Evilify(); 
        }
    }

    public void Evilify()
    {
        PlayerMotor.goodCharCounter -= 1;
        print("evilifying"); 
        print(PlayerMotor.goodCharCounter); 
        gameObject.SetActive(false); 
        evilCharacter.GetComponent<EvilCharacter>().isGood = false; 
        evilCharacter.SetActive(true); 
    }
}