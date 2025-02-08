using UnityEngine;
using UnityEngine.EventSystems;

public class ImageScrollSCRIPT : MonoBehaviour, IScrollHandler
{
    [SerializeField] int rotateScale = 1;
    public void OnScroll(PointerEventData eventData)
    {
        Vector3 rotationVector = new Vector3(0, eventData.scrollDelta.y, 0) * rotateScale;
        transform.Translate(rotationVector, Space.Self);
    }
}
