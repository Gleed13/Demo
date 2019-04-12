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
}
