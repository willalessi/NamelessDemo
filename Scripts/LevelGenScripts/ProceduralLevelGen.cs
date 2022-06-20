using UnityEngine;

/// <summary>
/// Procedural Level Generation
/// </summary>
public class ProceduralLevelGen : MonoBehaviour
{
    private RoomTemplates templates;
    private int rand;
    private bool spawned;

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        rand = Random.Range(0, 6);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        if (RoomTemplates.floorLvl == 0)
        {
            Invoke("SpawnFirstLevel", 0.1f);
        }
    }

    /// <summary>
    /// Spawned First Level
    /// </summary>
    private void SpawnFirstLevel()
    {
        if (!spawned)
        {
            if (RoomTemplates.platformCnt == RoomTemplates.maxPlatforms - 1)
            {
                Instantiate(templates.endRoom[0], transform.position, Quaternion.identity);
            }
            else if (rand <= 4)
            {
                Instantiate(templates.center[Random.Range(0, templates.center.Length)], transform.position, Quaternion.identity);
            }
            else
            {
                RoomTemplates.upIndex[0] = RoomTemplates.platformCnt;
                Instantiate(templates.down[Random.Range(0, templates.down.Length)], transform.position, Quaternion.identity);
            }
            RoomTemplates.platformCnt++;
            if (RoomTemplates.platformCnt == RoomTemplates.maxPlatforms)
            {
                RoomTemplates.floorLvl++;
                RoomTemplates.platformCnt = 0;
            }
        }
    }

    /// <summary>
    /// Spawned Mid Levels
    /// To be implemented later
    /// Will be used to make 4 directional random levels
    /// </summary>
    private void SpawnMidLevels()
    {
    }

    /// <summary>
    /// Spawned Last Level
    /// To be implemented later
    /// Will be used to make 4 directional random levels
    /// </summary>
    private void SpawnLastLevel()
    {
    }
}