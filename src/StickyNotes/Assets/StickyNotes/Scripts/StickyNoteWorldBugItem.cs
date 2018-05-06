using UnityEngine;
using UnityEngine.UI;

public class StickyNoteWorldBugItem : MonoBehaviour
{
    private Text text;

    void Awake()
    {
        text = gameObject.GetComponentInChildren<Text>();    
    }

    public void SetBugText(string bugText)
    {
        text.text = bugText;
    }

    public void DestroyMe()
    {
        Destroy(transform.parent.gameObject);
    }
}