using UnityEngine;
using UnityStandardAssets.CinematicEffects;

[RequireComponent(typeof(DepthOfField))]
public class DepthOfFieldHelper : MonoBehaviour {

	[SerializeField]
	private float lerpSpeed = 5f;

	private DepthOfField DOF;

	void Awake ()
	{
		DOF = GetComponent<DepthOfField>();
    }

	void Update ()
	{
		RaycastHit _hitInfo;
		if (Physics.Raycast(transform.position, transform.forward, out _hitInfo))
		{
			float _dist = (Camera.main.WorldToViewportPoint(_hitInfo.point)).z / (Camera.main.farClipPlane);
			float _plane = Mathf.Pow(_dist, 1f/4f);

			DOF.focus.plane = Mathf.Lerp(DOF.focus.plane, _plane, Time.deltaTime * lerpSpeed);
		}
	}

}
