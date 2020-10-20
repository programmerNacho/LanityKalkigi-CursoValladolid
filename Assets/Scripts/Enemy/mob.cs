using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnPoints;

    private Vector3 topRigth;
    private Vector3 topLeft;
    private Vector3 downRigth;
    private Vector3 downLeft;

    private void Start()
    {
        topRigth = spawnPoints[0].transform.position;
        topLeft = spawnPoints[1].transform.position;
        downRigth = spawnPoints[2].transform.position;
        downLeft = spawnPoints[3].transform.position;
    }
}
