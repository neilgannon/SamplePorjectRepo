using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    public PathNode NextNode;

    private void OnDrawGizmos()
    {
        if (NextNode)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, NextNode.transform.position);
        }
    }
}
