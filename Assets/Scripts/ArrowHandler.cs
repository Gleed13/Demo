using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowHandler : MonoBehaviour
{
    private Vector3 _start;

    public static ArrowHandler Instance { get; private set; }
    
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

    private static Vector3 GetWorldVector3(PointerEventData eventData)
    {
        var vec3 = new Vector3(eventData.position.x, eventData.position.y, 10f);
        System.Diagnostics.Debug.Assert(Camera.main != null, "Camera.main != null");
        return Camera.main.ScreenToWorldPoint(vec3);
    }
    
    public void OnBeginDrag(Vector3 vec3)
    {
        Debug.Log("start");
        _start = vec3;
        container.SetActive(true);
        bot.transform.position = vec3;
        body.transform.position = vec3;
        tip.transform.position = vec3;
    }

    public void OnDrag(Vector3 vec3)
    {
        Debug.Log("yeah boi");
        
        tip.transform.position = vec3;
        
        
        var distance = Vector3.Distance(_start, vec3);
        
        var s = body.transform.localScale;
        s.y = distance*2 - 0.5f;
        body.transform.localScale = s;
        
        
        var angle = Mathf.Atan2(vec3.y - _start.y, vec3.x - _start.x) * Mathf.Rad2Deg - 90f;
        
        var eb = body.transform.eulerAngles;
        eb.z = angle;
        body.transform.eulerAngles = eb;
        
        var et = tip.transform.eulerAngles;
        et.z = angle;
        tip.transform.eulerAngles = et;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end");
        container.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var vec3 = GetWorldVector3(eventData);
        Debug.Log(vec3.x + " " + vec3.y + " " + vec3.z);
        SetBot(vec3);
    }

    public void SetBot(Vector3 vector3)
    {
        
    }
}
