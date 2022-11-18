using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreButton : MonoBehaviour
{
    [SerializeField] GameObject[] tilePrefabs;

    SpawnerLand spawnerLand;
    Path path;

    void Start()
    {
        spawnerLand = FindObjectOfType<SpawnerLand>();
        path = FindObjectOfType<Path>();
    }

    private void OnMouseDown()
    {
        List<GameObject> list = logic();
        int rand = Random.Range(0, list.Count);
        spawnerLand.CreateLandLeft(list[rand] ,transform.position, transform.parent.position);
        gameObject.SetActive(false);
    }

    private List<GameObject> logic()
    {
        List<GameObject> listGame = new List<GameObject>();
        listGame.AddRange(tilePrefabs);

        for (int i = 0; i < listGame.Count; i++)
        {
            Transform explore = listGame[i].transform.Find("Explore");
            if (explore != null)
            {
                foreach (Transform item in explore)
                {
                    Vector3 pos = new Vector3(transform.position.x + item.transform.position.x, 0, transform.position.z + item.transform.position.z);
                    Vector3 direction = pos - transform.position;
                    print(pos + " " +  (pos + direction));
                    print(path.GetCoordinatesFromPosition(pos) + " " + path.GetCoordinatesFromPosition(pos + direction));
                    if (spawnerLand.PositionList.Contains(path.GetCoordinatesFromPosition(pos)) || spawnerLand.PositionList.Contains(path.GetCoordinatesFromPosition(pos + direction)))
                    {
                        listGame.Remove(listGame[i--]);
                        break;
                    }
                }
            }
        }
        return listGame;
    }
}
