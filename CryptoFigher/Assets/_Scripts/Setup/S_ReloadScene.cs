using UnityEngine;
using UnityEngine.SceneManagement;

namespace CryptoFighter.n_Setup
{
    public class S_ReloadScene : MonoBehaviour
    {
        private void Update()
        {
            if (Functions.InputController.GetInputAction().Player.ReLoadSence.IsPressed())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}