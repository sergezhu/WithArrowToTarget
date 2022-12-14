using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesContainer : MonoBehaviour
{
    [SerializeField] private List<Collider> _colliders;

    public IEnumerable<Collider> Colliders => _colliders;

    [ContextMenu("Find Colliders")]
    private void FindColliders()
    {
        _colliders = transform.GetComponentsInChildren<Collider>().ToList();

        #if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty( gameObject );
        #endif
    }
}
