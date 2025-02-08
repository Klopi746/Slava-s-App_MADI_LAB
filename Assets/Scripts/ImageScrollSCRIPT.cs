using UnityEngine;
using UnityEngine.EventSystems;

public class ImageScrollSCRIPT : MonoBehaviour, IScrollHandler
{
    [SerializeField] int rotateScale = 1;
    [SerializeField] int minAnchoredPosY = -200;
    [SerializeField] int maxAnchoredPosY = 200;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = transform.GetComponent<RectTransform>();
    }
    public void OnScroll(PointerEventData eventData)
    {
        if (eventData.scrollDelta.y < 0)
        {
            if (rectTransform.anchoredPosition.y > maxAnchoredPosY) return;
            Vector3 rotationVector = new Vector3(0, -eventData.scrollDelta.y, 0) * rotateScale;
            transform.Translate(rotationVector, Space.Self);
        }
        else
        {
            if (rectTransform.anchoredPosition.y < minAnchoredPosY) return;
            Vector3 rotationVector = new Vector3(0, -eventData.scrollDelta.y, 0) * rotateScale;
            transform.Translate(rotationVector, Space.Self);
        }
    }
}
