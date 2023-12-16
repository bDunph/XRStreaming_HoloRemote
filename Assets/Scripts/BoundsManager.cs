using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsManager : MonoBehaviour
{
    public TextLoader textLoader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AdjustBounds()
    {
        Depthkit.StudioMeshSource meshSource = gameObject.GetComponent<Depthkit.StudioMeshSource>();
        Vector3 volBoundsSize = new Vector3();
        volBoundsSize = meshSource.volumeBounds.size;
        volBoundsSize *= 0.5f;
        Vector3 volBoundCenter = new Vector3();
        volBoundCenter = meshSource.volumeBounds.center;
        Bounds newBounds = new Bounds(volBoundCenter, volBoundsSize);
        meshSource.volumeBounds = newBounds;
    }

    private void OnEnable()
    {
        textLoader.OnTextLoaded += AdjustBounds;
    }

    private void OnDisable()
    {
        textLoader.OnTextLoaded -= AdjustBounds;
    }
}
