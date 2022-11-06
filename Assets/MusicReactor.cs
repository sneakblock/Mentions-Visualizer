using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicReactor : MonoBehaviour
{
    // What band does this reactor listen to?
    [Range(0, 7)] public int syncBand;
    
    [Tooltip("All possible reactor facets for this reactor. This does not mean that they are active.")]
    public ReactorFacet[] ReactorFacets;

    [HideInInspector]
    public List<Material> mats;
    
    // Start is called before the first frame update
    void Start()
    {
        mats = GetComponent<Renderer>().materials.ToList();

        foreach (var reactorFacet in ReactorFacets)
        {
            reactorFacet.Owner = this;
            reactorFacet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var reactorFacet in ReactorFacets)
        {
            if (reactorFacet.IsActive) reactorFacet.Tick();
        }
    }
}
