using TMPro;
using UnityEngine;

public class TailManager : MonoBehaviour
{
	#region Fields

	[SerializeField]
	private TextMeshProUGUI legend;

	#endregion

	#region Public Methods

	public void SetLegend(string text)
	{
		legend.text = text;
	}

	#endregion
}
