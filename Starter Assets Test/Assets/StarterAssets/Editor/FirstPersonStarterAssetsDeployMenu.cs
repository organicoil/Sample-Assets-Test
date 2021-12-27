using System.Linq;
using UnityEditor;
using UnityEngine;

namespace StarterAssets.Editor
{
public partial class StarterAssetsDeployMenu : ScriptableObject
{

    // prefab paths
    private const string FirstPersonPrefabPath = "/FirstPersonController/Prefabs/";

    #if STARTER_ASSETS_PACKAGES_CHECKED
    /// <summary>
    /// Check the capsule, main camera, cinemachine virtual camera, camera target and references
    /// </summary>
    [MenuItem(StarterAssetsDeployMenu.MenuRoot + "/Reset First Person Controller", false)]
    static void ResetFirstPersonControllerCapsule()
    {
        var firstPersonControllers = FindObjectsOfType<FirstPersonController.FirstPersonController>();
        var player = firstPersonControllers.FirstOrDefault(controller => controller.CompareTag(StarterAssetsDeployMenu.PlayerTag));
        GameObject playerGameObject;

        // player
        if (player == null)
            StarterAssetsDeployMenu.HandleInstantiatingPrefab(StarterAssetsDeployMenu.StarterAssetsPath + FirstPersonPrefabPath,
                                                              StarterAssetsDeployMenu.PlayerCapsulePrefabName, out playerGameObject);
        else
            playerGameObject = player.gameObject;

        // cameras
        StarterAssetsDeployMenu.CheckCameras(FirstPersonPrefabPath, playerGameObject.transform);
    }
    #endif

}
}
