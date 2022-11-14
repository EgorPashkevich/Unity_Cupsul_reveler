using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public LineRenderer LineRenderer;

    public void Draw(Vector3 a, Vector3 b) {
        LineRenderer.enabled = true;

        LineRenderer.positionCount = 2;
        LineRenderer.SetPosition(0, a);
        LineRenderer.SetPosition(1, b);
    }

    public void Hide() {
        LineRenderer.enabled = false;
    }
}
