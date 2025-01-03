using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _ignoreLayer;
    [SerializeField] private CubeFactory _spawner;
    private Selectable _currentSelectable;

    private void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~_ignoreLayer))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    _spawner.Create(cube);
                    cube.Destroy();
                    Destroy(cube.gameObject);
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
                CheckForSelect();
            }
            
        }
        else
        {
            CheckForSelect();
        }
    }

    private void CheckForSelect()
    {
        if (_currentSelectable)
        {
            _currentSelectable.Deselect();
            _currentSelectable = null;
        }
    }
}
