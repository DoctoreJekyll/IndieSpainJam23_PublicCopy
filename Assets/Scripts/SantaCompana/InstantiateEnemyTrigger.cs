using UnityEngine;

namespace SantaCompana
{
    public class InstantiateEnemyTrigger : MonoBehaviour
    {
        
        [SerializeField] private GameObject[] prefabToInstantiate;

        public void InstantiateEnemy()
        {
            for (int i = 0; i < prefabToInstantiate.Length; i++)
            {
                prefabToInstantiate[i].SetActive(true);
            }
            
        }
        
    }
}
