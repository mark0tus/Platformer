using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDistance : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 6);
    }
}
