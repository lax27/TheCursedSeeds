using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject dropedSeedPrefab;
    public List<Wseed> WseedsList = new List<Wseed>();

    // Start is called before the first frame update
    Wseed GetDroppedSeed()
    {
       int randmomNumber = Random.Range(1, 101);
       List<Wseed> possibleseeds = new List<Wseed>();

        foreach(Wseed wseed in WseedsList)
        {
            if (randmomNumber <= wseed.dropChance)
            {
                possibleseeds.Add(wseed);
            }
        }

        if (possibleseeds.Count > 0)
        {
            Wseed dropedSeed = possibleseeds[Random.Range(0, possibleseeds.Count)];
            return dropedSeed;
        }
        Debug.Log("No loot droped");
        return null;
    }

    public void InstatianteWseed(Vector3 spawnPosition)
    {
        Wseed dropedSeed = GetDroppedSeed();
        if (dropedSeed != null)
        {
            GameObject WseedGameObject = Instantiate(dropedSeedPrefab, spawnPosition, Quaternion.identity);
            WseedGameObject.GetComponent<SpriteRenderer>().sprite = dropedSeed.seedSprite;

            float dropForce = 2f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
            WseedGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
