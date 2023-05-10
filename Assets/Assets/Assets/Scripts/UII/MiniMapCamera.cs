using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    Camera camera;
    public int numOfRooms;
    public float minimapZoom;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {

        foreach(Vector2 roomPos in DungeonManager.instance.currentRoomsPositions)
        {
            if (roomPos.x > DungeonManager.roomMaxPositiveDistance.x)
                DungeonManager.roomMaxPositiveDistance.x = roomPos.x;
            else if (roomPos.x < DungeonManager.roomMaxNegativeDistance.x)
                DungeonManager.roomMaxNegativeDistance.x = roomPos.x;

            if (roomPos.y > DungeonManager.roomMaxPositiveDistance.y)
                DungeonManager.roomMaxPositiveDistance.y = roomPos.y;
            else if (roomPos.y < DungeonManager.roomMaxNegativeDistance.y)
                DungeonManager.roomMaxNegativeDistance.y = roomPos.y;

        }

        float horizontalRooms = (DungeonManager.roomMaxPositiveDistance.x  -DungeonManager.roomMaxNegativeDistance.x)/22f;
        float verticalRooms = (DungeonManager.roomMaxPositiveDistance.y + Mathf.Abs(DungeonManager.roomMaxNegativeDistance.y))/12.48f;

        Vector2 esquinaSuperiorIzquierda = new Vector2(DungeonManager.roomMaxNegativeDistance.x - 11f, DungeonManager.roomMaxPositiveDistance.y + 12.48f * 0.5f);
        Vector2 esquinaInferiorDerecha = new Vector2(DungeonManager.roomMaxPositiveDistance.x + 11f, DungeonManager.roomMaxNegativeDistance.y- 12.48f*0.5f);

        transform.position = (Vector3)(esquinaSuperiorIzquierda * 0.5f + esquinaInferiorDerecha * 0.5f) + Vector3.forward* transform.position.z;

        camera.orthographicSize = Camera.main.orthographicSize * Mathf.Max(verticalRooms, horizontalRooms) + Camera.main.orthographicSize + minimapZoom;
    }
}
