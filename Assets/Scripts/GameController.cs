using System.Collections.Generic;
using Enum;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Side _turn;
    public static GameController Instance { get; private set; }

    public List<Player> players;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        _turn = Side.Red;
    }

    public void TriggerHandler(GameObject triggeredCard)
    {
        switch (_turn)
        {
            case Side.Red:
                
                break;
        }
    }

    public void SendArrowAction(GameObject first, GameObject second, PointAbleOption pointType)
    {
        if (pointType == PointAbleOption.Card && !second.CompareTag(first.tag))
        {
            var c1 = first.GetComponent<CardModel>().GetCard;
            var c2 = second.GetComponent<CardModel>().GetCard;
            Debug.Log("Can attack: " + CardLogic.CanAttack(c1, c2));
        }
    }
}
