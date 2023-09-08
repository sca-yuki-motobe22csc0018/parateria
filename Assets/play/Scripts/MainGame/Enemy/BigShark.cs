using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class BigShark : MonoBehaviour
{
    [SerializeField] int Shark;
    float x, startX, endX;
    float moveTime;
    float nowTime;

    [SerializeField]
    private string sharkAnimation;

    /// <summary> �Q�[���I�u�W�F�N�g�ɐݒ肳��Ă���SkeletonAnimation </summary>
	private SkeletonAnimation skeletonAnimation = default;

    /// <summary> Spine�A�j���[�V������K�p���邽�߂ɕK�v��AnimationState </summary>
    private Spine.AnimationState spineAnimationState = default;

    private void Start()
    {
        x = transform.position.x;
        // �Q�[���I�u�W�F�N�g��SkeletonAnimation���擾
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        // SkeletonAnimation����AnimationState���擾
        spineAnimationState = skeletonAnimation.AnimationState;
    }

    public void cf()
    {
        StartCoroutine(MoveShark());
    }

    public IEnumerator MoveShark()
    {
        SharkAnimation();
        bool move = false;
        MoveStart(8.0f,1.0f);
        yield return null;
        while (!move)
        {
            yield return null;
            nowTime += Time.deltaTime;
            if (nowTime > moveTime)
            {
                nowTime = moveTime;
                move = true;
            }
            x = nowTime / moveTime * (endX - startX) + startX;
            transform.position = new Vector2(x, transform.position.y);
        }

        yield return new WaitForSeconds(0.5f);
        MoveStart(13.0f, 1.5f);
        nowTime = 0.0f;

        while (move)
        {
            yield return null;
            nowTime += Time.deltaTime;
            if (nowTime > moveTime)
            {
                nowTime = moveTime;
                move = false;
            }
            x = nowTime / moveTime * (endX - startX) + startX;
            transform.position = new Vector2(x, transform.position.y);
        }
    }

    void MoveStart(float toX, float time)
    {
        startX = x;
        endX = toX;
        moveTime = time;
        nowTime = 0.0f;
        return;
    }

    private void SharkAnimation()
    {
        spineAnimationState.SetAnimation(0, sharkAnimation, false);
    }
}
