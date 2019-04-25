using Enum;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointAble : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public PointAbleOption type;
    
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
        ArrowHandler.Instance.OnBeginDragHandler(vec3);
        
        
        ArrowController.Instance.StartPoint(gameObject, type);
    }
                
    public void OnDrag(PointerEventData eventData)
    {
        //        Debug.Log("dragging");
        var vec3 = GetWorldVector3(eventData);
        ArrowHandler.Instance.OnDragHandler(vec3);
    }
                
    public void OnEndDrag(PointerEventData eventData)
    {
//        Debug.Log("ended");
        ArrowHandler.Instance.OnEndDragHandler(eventData);
        
        
        ArrowController.Instance.EndPoint();
    }
    #endregion
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.dragging)
            ArrowController.Instance.OnPointerEnterHandler(gameObject, type);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.dragging)
            ArrowController.Instance.OnPointerExitHandler(gameObject);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.dragging)
        {
            ArrowController.Instance.OnDropHandler(gameObject, type);
        }
    }
}
