using UnityEngine;
using UnityEngine.EventSystems;

public class PointAble : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    
    
    private static Vector3 GetWorldVector3(PointerEventData eventData)
    {
        var vec3 = new Vector3(eventData.position.x, eventData.position.y, 10f);
        System.Diagnostics.Debug.Assert(Camera.main != null, "Camera.main != null");
        return Camera.main.ScreenToWorldPoint(vec3);
    }

    #region Drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        //        Debug.Log("start");
        var vec3 = transform.position;
        ArrowHandler.Instance.OnBeginDragHandler(vec3, gameObject);
    }
                
    public void OnDrag(PointerEventData eventData)
    {
        //        Debug.Log("dragging");
        var vec3 = GetWorldVector3(eventData);
        ArrowHandler.Instance.OnDragHandler(vec3);
    }
                
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("ended");
        ArrowHandler.Instance.OnEndDragHandler(eventData);
    }
    #endregion
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        ArrowHandler.Instance.OnPointerEnterHandler(eventData, gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ArrowHandler.Instance.OnPointerExitHandler(eventData, gameObject);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.dragging && ArrowHandler.Instance.startPoint != gameObject)
        {
            Debug.Log(gameObject.name + " dropped");
            ArrowHandler.Instance.endPoint = gameObject;
        }
    }
}
