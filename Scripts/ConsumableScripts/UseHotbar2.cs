using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Use Hotbar 2
/// Uses speed potion
/// </summary>
public class UseHotbar2 : MonoBehaviour
{
    public Text speedCounter;
    public static float spdBoost = 2;

    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2) && HotbarHandling.speedPotions != 0)
        {
            HotbarHandling.speedPotions -= 1;
            speedCounter.text = "x" + HotbarHandling.speedPotions;

            StartCoroutine(StartCountdown());
        }
    }

    // Duration of speed potion
    private float currCountdownValue;

    /// <summary>
    /// StartCountdown
    /// </summary>
    /// <param name="countdownValue"></param>
    /// <returns></returns>
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        float tmpSpd = PlayerMovement.moveSpeed;
        float boostedSpeed = PlayerMovement.moveSpeed + spdBoost;
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            PlayerMovement.moveSpeed = boostedSpeed;
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        PlayerMovement.moveSpeed = tmpSpd;
        currCountdownValue = countdownValue;
    }
}