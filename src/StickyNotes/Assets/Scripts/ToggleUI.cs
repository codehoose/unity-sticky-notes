using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ToggleUI : MonoBehaviour
{
    CanvasGroup canvasGroup;

    public string buttonName = "StickyNote";

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update ()
    {
        if (Input.GetButtonDown(buttonName))
        {
            canvasGroup.interactable = !canvasGroup.interactable;
            canvasGroup.alpha = canvasGroup.interactable ? 1f : 0f;
            Time.timeScale = canvasGroup.interactable ? 0f : 1f;
        }	
	}
}
