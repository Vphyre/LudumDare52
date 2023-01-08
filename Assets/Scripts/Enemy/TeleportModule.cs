using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportModule : MonoBehaviour
{
    [SerializeField] private float _teleportTimeRange;
    [SerializeField] private List<Transform> teleportPositions;

    private void Start()
    {
        InvokeRepeating("Teleport", 0, _teleportTimeRange);
    }
    private void Teleport()
    {
        int randomPosition = Random.Range(0, teleportPositions.Count - 1);
        this.transform.position = teleportPositions[randomPosition].position;
    }
}
