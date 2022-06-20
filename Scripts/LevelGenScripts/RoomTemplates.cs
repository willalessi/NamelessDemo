using UnityEngine;

/// <summary>
/// Room Templates
/// Some code may not be used
/// Level gen is a large WIP
/// </summary>
public class RoomTemplates : MonoBehaviour
{
    public GameObject[] center;
    public GameObject[] down;
    public GameObject[] up;
    public GameObject[] endRoom;

    public static int platformCnt = 0;
    public static int maxPlatforms;

    public static int floorLvl = 0;

    public static int[] upIndex;
    public static int[] downIndex;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        maxPlatforms = Random.Range(15, 18);
        upIndex = new int[maxPlatforms];
        downIndex = new int[maxPlatforms];
    }
}