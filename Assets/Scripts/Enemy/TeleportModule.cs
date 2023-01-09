using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportModule : MonoBehaviour
{
    [SerializeField] private float _teleportTimeRange;
    [SerializeField] private GameObject[] _upPositions;
    [SerializeField] private GameObject[] _downPositions;
    [SerializeField] private GameObject[] _leftPositions;
    [SerializeField] private GameObject[] _rightPositions;
    private int currentSidePositon;

    private void Start()
    {
        currentSidePositon = 1;
        InvokeRepeating("Teleport", 0, _teleportTimeRange);
        _upPositions = GameObject.FindGameObjectsWithTag("UP");
        _downPositions = GameObject.FindGameObjectsWithTag("DOWN");
        _leftPositions = GameObject.FindGameObjectsWithTag("LEFT");
        _rightPositions = GameObject.FindGameObjectsWithTag("RIGHT");
    }
    private void Teleport()
    {
        int randomPositionList = VerifySide(Random.Range(0, 3));
        currentSidePositon = randomPositionList;

        if (currentSidePositon == 0)
        {
            this.transform.position = _upPositions[Random.Range(0, _upPositions.Length - 1)].transform.position;
        }
        else if (currentSidePositon == 1)
        {
            this.transform.position = _downPositions[Random.Range(0, _downPositions.Length - 1)].transform.position;
        }
        else if (currentSidePositon == 2)
        {
            this.transform.position = _leftPositions[Random.Range(0, _leftPositions.Length - 1)].transform.position;
        }
        else if (currentSidePositon == 3)
        {
            this.transform.position = _rightPositions[Random.Range(0, _rightPositions.Length - 1)].transform.position;
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
