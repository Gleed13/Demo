using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowHandler : MonoBehaviour
{
    private Vector3 _start;
    
    public static ArrowHandler Instance { get; private set; }

    //Points
    public GameObject startPoint;
    public GameObject endPoint;

    //Arrow
    public GameObject container;
    
    public GameObject bot;
    public GameObject body;
    public GameObject tip;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    
    #region DragHandler
    public void OnBeginDragHandler(Vector3 vec3, GameObject eventObject)
    {
        //remember start position
        _start = vec3;
        //remember on which platform the drag begins
        startPoint = eventObject;
        
        //show arrow and set it's starting position
        container.SetActive(true);
        bot.transform.position = vec3;
        body.transform.position = vec3;
        tip.transform.position = vec3;
    }

    public void OnDragHandler(Vector3 vec3)
    {
//        Debug.Log("yeah boi");
        
        //set position of tip of arrow
        tip.transform.position = vec3;
        
        
        //set height of body of arrow
        var distance = Vector3.Distance(_start, vec3);
        
        var scale = body.transform.localScale;
        scale.y = distance*2 - 0.5f;
        body.transform.localScale = scale;
        
        
        //set angles of body and tip
        var angle = Mathf.Atan2(vec3.y - _start.y, vec3.x - _start.x) * Mathf.Rad2Deg - 90f;
        
        var eb = body.transform.eulerAngles;
        eb.z = angle;
        body.transform.eulerAngles = eb;
        
        var et = tip.transform.eulerAngles;
        et.z = angle;
        tip.transform.eulerAngles = et;
    }

    public void OnEndDragHandler(PointerEventData eventData)
    {
        if (startPoint != null)
            Debug.Log("start = " + startPoint.name);
        if (endPoint != null)
            Debug.Log("end = " + endPoint.name);
        
        startPoint = null;
        endPoint = null;
        
        
        //hide arrow
        container.SetActive(false);
    }
    #endregion

    public void OnPointerEnterHandler(PointerEventData eventData, GameObject eventObject)
    {
        if (eventData.dragging && startPoint != eventObject)
        {
            Debug.Log(eventObject.name);
            endPoint = eventObject;
            endPoint.GetComponent<VisualPlatform>().ChangeZoneColor(Color.red);
        }
    }
    
    public void OnPointerExitHandler(PointerEventData eventData, GameObject eventObject)
    {
        if (eventData.dragging && startPoint != eventObject)
        {
            Debug.Log(eventObject.name + " exited");
            endPoint.GetComponent<VisualPlatform>().ChangeZoneColor(Color.green);
            endPoint = null;
        }
    }
}
