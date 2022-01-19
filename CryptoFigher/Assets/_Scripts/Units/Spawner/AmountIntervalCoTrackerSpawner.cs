using UnityEngine;

namespace CryptoFighter.n_Unit
{
    public class AmountIntervalCoTrackerSpawner : S_AmountIntervalCoSpawner
    {
        private void OnTriggerEnter2D(Collider2D collision) => Destroy(gameObject);
    }

}

