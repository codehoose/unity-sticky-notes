using UnityEngine;

public class StickyNoteMobile : MonoBehaviour
{
    [HideInInspector]
    public StickyNoteController controller;

    void OnTriggerEnter(Collider other)
    {
        var bugItem = other.GetComponent<StickyNoteWorldBugItem>();
        if (bugItem == null)
            return;

        controller.BugTrigger_Entered(bugItem);
    }

    void OnTriggerExit(Collider other)
    {
        var bugItem = other.GetComponent<StickyNoteWorldBugItem>();
        if (bugItem == null)
            return;

        controller.BugTrigger_Leave();
    }
}
