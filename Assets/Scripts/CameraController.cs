using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CameAnimChange(string AnimName)
    {
        animator.SetBool(AnimName, true);
    }
}
