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
        lastPosition += direction[1];
        GameObject land = Instantiate(landPrefabs, lastPosition, Quaternion.identity, transform);
        Transform Path = land.transform.Find("Path");
        List<Transform> newList = new List<Transform>();
        if (Path != null)
        {
            foreach(Transform child in Path)
                newList.Add(child);
            newList.Reverse();

        }
    }
}
