using UnityEngine;
using UnityEngine.UI;

public class StickyNoteWorldBugItem : MonoBehaviour, IStickyNoteBugItem
{
    private Text text;

    void Awake()
    {
        text = gameObject.GetComponentInChildren<Text>();    
    }

    public void DestroyMe()
    {
        Destroy(transform.parent.gameObject);
    }

    public void Set(IStickyNote stickyNote)
    {
        text.text = stickyNote.BugText;
    }
}