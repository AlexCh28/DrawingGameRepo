using System;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public event Action<Vector3[]> OnDrawingComplete;

    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Transform _finish;
    [SerializeField]
    private float _minDistance;
    private LineRenderer _line;
    private Touch _touch;
    private Vector3 _touchWorldPos;
    private Vector2 _previousPoint;
    private int _vertIndex;
    private bool _isStarted;
    private bool _isFinished;

    public bool IsFinished => _isFinished;

    private void Awake() {
        _line = GetComponent<LineRenderer>();
        SetDefaultLineOriginOrFinish();
    }

    private void FixedUpdate() {
        if (_isFinished) return;

        if (Input.touchCount<=0) { SetDefaultLineOriginOrFinish(); return;}

        _touch = Input.GetTouch(0);
        _touchWorldPos = Camera.main.ScreenToWorldPoint(_touch.position);

        RaycastHit2D hit = Physics2D.Raycast(_touchWorldPos, Vector2.zero);

        if(!_isStarted && hit.transform != null && hit.transform == _target)
        {
            _isStarted = true;
        }

        if (!_isStarted) return;

        if (Vector2.Distance(new Vector2(_touchWorldPos.x, _touchWorldPos.y), _previousPoint) < _minDistance) return;

        _line.positionCount++;
        _line.SetPosition(_vertIndex, new Vector3(_touchWorldPos.x, _touchWorldPos.y, 0));

        _vertIndex += 1;
        _previousPoint = new Vector2(_touchWorldPos.x, _touchWorldPos.y);        
    }

    private void SetDefaultLineOriginOrFinish(){
        RaycastHit2D hit = Physics2D.Raycast(_touchWorldPos, Vector2.zero);

        if(_isStarted && hit.transform != null && (hit.transform == _finish || hit.transform.CompareTag("Universal")))
        {
            _isStarted = false;
            _isFinished = true;
            
            Vector3[] waypoints = new Vector3[_line.positionCount];
            _line.GetPositions(waypoints);
            OnDrawingComplete?.Invoke(waypoints);
        }

        else{
            _isStarted = false;
            _vertIndex = 1; 
            _line.positionCount = 1;
            _previousPoint = new Vector2(_target.position.x, _target.position.y);
            _line.SetPosition(0, _previousPoint);
        }
    }
}
