using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class CharaSpineMove : MonoBehaviour
{
	/// <summary> �Đ�����A�j���[�V������ </summary>
	[SerializeField]
	private string charaRunAnimation;

	[SerializeField]
	private string charaJumpAnimation;

	[SerializeField]
	private string charaDieAnimation;

	[SerializeField]
	private string charaTaikiAnimation;

	private int a;
	private int b;

	/// <summary> �Q�[���I�u�W�F�N�g�ɐݒ肳��Ă���SkeletonAnimation </summary>
	private SkeletonAnimation skeletonAnimation = default;

	/// <summary> Spine�A�j���[�V������K�p���邽�߂ɕK�v��AnimationState </summary>
	private Spine.AnimationState spineAnimationState = default;

	private void Start()
	{
		// �Q�[���I�u�W�F�N�g��SkeletonAnimation���擾
		skeletonAnimation = GetComponent<SkeletonAnimation>();

		// SkeletonAnimation����AnimationState���擾
		spineAnimationState = skeletonAnimation.AnimationState;

		a=0;
		b=1;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1 && Player.jumpCount < 4&&Player.lifePoint!=0)
		{
			PlayJumpAnimation();
			b = 0;
		}

        if (Player.lifePoint == a)
        {
			PlayDieAnimation();
			a=1;
			
        }

		// A�L�[�̓��͂ŃA�j���[�V������؂�ւ���e�X�g
		if (Player.OnGround==true&&b==0&&Player.lifePoint!=0)
		{
			PlayRunAnimation();
			b=1;
		}
		
	}

	/// <summary>
	/// Spine�A�j���[�V�������Đ�
	/// testAnimationName�ɍĐ��������A�j���[�V���������L�ڂ��Ă��������B
	/// </summary>
	private void PlayRunAnimation()
	{
		spineAnimationState.SetAnimation(0, charaRunAnimation, true);
	}

	private void PlayJumpAnimation()
	{
		spineAnimationState.SetAnimation(0, charaJumpAnimation, false);
	}

	private void PlayDieAnimation()
	{
		spineAnimationState.SetAnimation(0, charaDieAnimation, false);
	}
}