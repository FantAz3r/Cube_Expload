using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private const int _leftMouceButton = 0; 

    [SerializeField] private LayerMask _ignoreLayer;
    [SerializeField] private CubeFactory _spawner;
    [SerializeField] private Exploader _exploader;

    private Selectable _currentSelectable;
    private Camera _mainCamera;
    private int _minChance = 0;
    private int _maxChance = 100;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        List<Cube> createdCubes = new List<Cube>();
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~_ignoreLayer))
        {
            if (Input.GetMouseButtonDown(_leftMouceButton))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    if (cube.SeparationChance > Random.Range(_minChance, _maxChance + 1))
                    {
                        createdCubes = _spawner.Create(cube);
                        Destroy(cube.gameObject);
                        _exploader.Explode(cube, createdCubes);
                    }
                }
            }

            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();

            if (selectable != null)
            {
                if(_currentSelectable && _currentSelectable != selectable)
                {
                    _currentSelectable.Deselect();
                }

                _currentSelectable = selectable;
                selectable.Select();
            }
            else 
            {
                Deselect();
            }
            
        }
        else
        {
            Deselect();
        }
    }

    private void Deselect()
    {
        if (_currentSelectable)
        {
            _currentSelectable.Deselect();
            _currentSelectable = null;
        }
    }
}
