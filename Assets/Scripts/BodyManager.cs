using System;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
	#region Fields

	[SerializeField]
	private GameObject buttonPrefab;

	[SerializeField]
	private GameObject placeHolderPrefab;

	private List<GameObject> cells;

	#endregion

	#region Public Methods

	public void Initialize(int year, int month, Action<(string, string)> clickEventHandler)
	{
		var dateTime = new DateTime(year, month, 1);
		var daysInMonth = DateTime.DaysInMonth(year, month);

		var dayOfWeek = (int)dateTime.DayOfWeek;
		var size = (dayOfWeek + daysInMonth) / 7;

		if ((dayOfWeek + daysInMonth) % 7 > 0)
			size++;

		var arr = new int[size * 7];

		for (var i = 0; i < daysInMonth; i++)
			arr[dayOfWeek + i] = i + 1;

		if (cells == null)
			cells = new List<GameObject>();

		foreach(var c in cells)
			Destroy(c);

		cells.Clear();

		foreach(var a in arr)
		{
			var instance = Instantiate(a == 0 ? placeHolderPrefab : buttonPrefab, transform);
			var buttonManager = instance.GetComponent<ButtonManager>();

			if (buttonManager != null)
				buttonManager.Initialize(a.ToString(), clickEventHandler);

			cells.Add(instance);
		}
	}

	#endregion
}
