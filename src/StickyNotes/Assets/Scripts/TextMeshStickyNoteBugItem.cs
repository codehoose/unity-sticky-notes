using UnityEngine;

public class TextMeshStickyNoteBugItem : MonoBehaviour, IStickyNoteBugItem
{
    TextMesh textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    public void DestroyMe()
    {
        Destroy(transform.parent.gameObject);
    }

    public void Set(IStickyNote stickyNote)
    {
        textMesh.text = stickyNote.BugText;
    }
}
