using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float Horizontal => snapX ? SnapFloat(input.x, AxisOptions.Horizontal) : input.x;
    public float Vertical => snapY ? SnapFloat(input.y, AxisOptions.Vertical) : input.y;
    public Vector2 Direction => new Vector2(Horizontal, Vertical);

    public float HandleRange
    {
        get => handleRange;
        set => handleRange = Mathf.Abs(value);
    }
    public float DeadZone
    {
        get => deadZone;
        set => deadZone = Mathf.Abs(value);
    }

    public AxisOptions AxisOptions { get => axisOptions; set => axisOptions = value; }
    public bool SnapX { get => snapX; set => snapX = value; }
    public bool SnapY { get => snapY; set => snapY = value; }

    [SerializeField] private float handleRange = 1;
    [SerializeField] private float deadZone = 0;
    [SerializeField] private AxisOptions axisOptions = AxisOptions.Both; // Permitir ambas direcciones
    [SerializeField] private bool snapX = false;
    [SerializeField] private bool snapY = false;

    [SerializeField] protected RectTransform background = null;
    [SerializeField] private RectTransform handle = null;
    private RectTransform baseRect = null;

    private Canvas canvas;
    private Camera cam;
    private Vector2 input = Vector2.zero;

    protected virtual void Start()
    {
        HandleRange = handleRange;
        DeadZone = deadZone;
        baseRect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
            Debug.LogError("The Joystick is not placed inside a canvas.");

        Vector2 center = new Vector2(0.5f, 0.5f);
        background.pivot = center;
        handle.anchorMin = center;
        handle.anchorMax = center;
        handle.pivot = center;
        handle.anchoredPosition = Vector2.zero;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        cam = canvas.renderMode == RenderMode.ScreenSpaceCamera ? canvas.worldCamera : null;
        Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
        Vector2 radius = background.sizeDelta / 2;

        input = (eventData.position - position) / (radius * canvas.scaleFactor);
        FormatInput();
        HandleInput(input.magnitude, input.normalized, radius, cam);

        handle.anchoredPosition = input * radius * handleRange;
    }

    protected virtual void HandleInput(float magnitude, Vector2 normalized, Vector2 radius, Camera cam)
    {
        input = magnitude > deadZone ? (magnitude > 1 ? normalized : input) : Vector2.zero;
    }

    private void FormatInput()
    {
        // Al configurar AxisOptions como Both, el joystick permite ambas direcciones
        if (axisOptions == AxisOptions.Horizontal)
            input = new Vector2(input.x, 0f);
        else if (axisOptions == AxisOptions.Vertical)
            input = new Vector2(0f, input.y);
        // No se aplica ninguna restricción si AxisOptions es Both
    }

    private float SnapFloat(float value, AxisOptions snapAxis)
    {
        if (value == 0)
            return value;

        if (axisOptions == AxisOptions.Both)
        {
            return Mathf.Sign(value); // Permitir movimiento en ambas direcciones
        }
        return Mathf.Sign(value);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }

    protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRect, screenPosition, cam, out localPoint))
        {
            Vector2 pivotOffset = baseRect.pivot * baseRect.sizeDelta;
            return localPoint - (background.anchorMax * baseRect.sizeDelta) + pivotOffset;
        }
        return Vector2.zero;
    }
}

public enum AxisOptions { Both, Horizontal, Vertical }
