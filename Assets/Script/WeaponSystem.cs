using UnityEngine;

namespace Script
{
    public class WeaponSystem : MonoBehaviour
    {
        public float damage = 10f;
        public float chopPower = 1f; 
        public LayerMask hitLayers;
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                _animator.SetTrigger("Hit");
            }
        }

        public virtual void Attack()
        {
            var selectedObject = SelectionManager.Instance.selectedObject;
            if (selectedObject != null)
            {
                if (selectedObject.layer == LayerMask.NameToLayer("Tree"))
                {
                    selectedObject.GetComponent<Tree>().Chop(chopPower);
                }
            }
        }


    }
}