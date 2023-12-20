using System.Collections;
using UnityEngine;

public class beginningCutscene : MonoBehaviour
{
    public GameObject cutsceneCam, player, crosshair;
    public float cutsceneTime;

    void Start()
    {
        StartCoroutine(cutscene());
    }

    IEnumerator cutscene()
    {
        yield return new WaitForSeconds(cutsceneTime);
        player.SetActive(true);
        crosshair.SetActive(true);
        cutsceneCam.SetActive(false);
    }
}
