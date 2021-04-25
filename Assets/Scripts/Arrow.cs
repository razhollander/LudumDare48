using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    int CLICK_ANIMATION = Animator.StringToHash("ArrowClicked");

    [SerializeField]
    Animator _animtor;

    //float animationTime;
    //private void Awake()
    //{
    //    AnimationClip[] clips = _animtor.runtimeAnimatorController.animationClips;
    //    foreach (AnimationClip clip in clips)
    //    {
    //        if(clip.GetHashCode() == CLICK_ANIMATION)
    //            animationTime = clip.length;
    //            break;
    //    }
    //}

    public void Click(Vector2 pos)
    {
        transform.position = pos;
        gameObject.SetActive(true);
        _animtor.Play(CLICK_ANIMATION);
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

}
