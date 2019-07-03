using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceTest : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            SliceObject();
    }
    public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }
    public void SliceObject()
    {
        SlicedHull hull = SliceObject(target);
        if (hull != null)
        {
            hull.CreateLowerHull(target, null);
            hull.CreateUpperHull(target, null);

            target.SetActive(false);
        }
    }

}
