using System.Collections.Generic;
using UnityEngine;

public class CoinsContainer
{
    [SerializeField] private List<Coin> _coins = new List<Coin>();

    public CoinsContainer(IEnumerable<Coin> coins)
    {
        _coins = new List<Coin>(coins);
    }

    public Coin GetClosestCoin(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Coin closestCoin = null;

        for (int i = 0; i < _coins.Count; i++)
        {
            if (_coins[i] == null)
                continue;

            float distance = Vector3.Distance(point, _coins[i].transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestCoin = _coins[i];
            }
        }

        return closestCoin;
    }

    public void RemoveCoin(Coin coin)
    {
        if (coin != null)
        {
            _coins.Remove(coin);
        }
    }
}