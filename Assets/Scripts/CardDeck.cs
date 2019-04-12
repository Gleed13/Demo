using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    private int[] _indexes;
    public int numberOfCards;

    private void Awake()
    {
        InitDeck();
    }

    private void InitDeck() //shuffles random non-repeating indexes of cards in _indexes
    {
        int[] intArr = new int[numberOfCards];
        //fill intArr from 0 to intArr.Length
        for (var i = 0; i < intArr.Length; i++)
        {
            intArr[i] = i;
        }
        List<int> intList = intArr.ToList(); //create list of that array
        intArr = new int[intList.Count]; //create new array
        System.Random random = new System.Random();
        var j = 0;
        for (var i = intList.Count; i > 0; i--)
        {
            var rng = random.Next(i);
            intArr[j] = intList[rng];
            intList.RemoveAt(rng);
            j++;
        }

        _indexes = intArr;
    }

    private void DebugArray()
    {
        for (var i = 0; i < _indexes.Length; i++)
        {
            Debug.Log("_indexes[" + i + "] = " + _indexes[i]);
        }
    }

    public int[] GetIndexArray()
    {
        return _indexes;
    }
}
