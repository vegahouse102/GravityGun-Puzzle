using UnityEngine;
using System.Collections.Generic;

public class MovingLineRender : MonoBehaviour
{
	[SerializeField]
	LineRenderer _lineRenderer;
	[SerializeField]
	MovingPlatform _movingPlatform;
	void Start()
	{
		var movePoints = _movingPlatform.GetPlatformMovePoints();

		_lineRenderer.positionCount = movePoints.Count;

		for (int i = 0; i < movePoints.Count; i++)
		{
			_lineRenderer.SetPosition(i, movePoints[i].position);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
