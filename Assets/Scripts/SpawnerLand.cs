using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerLand : MonoBehaviour
{
    Path path;
    Vector3[] direction = { Vector3.forward, Vector3.right, Vector3.back, Vector3.left };
    [SerializeField] List<Vector2Int> positionList = new List<Vector2Int>();
    public List<Vector2Int> PositionList { get => positionList; set { } }
    private void Start()
    {
        path = GetComponentInChildren<Path>();
        positionList.Add(path.GetCoordinatesFromPosition(transform.position));
        Node node = new Node(transform.position, null);
        path.pathDic.Add(transform.position, node);
    }

    public void CreateLandLeft(GameObject landPrefabs, Vector3 position, Vector3 positionParent)
    {
        Vector2Int coordinatesPos = path.GetCoordinatesFromPosition(position);
        if (!positionList.Contains(coordinatesPos))
            positionList.Add(coordinatesPos);
        GameObject land = Instantiate(landPrefabs, position, landPrefabs.transform.rotation, transform);
        Transform explore = land.transform.Find("Explore");
        foreach (Transform posExplore in explore)
        {
            Vector2Int coordinates = path.GetCoordinatesFromPosition(posExplore.position);
            if (!positionList.Contains(coordinates)) positionList.Add(coordinates);
        }
        //Transform Path = land.transform.Find("Path");
        //List<Transform> newList = new List<Transform>();
        //if (Path != null)
        //{
        //    foreach (Transform child in Path)
        //        newList.Add(child);
        //    foreach (Transform child2 in newList)
        //    {
        //        Node nodeParen = path.GetNode(positionParent);
        //        if (nodeParen != null)
        //        {
        //            Node node = new Node(child2.position, nodeParen);
        //            path.pathDic.Add(node.position, node);
        //        }
        //    }
        //}
    }
}
