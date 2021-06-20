using UnityEngine;

interface IKnockbackable
{
    void StartKnocback(Vector2 direction);
    void EndKnocback();
    float GetKnockbackTime();
}
