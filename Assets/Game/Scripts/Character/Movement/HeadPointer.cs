using UnityEngine;

public class HeadPointer : MonoBehaviour
{
    private const float CheckDistanceOffset = 1.2f;

    [SerializeField] private CoinsContainer _coinsContainer;
    [SerializeField] private float _rotationSpeed = 100f;

    public void Initialize(CoinsContainer coinsContainer)
    {
        _coinsContainer = coinsContainer;
    }

    private void Update()
    {
        Coin closestCoin = _coinsContainer.GetClosestCoin(transform.position);

        if (closestCoin != null)
        {
            float distance = Vector3.Distance(transform.position, closestCoin.transform.position);

            if (distance >= CheckDistanceOffset)
            {
                Debug.DrawLine(transform.position, closestCoin.transform.position);

                Vector3 toTargetDirection = closestCoin.transform.position - transform.position;
                Vector3 toTargetDirectionXZ = new Vector3(toTargetDirection.x, 0, toTargetDirection.z);

                Quaternion targetRotation = Quaternion.LookRotation(toTargetDirectionXZ);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }
}