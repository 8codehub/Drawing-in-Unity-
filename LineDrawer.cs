using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    // A reference to the line prefab game object.
    public GameObject linePrefab;

    // A reference to the current line game object.
    private GameObject _currentLine;

    // A reference to the LineRenderer component of the current line game object.
    private LineRenderer _lineRenderer;

    // A reference to the EdgeCollider2D component of the current line game object.
    private EdgeCollider2D _edgeCollider;

    // A list to store the touch positions of the line.
    private List<Vector2> _touchPositions = new List<Vector2>();

    // A constant value to set the sensitivity threshold for creating a new line segment.
    private const float SensitivityThreshold = 0.3f;

    private void Update()
    {
        // Check if mouse button 0 (left mouse button) is pressed down.
        if (Input.GetMouseButtonDown(0))
        {
            // Call the HandleClickDown method.
            HandleClickDown();
        }
        // Check if mouse button 0 (left mouse button) is held down.
        else if (Input.GetMouseButton(0))
        {
            // Call the HandleMoving method.
            HandleMoving();
        }
        // Check if mouse button 0 (left mouse button) is released.
        else if (Input.GetMouseButtonUp(0))
        {
            // Call the HandleClickUp method.
            HandleClickUp();
        }
    }

    private void HandleMoving()
    {
        // Get the current mouse position in world space.
        Vector2 tempTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check if a new line segment can be created.
        if (CanCreateNewLine(tempTouchPos))
        {
            // Call the DrawNewLine method with the new touch position.
            DrawNewLine(tempTouchPos);
        }
    }

    private void HandleClickDown()
    {
        // Instantiate a new line game object using the line prefab.
        _currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);

        // Get the LineRenderer component of the current line game object.
        _lineRenderer = _currentLine.GetComponent<LineRenderer>();

        // Get the EdgeCollider2D component of the current line game object.
        _edgeCollider = _currentLine.GetComponent<EdgeCollider2D>();

        // Add the current mouse position in world space to the touch positions list.
        _touchPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        _touchPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        // Set the start and end positions of the LineRenderer component.
        _lineRenderer.SetPosition(0, _touchPositions[0]);
        _lineRenderer.SetPosition(1, _touchPositions[1]);

        // Set the points of the EdgeCollider2D component to the touch positions list.
        _edgeCollider.points = _touchPositions.ToArray();
    }

    private void DrawNewLine(Vector2 newFingerPos)
    {
        // add the new position of the finger to the list of touch positions
        _touchPositions.Add(newFingerPos);

        // increase the number of positions in the LineRenderer component
        _lineRenderer.positionCount++;

        // set the new position to the last position in the LineRenderer component
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, newFingerPos);

        // set the points in the EdgeCollider2D component to the touch positions
        _edgeCollider.points = _touchPositions.ToArray();
    }

    private void HandleClickUp()
    {
        // Clear the touch positions list
        _touchPositions.Clear();

        // Destroy the current line after 2 seconds
        Destroy(_currentLine, 2f);
    }

    private bool CanCreateNewLine(Vector2 tempTouchPos)
    {
        // Check if the distance between the current touch position and the last touch position in the list is greater than the sensitivity threshold
        return Vector2.Distance(tempTouchPos, _touchPositions[_touchPositions.Count - 1]) > SensitivityThreshold;
    }
}