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
    /*void CalculateJumpLine()
    {
        float g = rigidbody2D.gravityScale * Physics2D.gravity.magnitude;
        float v0 = jumpForce / rigidbody2D.mass; // converts the jumpForce to an initial velocity
        float maxJump_y = groundCheck.position.y + (v0 * v0) / (2 * g);

        // For Debug.DrawLine in FixedUpdate :
        lineStart = new Vector3(-100, maxJump_y, 0);
        lineEnd = new Vector3(100, maxJump_y, 0);
    }*/
}
