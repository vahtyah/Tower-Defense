using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerLand : MonoBehaviour
{
    [SerializeField] GameObject landPrefabs;

    Path path;
    Vector3[] direction = { Vector3.forward, Vector3.right, Vector3.back, Vector3.left };
    List<Vector3> positionList = new List<Vector3>();
    private void Start()
    {
        positionList.Add(transform.position);
        path = GetComponentInChildren<Path>();
        Node node = new Node(transform.position, null);
        path.pathDic.Add(transform.position, node);
    }

    public void CreateLandLeft(Vector3 position, Vector3 positionParent)
    {
        positionList.Add(position);
        GameObject land = Instantiate(landPrefabs, position, Quaternion.identity, transform);
        Transform Path = land.transform.Find("Path");
        List<Transform> newList = new List<Transform>();
        if (Path != null)
        {
            foreach (Transform child in Path)
                newList.Add(child);
            foreach (Transform child2 in newList)
            {
                Node nodeParen = path.GetNode(positionParent);
                if (nodeParen != null)
                {
                    Node node = new Node(child2.position, nodeParen);
                    path.pathDic.Add(node.position, node);
                }
            }
        }
    }
}
