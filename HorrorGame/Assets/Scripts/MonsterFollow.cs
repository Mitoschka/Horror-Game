using UnityEngine;

public class MonsterFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject firstMonster;
    public GameObject secondMonster;

    // Update is called once per frame
    /// <summary>
    /// Given the coordinates of the player, we lower the monsters at a certain distance
    /// </summary>
    void Update()
    {
        Vector3 firstPosition = new Vector3(firstMonster.transform.position.x, player.transform.position.y - 5.8f, firstMonster.transform.position.z);
        firstMonster.transform.position = firstPosition;
        Vector3 secondPosition = new Vector3(secondMonster.transform.position.x, player.transform.position.y + 4.1f, secondMonster.transform.position.z);
        secondMonster.transform.position = secondPosition;
    }
}
