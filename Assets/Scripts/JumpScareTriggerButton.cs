using Unity.VisualScripting;
using UnityEngine;

public class JumpScareTriggerButton : MonoBehaviour
{
    public GameObject inttext, light;
    public bool toggle = true, interactable;
    public Renderer lightBulb;
    public Material offlight, onlight;
    public AudioSource lightSwitchSound;
    public Animator switchAnim;
    public GameObject sadakoObject;
    public AudioSource jumpScareSound;
    public GameObject player;

    private bool hasTriggered = false;
    private bool hasJumpScared = false;

    void OnTriggerStay(Collider other)

    {
        if (other.CompareTag("MainCamera"))

        {
            inttext.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)

    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }

    void Update()

    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                //lightSwitchSound.Play();
                switchAnim.ResetTrigger("press");
                switchAnim.SetTrigger("press");
                if (!hasTriggered)
                {
                    sadakoObject.SetActive(true);
                    hasTriggered = true; // Mark as triggered
                    Invoke("DisableSadakoObject", 3f);
                }
            }
        }

        if (toggle == false)
        {
            light.SetActive(false);
            lightBulb.material = offlight;
        }

        if (toggle == true)
        {
            light.SetActive(true);
            lightBulb.material = onlight;
        }

        if (hasTriggered && player != null)
        {
            // Calculate the direction from the player's camera to the sadakoObject
            Vector3 cameraToSadako = sadakoObject.transform.position - player.transform.position;
            float angle = Vector3.Angle(player.transform.forward, cameraToSadako);

            // You can adjust this angle to define the range within which the player is considered to be looking at the object
            if (angle < 30f)
            {
                if (!hasJumpScared)
                {
                    jumpScareSound.PlayOneShot(jumpScareSound.clip);
                    hasJumpScared = true;
                }
            }
        }
    }

    private void DisableSadakoObject()
    {
        sadakoObject.SetActive(false);
    }
}
