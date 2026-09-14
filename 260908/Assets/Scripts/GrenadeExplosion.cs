using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public void Explode(Vector3 explosionPoint, float radius, int damage)
    {
        // 폭발 지점 주변의 모든 콜라이더 수집
        Collider[] hitColliders = Physics.OverlapSphere(explosionPoint, radius);

        foreach (var hit in hitColliders)
        {
            if (hit.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}
