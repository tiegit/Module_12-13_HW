using UnityEngine;

public class HeadPointer
{
    private const float CheckDistanceOffset = 1.2f;

    private Transform _headTransform;
    private CoinsContainer _coinsContainer;
    private float _rotationSpeed;

    public HeadPointer(Transform headTransform, CoinsContainer coinsContainer, float rotationSpeed)
    {
        _headTransform = headTransform;
        _coinsContainer = coinsContainer;
        _rotationSpeed = rotationSpeed;
    }

    public void CustomUpdate(float deltaTime)
    {
        Coin closestCoin = _coinsContainer.GetClosestCoin(_headTransform.position);

        if (closestCoin != null)
        {
            float distance = Vector3.Distance(_headTransform.position, closestCoin.transform.position);

            if (distance >= CheckDistanceOffset)
            {
                Vector3 toTargetDirection = closestCoin.transform.position - _headTransform.position;
                Vector3 toTargetDirectionXZ = new Vector3(toTargetDirection.x, 0, toTargetDirection.z);

                Quaternion targetRotation = Quaternion.LookRotation(toTargetDirectionXZ);

                _headTransform.rotation = Quaternion.RotateTowards(_headTransform.rotation, targetRotation, _rotationSpeed * deltaTime);
            }
        }
    }
}