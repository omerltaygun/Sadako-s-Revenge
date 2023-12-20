using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SadakoJumpscare : MonoBehaviour
{
    public Animator sadakoKillAnim;
    public GameObject player;
    public float jumpscareTime;
    public string sceneName;
    public GameObject sadakoKillCam;
    public AudioSource chaseMusic;
    public AudioSource killMusic;
    public AudioSource ambbianceMusic;
    public Light pointLight;
    public GameObject sadakoEye;
    public SadakoAI sadakoAI;
    public SadakoLvl2AI sadakoAILvl2;
    public GameObject crosshair;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            
            if (sadakoAI != null )
            {
                sadakoAI.enabled = false;
            }
            
            if (sadakoAILvl2 != null)
            {
                sadakoAILvl2.enabled = false;
            }
           
            sadakoKillAnim.SetTrigger("jumpscare");
            pointLight.enabled = true;
            sadakoKillCam.SetActive(true);
            killMusic.Play();
            chaseMusic.enabled = false;
            ambbianceMusic.enabled = false;
            crosshair.SetActive(false);
            StartCoroutine(jumpscare());
        }
    }

    IEnumerator jumpscare()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(3.0f);

        // Enable the sadakoEye image
        sadakoEye.SetActive(true);

        // Wait for the specified jumpscare time
        yield return new WaitForSeconds(jumpscareTime);

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
