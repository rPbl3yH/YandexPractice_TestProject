using UnityEngine;

namespace Game.Money
{
    public class MoneyComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _distance;
        private Transform _target;

        public void Construct(Transform target)
        {
            _target = target;
        }
        
        private void Update()
        {
            if (Vector3.Distance(transform.position, _target.position) <= _distance)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            }
        }
    }
}