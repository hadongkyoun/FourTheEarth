using UnityEngine;
using PurrNet;
public class CubeSpawner : NetworkBehaviour
{
    [Header("Sample Spawn")]
    [SerializeField]
    private GameObject cubePrefab;
    private GameObject currentCube;

    protected override void OnSpawned(bool asServer)
    {
        base.OnSpawned(asServer);

        enabled = isOwner;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if(currentCube != null)
            {
                Destroy(currentCube);
            }
            currentCube = Instantiate(cubePrefab, transform.position, transform.rotation);
        }
    }
}
