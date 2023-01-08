using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportModule : MonoBehaviour
{
    [SerializeField] private float _teleportTimeRange;
    [SerializeField] private List<Transform> _upPositions;
    [SerializeField] private List<Transform> _downPositions;
    [SerializeField] private List<Transform> _leftPositions;
    [SerializeField] private List<Transform> _rightPositions;
    private int currentSidePositon;

    private void Start()
    {
        currentSidePositon = 1;
        InvokeRepeating("Teleport", 0, _teleportTimeRange);
    }
    private void Teleport()
    {
        int randomPositionList = VerifySide(Random.Range(0, 3));
        currentSidePositon = randomPositionList;

        if (currentSidePositon == 0)
        {
            this.transform.position = _upPositions[Random.Range(0, _upPositions.Count - 1)].position;
        }
        else if (currentSidePositon == 1)
        {
            this.transform.position = _downPositions[Random.Range(0, _downPositions.Count - 1)].position;
        }
        else if (currentSidePositon == 2)
        {
            this.transform.position = _leftPositions[Random.Range(0, _leftPositions.Count - 1)].position;
        }
        else if (currentSidePositon == 3)
        {
            this.transform.position = _rightPositions[Random.Range(0, _rightPositions.Count - 1)].position;
        }
    }
    private int VerifySide(int drawnSide)
    {
        if (drawnSide != currentSidePositon)
        {
            return drawnSide;
        }
        else
        {
            do
            {
                drawnSide = Random.Range(0, 3);
            }
            while (drawnSide == currentSidePositon);
        }
        return drawnSide;
    }
}
