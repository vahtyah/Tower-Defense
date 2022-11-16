using UnityEngine;
[System.Serializable]
public class Node
{
    public Vector3 position;
    public Node connectedTo;
    public Node(Vector3 position, Node connectedTo)
    {
        this.position = position;
        this.connectedTo = connectedTo;
    }
}
