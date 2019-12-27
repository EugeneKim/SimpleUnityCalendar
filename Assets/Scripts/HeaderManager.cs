using TMPro;
using UnityEngine;

public class HeaderManager : MonoBehaviour
{
	#region Fields

	[SerializeField]
	private TextMeshProUGUI title;

	#endregion

	#region Public Methods

	public void SetTitle(string text)
	{
		title.text = text;
	}

	#endregion
}
