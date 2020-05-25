using System.Collections.Generic;
using UnityEngine;

public class FloorDownCreate : MonoBehaviour
{
    public Transform player;
    public Floor[] floors;
    public Floor floor;
    private Vector3 vectorFlo = new Vector3(0, 3, 0);
    private Vector3 vector = new Vector3(0, 158.8f, 0);
    private bool isFirst = true;
    public GameObject delete;
    public GameObject FirstMonster;
    public GameObject SecondMonster;
    private int number;
    private Vector3 position = new Vector3(0, 0, -3.5f);
    private bool isTransform = false;
    private int randomNumber = 0;

    private List<Floor> spawnedFloors = new List<Floor>();

    // Start is called before the first frame update
    /// <summary>
    /// Add the first floor to the list, and also generate a random value of the spawn of monsters
    /// </summary>
    void Start()
    {
        transform.position += vectorFlo;
        spawnedFloors.Add(floor);
        randomNumber = Random.Range(2, 5);
    }

    // Update is called once per frame
    /// <summary>
    /// Create and add a floor to the list, check the number of floors and if the limit is exceeded, then delete the top
    /// </summary>
    void Update()
    {
        if (player.position.y < spawnedFloors[spawnedFloors.Count - 1].end.position.y + 10)
        {
            SpawnFloor();
        }

        if (spawnedFloors.Count >= 20)
        {
            Destroy(spawnedFloors[0].gameObject);
            spawnedFloors.RemoveAt(0);
            Destroy(delete);
        }

        if (!isTransform)
        {
            number = gameObject.GetComponent<FloorDownCreate>().Count();
            if (number > randomNumber)
            {
                FirstMonster.transform.position += position;
                SecondMonster.transform.position += position;
                isTransform = true;
                MonsterFollow other = GameObject.Find("firstMonster").GetComponent<MonsterFollow>();
                other.enabled = false;
            }
        }
    }

    /// <summary>
    /// We create a floor in a certain position, according to the size of our floor
    /// </summary>
    void SpawnFloor()
    {
        if (isFirst)
        {
            vector = new Vector3(0, 158.2f, 0);
            isFirst = false;
        }
        else
        {
            vector = new Vector3(0, 158.8f, 0);
        }
        Floor newFloor = Instantiate(floors[0]);
        newFloor.transform.position = spawnedFloors[spawnedFloors.Count - 1].end.position - newFloor.start.localPosition + vector;
        spawnedFloors.Add(newFloor);
    }

    /// <summary>
    /// Get the number of floors
    /// </summary>
    /// <returns> Number of floors </returns>
    public int Count() => spawnedFloors.Count;
}