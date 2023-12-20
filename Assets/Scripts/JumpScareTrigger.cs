using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioSource doorCloseSound;
    public GameObject sadakoObject;
    public AudioSource jumpScareSound;
    public GameObject player;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            doorAnimator.SetTrigger("close");
            doorCloseSound.Play();
            sadakoObject.SetActive(true);
            hasTriggered = true;
            Invoke("DisableSadakoObject", 3f);
        }
    }

    private void Update()
    {
        if (hasTriggered && player != null)
        {
            // Calculate the direction from the player's camera to the sadakoObject
            Vector3 cameraToSadako = sadakoObject.transform.position - player.transform.position;
            float angle = Vector3.Angle(player.transform.forward, cameraToSadako);

            // You can adjust this angle to define the range within which the player is considered to be looking at the object
            if (angle < 30f)
            {
                jumpScareSound.PlayOneShot(jumpScareSound.clip);
                hasTriggered=false;
            }
        }
    }

    private void DisableSadakoObject()
    {
        sadakoObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
