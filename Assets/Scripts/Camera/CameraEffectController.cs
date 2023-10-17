using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace Camera
{
    public class CameraEffectController : MonoBehaviour
    {

        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        private CinemachineBasicMultiChannelPerlin effect;

        private bool enemyIsInRange;

        private float initValue = 3.25f;
        private float zoomValue = 3f;

        private void Start()
        {
            effect = virtualCamera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
        }

        private void Update()
        {
            if(enemyIsInRange && zoomValue < virtualCamera.m_Lens.OrthographicSize)
            {
                virtualCamera.m_Lens.OrthographicSize -= Time.deltaTime / 1.5f;
            }
            else if (!enemyIsInRange && virtualCamera.m_Lens.OrthographicSize < initValue)
            {
                virtualCamera.m_Lens.OrthographicSize += Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                enemyIsInRange = true;
                StopAllCoroutines();
                StartCoroutine(StartEffectCorroutine(1f, 0f, 1f));
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                enemyIsInRange = false;
                StopAllCoroutines();
                StartCoroutine(StartEffectCorroutine(1f, 1f, 0f));
            }
        }


        IEnumerator StartEffectCorroutine(float duration, float start, float targetValue)
        {
            float currentTime = 0;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                effect.m_AmplitudeGain = Mathf.Lerp(start, targetValue, currentTime / duration);
                effect.m_FrequencyGain = Mathf.Lerp(start, targetValue, currentTime / duration);
                yield return null;
            }
            yield break;
        }
    }
}
