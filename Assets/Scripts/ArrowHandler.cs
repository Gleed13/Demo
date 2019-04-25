using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowHandler : MonoBehaviour
{
    private Vector3 _start;
    
    public static ArrowHandler Instance { get; private set; }

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
    
    public void OnBeginDragHandler(Vector3 vec3)
    {
        //remember start position
        _start = vec3;
        
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
//        var distance = Vector3.Distance(_start, vec3);
        var tmp = Mathf.Pow(_start.x - vec3.x, 2) + Mathf.Pow(_start.y - vec3.y, 2);
        var distance = Mathf.Sqrt(tmp);
        
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
        //hide arrow
        container.SetActive(false);
    }
}
