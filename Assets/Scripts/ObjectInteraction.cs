using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    public bool interactable, toggle;
    public GameObject inttext, dialogue;
    public string dialogueString;
    public TMP_Text dialogueText;
    public float dialogueTime;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (toggle == false)
            {
                inttext.SetActive(true);
                interactable = true;
            }
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
                dialogueText.text = dialogueString;
                dialogue.SetActive(true);
                inttext.SetActive(false);
                StartCoroutine(disableDialogue());
                toggle = true;
                interactable = false;
            }
        }
    }

    IEnumerator disableDialogue()

    {
        yield return new WaitForSeconds(dialogueTime);
        dialogue.SetActive(false);
    }
}
