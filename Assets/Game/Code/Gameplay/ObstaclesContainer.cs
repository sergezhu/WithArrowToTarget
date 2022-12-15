using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesContainer : MonoBehaviour
{
    [SerializeField] private List<Collider> _colliders;
    [SerializeField] private List<MeshRenderer> _renderers;

    public IEnumerable<Collider> Colliders => _colliders;
    public IEnumerable<MeshRenderer> Renderers => _renderers;

    [ContextMenu("Find Colliders")]
    private void FindColliders()
    {
        _colliders = transform.GetComponentsInChildren<Collider>().ToList();

        #if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty( gameObject );
        #endif
    }

    [ContextMenu( "Find MeshRenderers" )]
    private void FindRenderers()
    {
        _renderers = transform.GetComponentsInChildren<MeshRenderer>().ToList();

        #if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty( gameObject );
        #endif
    }
}
