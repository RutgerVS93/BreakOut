using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBeamScript : MonoBehaviour {

    public GameObject parent;

    public GameObject beamLine;
    public GameObject beamSide;

    private GameObject beamSideLeft;
    private GameObject beamSideRight;
    private GameObject beam;

    private LineRenderer line;

    public float textureScrollSpeed = 8f; //How fast the texture scrolls along the beam
    public float textureLengthScale = 3; //Length of the beam texture

    void Start ()
    {
        beamSideLeft = Instantiate(beamSide, new Vector3(-5, -18, 0), Quaternion.identity) as GameObject;
        beamSideLeft.transform.parent = parent.transform;
        beamSideRight = Instantiate(beamSide, new Vector3(5, -18, 0), Quaternion.identity) as GameObject;
        beamSideRight.transform.parent = parent.transform;
        beam = Instantiate(beamLine, Vector3.zero, Quaternion.identity) as GameObject;
        beam.transform.parent = parent.transform;
        line = beam.GetComponent<LineRenderer>();
	}

    void ShootBeamInDir(Vector3 start, Vector3 end)
    {
        line.positionCount = 2;

        line.SetPosition(0, start);
        beamSideLeft.transform.position = start;

        line.SetPosition(1, end);
        beamSideRight.transform.position = end;

        float distance = Vector2.Distance(start, end);
        line.sharedMaterial.mainTextureScale = new Vector2(distance / textureLengthScale, 1);
        line.sharedMaterial.mainTextureOffset -= new Vector2(Time.deltaTime * textureScrollSpeed, 0);
    }

    void Update ()
    {
        ShootBeamInDir(beamSideLeft.transform.position, beamSideRight.transform.position);
    }
}
