using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLand : MonoBehaviour
{
    [SerializeField] GameObject landPrefabs;

    Path path;
    Vector3 lastPosition;
    Vector3[] direction = { Vector3.forward, Vector3.right, Vector3.back, Vector3.left };
    private void Start()
    {
        lastPosition = transform.position;
        path = GetComponentInChildren<Path>();
    }

    public void CreateLandLeft()
    {
        lastPosition += direction[3];
        GameObject land = Instantiate(landPrefabs,lastPosition,Quaternion.identity,transform);
        Transform pathParent = land.transform.Find("Path");
        if(pathParent != null)
        {
            foreach (Transform child in pathParent)
            {
                path.pathList.Add(child);
            }
        }
    }
}
