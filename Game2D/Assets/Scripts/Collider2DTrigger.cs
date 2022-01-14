using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2DTrigger : MonoBehaviour
{
    public LayerMask layerMask;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.IsTouchingLayers)
        {

        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}