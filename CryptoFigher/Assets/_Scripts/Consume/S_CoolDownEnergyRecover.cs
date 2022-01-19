
namespace CryptoFighter.n_Consume
{
    public class S_CoolDownEnergyRecover : EnergyRecover
    {

        private void OnEnable()
        {
            _energy.OnDecreseCruurentEnergy += PauseEnergyRecover;
        }

        private void OnDisable()
        {
            _energy.OnDecreseCruurentEnergy -= PauseEnergyRecover;
        }

        private void PauseEnergyRecover()
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(Co_RecoverEnergy());
        }

    }
}


