using System.Collections;
using UnityEngine;

public class leverScript : MonoBehaviour
{
    public Animator switchAnim;
    public GameObject ironbarGate, intText;
    public bool interactable, toggle;
    public AudioSource ironBarSound;


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (toggle == false)
            {
                intText.SetActive(true);
                interactable = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switchAnim.SetTrigger("pull");
                StartCoroutine(MoveIronBarGate());
                ironBarSound.Play();
                intText.SetActive(false);
                toggle = true;
                interactable = false;
            }
        }
    }

    IEnumerator MoveIronBarGate()
    {
        float duration = 2.0f; // Adjust the duration as needed
        float targetY = -10.3f;
        float initialY = ironbarGate.transform.position.y;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float newY = Mathf.Lerp(initialY, targetY, elapsedTime / duration);
            ironbarGate.transform.position = new Vector3(ironbarGate.transform.position.x, newY, ironbarGate.transform.position.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is precisely set
        ironbarGate.transform.position = new Vector3(ironbarGate.transform.position.x, targetY, ironbarGate.transform.position.z);
    }
}
