using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask evilLayerMask;
    public Color goodColor = Color.green;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Change to GetMouseButtonDown to trigger only once per click
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, evilLayerMask))
            {
                if (hit.collider.CompareTag("EvilCharacter"))
                {
                    // Call the Goodify method of the EvilCharacter when hit
                    hit.collider.GetComponent<EvilCharacter>().Goodify(goodColor);
                }
            }
        }
    }
}