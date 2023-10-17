using System;
using UnityEngine;

namespace Player
{
    public class PlayerDead : MonoBehaviour
    {
        public Action onPlayerDead;

        [SerializeField] private GameObject[] cruceirosObj;
        [SerializeField] private Transform[] cruceirosTransform;
        [SerializeField] private GameObject lastCruceiro;

        private void Start()
        {
            cruceirosObj = GameObject.FindGameObjectsWithTag("Cruceiro");
            cruceirosTransform = new Transform[cruceirosObj.Length];
            lastCruceiro = null;

            for (int i = 0; i < cruceirosObj.Length; i++)
            {
                cruceirosTransform[i] = cruceirosObj[i].transform;
            }
        }

        public void SetLastCruceiro(GameObject newCruceiro)
        {
            lastCruceiro = newCruceiro;
        }

        public void PlayerDeadFunction()
        {
            if(Events_Level4.instance == null)
            {
                UI_ScreamerCanvas.instance.ShowScreamer();

                if (lastCruceiro != null)
                    this.gameObject.transform.position = lastCruceiro.transform.GetChild(0).position;
                else
                    this.gameObject.transform.position = GetNearestCruceiro(cruceirosTransform).GetChild(0).position;
            }
            else
            {
                Events_Level4.instance.Play_Ending();
            }
        }

        private Transform GetNearestCruceiro(Transform[] cruceiro)
        {
            Transform nCruceiro = null;
            float distance = Mathf.Infinity;
            Vector2 currentPos = transform.position;

            foreach (Transform t in cruceiro)
            {
                float dist = Vector3.Distance(t.position, currentPos);
                if (dist < distance)
                {
                    nCruceiro = t;
                    distance = dist;
                }
            }

            return nCruceiro;
        }
        
        
    }
}
