using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator = null;
    [SerializeField] float dampForward = .1f;
    [SerializeField] float dampRight = .1f;
    [SerializeField] float dampSpeed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateForwardAnimatorParam(float _value)
    {
        if (!playerAnimator) return;
        playerAnimator.SetFloat(AnimationParamaters.ForwardAxisParam, _value, dampForward, Time.deltaTime);
    } 

    public void UpdateRightAnimatorParam(float _value)
    {
        if (!playerAnimator) return;
        playerAnimator.SetFloat(AnimationParamaters.RightAxisParam, _value, dampRight, Time.deltaTime);
    }

    public void UpdateRotateAnimatorParam(float _value)
    {
        if (!playerAnimator) return;
        playerAnimator.SetFloat(AnimationParamaters.RotateAxisParam, _value, dampSpeed, Time.deltaTime);
    }

}
