
using UnityEngine;
using CryptoFighter.n_Status;

namespace CryptoFighter.n_Unit._Enemy
{
    public class EnemyTracker : Enemy
    {
        
        [SerializeField] MoveSpeed _moveSpeed;
        [SerializeField] GameObject _image;
        [SerializeField] private Transform _target;
        private Vector3 _direction;

        protected override void Awake()
        {
            base.Awake();
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            // HandleEnemyMovement();
            HandleFlipping();
        }

        private void HandleFlipping()
        {
            var localScale = _image.transform.localScale;
            var localScaleX = Mathf.Sign(_direction.x);
            localScale = new Vector3(localScaleX, localScale.y, localScale.z);
            
            _image.transform.localScale = localScale;
        }

        private void HandleEnemyMovement()
        {
            _direction = _target.position - transform.position;
            transform.Translate(Vector3.ClampMagnitude(_direction, 1f) * _moveSpeed.CurrentMoveSpeed * Time.deltaTime);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                PlayTrackerDestroyEffect(config.WallDestroyEffect);
            }

            PlayTrackerDestroyEffect(config.GetDestroyEffcet());

            Destroy(gameObject);

        }

        private void PlayTrackerDestroyEffect(GameObject prefab)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}


