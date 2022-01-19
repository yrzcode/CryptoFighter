using UnityEngine;

namespace CryptoFighter.n_Scale
{
    public class S_RandomHorizontalFlip : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        
        enum Direction {Left = -1,Right = 1}
        private Direction _direction;

        private void Start()
        {
            _direction = Functions.GetRandomEnumValue<Direction>();
            
            switch (_direction)
            {
                case Direction.Left:
                    Functions.FlipGameObject(_gameObject);
                    break;
                case Direction.Right:
                    break;
            }
        }
    }
}