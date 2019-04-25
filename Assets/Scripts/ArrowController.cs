using Enum;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public static ArrowController Instance { get; private set; }
    
    //Points
    public GameObject startPoint;
    public GameObject endPoint;
    
    //Types
    public PointAbleOption startPointType;
    public PointAbleOption endPointType;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void StartPoint(GameObject eventObject, PointAbleOption type)
    {
        //remember on which platform the drag begins
        startPoint = eventObject;
        startPointType = type;
    }
    
    public void EndPoint()
    {
        if (startPoint && endPoint && startPointType == endPointType)
        {
            Debug.Log("start = " + startPoint.name);
            Debug.Log("end = " + endPoint.name);
        }
        
        startPoint = null;
        endPoint = null;

        startPointType = PointAbleOption.Null;
        endPointType = PointAbleOption.Null;
    }

    public void OnPointerEnterHandler(GameObject eventObject, PointAbleOption type)
    {
        if (startPoint == eventObject) return;
        
        
        endPoint = eventObject;
        endPointType = type;
            
        if (startPointType == endPointType)
        {
            Debug.Log(eventObject.name + " entered");
//            endPoint.GetComponent<VisualPlatform>().ChangeZoneColor(Color.red);
        }
    }
    
    public void OnPointerExitHandler(GameObject eventObject)
    {
        if (startPoint == eventObject) return;
        
        
        if (startPointType == endPointType)
        {
            Debug.Log(eventObject.name + " exited");
//            endPoint.GetComponent<VisualPlatform>().ChangeZoneColor(Color.green);
        }
            
        endPoint = null;
        endPointType = PointAbleOption.Null;
    }

    public void OnDropHandler(GameObject eventObject, PointAbleOption type)
    {
        if (startPoint == eventObject) return;
        
        endPoint = eventObject;
        endPointType = type;
    }
}
