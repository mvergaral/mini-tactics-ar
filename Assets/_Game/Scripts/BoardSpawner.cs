using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class BoardSpawner : MonoBehaviour
{
    public GameObject boardPrefab;

    private ARRaycastManager _raycastManager;
    private GameObject _spawnedBoard;
    static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    void Awake()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (_spawnedBoard != null)
            return;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            TryPlaceBoard(mousePos);
        }
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                TryPlaceBoard(touch.position);
            }
        }
#endif
    }

    void TryPlaceBoard(Vector2 screenPosition)
    {
        if (_raycastManager.Raycast(screenPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = _hits[0].pose;
            _spawnedBoard = Instantiate(boardPrefab, hitPose.position, hitPose.rotation);

            // Opcional: rotar el board para mirar a la cámara (solo en eje Y)
            Vector3 camForward = Camera.main.transform.forward;
            camForward.y = 0;
            _spawnedBoard.transform.rotation = Quaternion.LookRotation(camForward);

            // Ocultar planos detectados
            foreach (var plane in FindObjectsByType<ARPlane>(FindObjectsSortMode.None))
            {
                plane.gameObject.SetActive(false);
            }

            // Opcional: desactivar el ARPlaneManager para que no sigan apareciendo nuevos planos
            var planeManager = FindFirstObjectByType<ARPlaneManager>();
            if (planeManager != null)
            {
                planeManager.enabled = false;
            }


            Debug.Log("Board colocado en: " + hitPose.position);
        }
        else
        {
            Debug.Log("No se detectó ningún plano.");
        }
    }
}
