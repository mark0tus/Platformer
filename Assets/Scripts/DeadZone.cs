using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public GameMaster gm;

    private void Update()
    {
      //  spawnPoint = gm.lastCheckpointPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            collision.transform.position = spawnPoint.position;

    }
}
