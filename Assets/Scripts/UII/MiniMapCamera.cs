using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    Camera camera;
    public int numOfRooms;
    public float minimapZoom;

    public const float ROOM_X_SIZE = 22f;
    public const float ROOM_Y_SIZE = 12.48f;

    public const float ROOM_X_HALFSIZE = ROOM_X_SIZE * 0.5f;
    public const float ROOM_Y_HALFSIZE = ROOM_Y_SIZE * 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {

        /*
        Este codigo se hizo antes del refactor para que el codigo fuera legible,
        como no entendiamos bien el codigo de los compañeros lo que se hizo fue
        "deducir" con cálculos datos que probablemente esten en otro sitio.

        Como queda poco tiempo para la entrega final se queda así pero el código está comentado.
         
         */

        // en este for lo que se hace es ver si es el mapa es mas grande en horizontal o en vertical
        // y se guarda los extremos negativo y positivo de el mapa en los vectores roomMaxPositiveDistance y roomMaxNegativeDistance

        foreach (Vector2 roomPos in DungeonManager.instance.CurrentRooms)
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

        // A partir de las dimensiones del mapa calcula la longitud del mapa pero en lugar de metros en "cantidad de salas" horizontalmente y verticalmente

        float horizontalRooms = (DungeonManager.roomMaxPositiveDistance.x  -DungeonManager.roomMaxNegativeDistance.x)/ROOM_X_SIZE;
        float verticalRooms = (DungeonManager.roomMaxPositiveDistance.y + Mathf.Abs(DungeonManager.roomMaxNegativeDistance.y))/ ROOM_Y_SIZE;

        // a partir de la cantidad de salas calculada se hace la siguiente regla de 3:
        // si el zoom del main camera es el necesario para que se vea 1 sala
        // el zoom para que se vea el numero de salas calculado es X

        // lo cual nos da el zoom a ponerle a la camara:
        camera.orthographicSize = Camera.main.orthographicSize * Mathf.Max(verticalRooms, horizontalRooms) + Camera.main.orthographicSize + minimapZoom;
        
        // POSICION DE LA CAMARA
        // se calcula las posiciones de las esquinas del mapa para calcular en centro del mapa.
        Vector2 esquinaSuperiorIzquierda = new Vector2(DungeonManager.roomMaxNegativeDistance.x - ROOM_X_HALFSIZE, DungeonManager.roomMaxPositiveDistance.y + ROOM_Y_HALFSIZE);
        Vector2 esquinaInferiorDerecha = new Vector2(DungeonManager.roomMaxPositiveDistance.x + ROOM_X_HALFSIZE, DungeonManager.roomMaxNegativeDistance.y- ROOM_Y_HALFSIZE);

        // con el centro del mapa, se sabe donde poner la camara del minimapa y se coloca ahí.
        Vector2 centroDelMapa = (esquinaSuperiorIzquierda * 0.5f + esquinaInferiorDerecha * 0.5f);
        transform.position = (Vector3)centroDelMapa + Vector3.forward * transform.position.z;

    }
}
