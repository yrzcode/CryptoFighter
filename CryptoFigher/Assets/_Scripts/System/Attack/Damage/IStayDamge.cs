using UnityEngine;

public interface IStayDamge
{
    int Damage { get; }

    void OnTriggerStay2D(Collider2D other);

}