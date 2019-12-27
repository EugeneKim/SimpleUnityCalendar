using System;
using System.Globalization;
using UnityEngine;

public class CalendarManager : MonoBehaviour
{
	#region Fields

	[SerializeField]
	private HeaderManager headerManager;

	[SerializeField]
	private BodyManager bodyManager;

	[SerializeField]
	private TailManager tailManager;

	private DateTime targetDateTime;
	private CultureInfo cultureInfo;

	#endregion

	#region Public Methods

	public void OnGoToPreviousOrNextMonthButtonClicked(string param)
	{
		targetDateTime = targetDateTime.AddMonths(param == "Prev" ? -1 : 1);
		Refresh(targetDateTime.Year, targetDateTime.Month);
	}

	#endregion

	#region Private Methods

	private void Start()
	{
		targetDateTime = DateTime.Now;
		cultureInfo = new CultureInfo("en-US");
		Refresh(targetDateTime.Year, targetDateTime.Month);
	}

	#endregion

	#region Event Handlers

	private void Refresh(int year, int month)
	{
		headerManager.SetTitle($"{year} {cultureInfo.DateTimeFormat.GetMonthName(month)}");
		bodyManager.Initialize(year, month, OnButtonClicked);
	}

	private void OnButtonClicked((string day, string legend) param)
	{
		tailManager.SetLegend($"You have clicked day {param.day}.");
	}

	#endregion
}
