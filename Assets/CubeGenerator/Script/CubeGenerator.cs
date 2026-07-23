using UnityEngine;
using DG.Tweening;
public class CubeGenerator : MonoBehaviour
{
	[SerializeField]
	private GameObject _cube;
	[SerializeField]
	private Transform _pos;



	private RemoveAndEffectObject _lastObjectRemover;



	private bool _isGenerating;
	public void GenerateCube(bool value)
	{
		if (!value)
			return;
		if (_isGenerating)
			return;
		_isGenerating = true;
		Sequence sequence = DOTween.Sequence();
		if (_lastObjectRemover != null)
		{
			sequence.Append(_lastObjectRemover.RemoveAndEffect());
		}

		sequence.AppendCallback(() =>
		{

			GameObject obj =  Instantiate(_cube, _pos.position,Quaternion.identity);
			_lastObjectRemover = obj.GetComponent<RemoveAndEffectObject>();
			if( _lastObjectRemover != null)
			{
				_lastObjectRemover.OnRemoveEnd += RemovedLastObject;
			}
		});

		sequence.AppendCallback(() => _isGenerating = false);
	}

	private void RemovedLastObject()
	{
		_lastObjectRemover = null;
		GenerateCube(true);
	}

	private void OnDestroy()
	{
		if(_lastObjectRemover!=null)
			_lastObjectRemover. OnRemoveEnd -= RemovedLastObject;
	}
}
