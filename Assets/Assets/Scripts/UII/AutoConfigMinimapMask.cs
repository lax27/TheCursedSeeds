using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AutoConfigMinimapMask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ConfigurarRenderers();
    }

    public static void ConfigurarRenderers()
    {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }

        TilemapRenderer[] tilemaps = FindObjectsOfType<TilemapRenderer>();

        for (int i = 0; i < tilemaps.Length; i++)
        {
            tilemaps[i].maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        }
    }

  
}
