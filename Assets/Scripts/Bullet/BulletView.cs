using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    bool hasTankSpawned = false;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (hasTankSpawned)
        {

        }
    }

    public void SetBullet(Material color)
    {
        hasTankSpawned = true;
        meshRenderer.material = color;
    }
}
