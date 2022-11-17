using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreButton : MonoBehaviour
{
    [SerializeField] GameObject[] tilePrefabs;

    SpawnerLand spawnerLand;

    void Start()
    {
        spawnerLand = FindObjectOfType<SpawnerLand>();
    }

    private void OnMouseDown()
    {
        int rand = Random.Range(0, tilePrefabs.Length);
        print(rand + " " + tilePrefabs[rand]);
        spawnerLand.CreateLandLeft(tilePrefabs[rand] ,transform.position, transform.parent.position);
        gameObject.SetActive(false);
    }
}
