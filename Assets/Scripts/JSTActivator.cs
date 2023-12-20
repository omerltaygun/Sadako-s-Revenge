using UnityEngine;

public class JSTActivator : MonoBehaviour
{
    public GameObject JumpScareTrigger;

    private void OnTriggerEnter(Collider other)
    {
        JumpScareTrigger.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}
