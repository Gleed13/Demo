using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trigger : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var platform = transform.parent.gameObject;
        var c = platform.GetComponent<VisualPlatform>();
        c.ShowCards();
        c.ChangeZoneColor(Color.red);
//        GameController.Instance.TriggerHandler(gameObject);
    }
}
