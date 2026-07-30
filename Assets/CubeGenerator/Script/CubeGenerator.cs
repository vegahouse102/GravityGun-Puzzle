using UnityEngine;
using DG.Tweening;
public class CubeGenerator : MonoBehaviour
{
	[SerializeField]
	private GameObject _cube;
	[SerializeField]
	private Transform _pos;
	[SerializeField]
	private RemoveAndEffectObject _connectCreatedCube;


	private RemoveAndEffectObject _lastObjectRemover;



	private bool _isGenerating;

	private void Start()
	{
		if (_connectCreatedCube != null)
		{
			_lastObjectRemover = _connectCreatedCube;
			_lastObjectRemover.OnRemoveEnd += RemovedLastObject;
			
		}
	}
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
			RemoveAndEffectObject lastObjectRemover = obj.GetComponent<RemoveAndEffectObject>();
			if(lastObjectRemover != null)
			{
				if (_lastObjectRemover != null)
					_lastObjectRemover.OnRemoveEnd -= RemovedLastObject;
				_lastObjectRemover = lastObjectRemover;
				_lastObjectRemover.OnRemoveEnd += RemovedLastObject;
			}
		});

		sequence.AppendCallback(() => _isGenerating = false);
	}

	private void RemovedLastObject(GameObject removedObject)
	{
		Debug.Log("ddd");
		_lastObjectRemover = null;
		GenerateCube(true);
	}

	private void OnDestroy()
	{
		if(_lastObjectRemover!=null)
			_lastObjectRemover. OnRemoveEnd -= RemovedLastObject;
	}
}
