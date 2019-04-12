using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
//        Debug.Log(eventData.pointerDrag.name);
        Debug.Log(gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        
    }
}
