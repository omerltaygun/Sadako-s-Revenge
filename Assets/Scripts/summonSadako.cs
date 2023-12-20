using UnityEngine;

public class summonSadako : MonoBehaviour
{
    public GameObject sadako, block1, block2, exitDoor;
    public Collider collision;
    public bool blocks;
    public AudioSource chaseMusic;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            sadako.SetActive(true);
            chaseMusic.Play();
            if (blocks == true)
            {
                block1.SetActive(true);
                block2.SetActive(true);
            }
            exitDoor.SetActive(true);
            collision.enabled = false;
        }
    }
}
