using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class WindowBase : MonoBehaviour
{
	[SerializeField] private Button closeButton;
	[SerializeField] private TextMeshProUGUI titleText;

	public event UnityAction Cleanuped;

	private void Awake()
	{
		OnAwake();

		closeButton?.onClick.AddListener(OnClose);
	}
	private void OnDestroy()
	{
		closeButton?.onClick.RemoveListener(OnClose);
		OnCleanup();
		Cleanuped?.Invoke();
	}

	public void Close()
	{
		OnClose();
	}

	public void SetTitle(string title)
	{
		if (titleText == null) return;

		titleText.text = title;
	}

	protected virtual void OnAwake() { }
	protected virtual void OnClose() { }
	protected virtual void OnCleanup() { }
}