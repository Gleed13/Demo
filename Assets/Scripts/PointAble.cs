using UnityEngine;
using UnityEngine.EventSystems;

public class PointAble : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    
    private static Vector3 GetWorldVector3(PointerEventData eventData)
    {
        var vec3 = new Vector3(eventData.position.x, eventData.position.y, 10f);
        System.Diagnostics.Debug.Assert(Camera.main != null, "Camera.main != null");
        return Camera.main.ScreenToWorldPoint(vec3);
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start");
        var vec3 = transform.position;
        ArrowHandler.Instance.OnBeginDrag(vec3);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        ArrowHandler.Instance.OnEndDrag(eventData);
    }
}
