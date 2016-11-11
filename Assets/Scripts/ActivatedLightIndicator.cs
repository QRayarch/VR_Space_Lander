using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ShipComponent))]
public class ActivatedLightIndicator : MonoBehaviour {

    public MeshRenderer meshRender;
    public Material activatedMat;
    public Material deactivatedMat;

    private ShipComponent shipComponent;

	// Use this for initialization
	void Start () {
        shipComponent = GetComponent<ShipComponent>();
        shipComponent.OnActivated += Activated;
        shipComponent.OnDeactivate += Deactivated;
        Deactivated();
    }

    public void Activated()
    {
        meshRender.material = activatedMat;
    }

    public void Deactivated()
    {
        meshRender.material = deactivatedMat;
    }
}
