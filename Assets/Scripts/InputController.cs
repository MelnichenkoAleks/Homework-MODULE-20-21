using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private float dragHeightOffset;
    [SerializeField] private float boomRadius;
    [SerializeField] private float boomForce;

    [SerializeField] private GameObject boomEffectPrefab;

    private DragService _dragService;
    private ExplosionService _explosionService;

    private void Awake()
    {
        _dragService = new DragService(dragHeightOffset);
        _explosionService = new ExplosionService(boomRadius, boomForce, boomEffectPrefab);
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            _dragService.TrySelectObject(ray);

        if (Input.GetMouseButton(0))
            _dragService.DragObject(ray);

        if (Input.GetMouseButtonUp(0))
            _dragService.ReleaseObject();

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
                _explosionService.CreateExplosion(hit.point);
        }
    }
}
