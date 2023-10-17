using System;
using UnityEngine;

namespace SantaCompana
{
    public class AnimaPosition : MonoBehaviour
    {

        [SerializeField] private Transform initialDestiny;

        private void OnEnable()
        {
            this.gameObject.transform.position = initialDestiny.position;
        }
    }
}
