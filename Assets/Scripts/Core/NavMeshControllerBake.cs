using System;
using NavMeshPlus.Components;
using UnityEngine;

namespace Core
{
    public class NavMeshControllerBake : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface navMeshSurface;
        

        public void BuildNaveMesh()
        {
            //navMeshSurface.BuildNavMesh();
            Debug.Log("Build Nave Mesh only debug");
        }
    }
}
