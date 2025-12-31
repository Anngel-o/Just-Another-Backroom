using UnityEngine;

public class FlashlightIK : MonoBehaviour
{
    public Animator animator;
    public Transform ikTarget;
    [Range(0f, 1f)] public float ikWeight = 1f;

    void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

        animator.SetIKPosition(AvatarIKGoal.LeftHand, ikTarget.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, ikTarget.rotation);
    }

}
