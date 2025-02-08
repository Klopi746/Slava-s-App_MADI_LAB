using UnityEngine;
using UnityEngine.EventSystems;

public class QuitButtSCRIPT : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}
