using UnityEngine;

public class FlashlightIK : MonoBehaviour
{
    public Animator animator;
    public Transform ikTarget;
    [Range(0f, 1f)] public float ikWeight = 1f;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, ikWeight);

        animator.SetIKPosition(AvatarIKGoal.LeftHand, ikTarget.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, ikTarget.rotation);
    }   

}
