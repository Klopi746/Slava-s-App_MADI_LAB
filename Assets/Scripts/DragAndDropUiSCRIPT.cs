using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropUiSCRIPT : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.pointerCurrentRaycast.screenPosition;
    }
}
