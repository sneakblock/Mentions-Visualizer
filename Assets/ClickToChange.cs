using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]
public class ClickToChange : MonoBehaviour
{
    private MusicReactor reactor;

    private void Start()
    {
        reactor = GetComponent<MusicReactor>();
    }

    private void OnMouseDown()
    {
        if (!reactor) return;
        foreach (var facet in reactor.ReactorFacets)
        {
            int enabled = Random.Range(0, 2);
            if (enabled == 1)
            {
                facet.SetActive(true);
            }
            else
            {
                facet.SetActive(false);
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            int randomChannel = Random.Range(0, 8);
            while (randomChannel == reactor.syncBand)
            {
                randomChannel = Random.Range(0, 8);
            }
            reactor.syncBand = randomChannel;
        }
    }
}
