using UnityEngine;

public delegate void DamageableDieEvent();

public class Damageable : MonoBehaviour {
    public float Health {get; private set;}

    public event DamageableDieEvent OnDie;

    public void Damage(float value)
    {
        Health -= value;
        if (Health <= 0)
            OnDie.Invoke(); 
    }
}