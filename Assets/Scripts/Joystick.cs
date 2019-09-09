using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	private Image JoystickBG;
	private Image JoystickMove;
	public Vector3 direction;
	// Use this for initialization
	void Start ()
	{
		JoystickBG = GetComponent<Image> ();
		JoystickMove = transform.GetChild (0).GetComponentInChildren<Image> ();
		direction = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void OnDrag (PointerEventData data)
	{
		Vector2 pos = Vector2.zero;

		//check vi tri joystickMove nam trong joystickBackground
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (JoystickBG.rectTransform, data.position, data.pressEventCamera, out pos)) {
			pos.x = (pos.x / JoystickBG.rectTransform.sizeDelta.x);
			pos.y = (pos.y / JoystickBG.rectTransform.sizeDelta.y);
			float horizontal = (JoystickBG.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2;
			float vertical = (JoystickBG.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2;
			direction = new Vector3 (horizontal, 0, vertical);
			direction = (direction.magnitude > 1) ? direction.normalized : direction;
			JoystickMove.rectTransform.anchoredPosition = new Vector2 (direction.x * (JoystickBG.rectTransform.sizeDelta.x / 3),
				direction.z * (JoystickBG.rectTransform.sizeDelta.y / 3));
		}
	}

	public void OnPointerDown (PointerEventData data)
	{
		OnDrag (data);
	}

	public void OnPointerUp (PointerEventData data)
	{
		direction = Vector3.zero;
		JoystickMove.rectTransform.anchoredPosition = Vector3.zero;
	}
}
