using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue = 1;

    public int CoinValue => _coinValue;
}