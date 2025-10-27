using System.Collections.Generic;
using UnityEngine;

public class CoinsContainer
{
    private List<Coin> _coins = new List<Coin>();

    private List<Coin> _startCoins = new List<Coin>();

    public CoinsContainer(IEnumerable<Coin> coins)
    {
        _coins = new List<Coin>(coins);
        _startCoins = new List<Coin>(coins);
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

    public int GetCoinsCount() => _coins.Count;

    public void ResetCoinsContainer()
    {
        _coins = new List<Coin>(_startCoins);

        foreach (Coin coin in _coins)
            coin.gameObject.SetActive(true);
    }

    public void RemoveCoin(Coin coin)
    {
        if (coin != null)
        {
            coin.gameObject.SetActive(false);

            _coins.Remove(coin);

            int droppedCoinsCount = _startCoins.Count - _coins.Count;

            Debug.Log($"<color=white>Собрано {droppedCoinsCount} монеты из {_startCoins.Count}</color>");
        }
    }
}