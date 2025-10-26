public class ScoreCounter
{
    private int _score;

    public int Score => _score;

    public void AddCoin(Coin coin)
    {
        if (coin != null)
        {
            _score += coin.CoinValue;
        }
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
