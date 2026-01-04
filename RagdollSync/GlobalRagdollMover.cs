using HarmonyLib;
using InventorySystem.Items.DebugTools;
using UnityEngine.Windows;
using UnityEngine;

namespace RagdollSync
{
    [HarmonyPatch(typeof(RagdollMover))]
    public class GlobalRagdollMover
    {
        [HarmonyPatch("UpdateMoving")]
        [HarmonyPostfix]
        public static void UpdateMovingPostfix()
        {
            if (_hitRb == null)
            {
                _hasHit = false;
                return;
            }

            if (Input.GetKeyDown(FreezeKey))
            {
                _hitRb.isKinematic = !_hitRb.isKinematic;
            }

            Transform transform = _hitRb.transform;
            Vector3 vector = Cam.position + Cam.forward * _hitDist;
            Vector3 vector2 = transform.TransformPoint(_hitLocalPos);
            Vector3 vector3 = vector - vector2;
            float num = vector3.magnitude * _proportionalForce;
            if (num < _maxForce)
            {
                _hitRb.AddForceAtPosition(vector3 * num, vector, ForceMode.Force);
            }
            else
            {
                transform.position += vector3;
            }
        }
    }
}
