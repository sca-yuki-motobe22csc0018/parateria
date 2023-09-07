using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class CharaSpineMove : MonoBehaviour
{
	/// <summary> 再生するアニメーション名 </summary>
	[SerializeField]
	private string charaRunAnimation;

	[SerializeField]
	private string charaJumpAnimation;

	/// <summary> ゲームオブジェクトに設定されているSkeletonAnimation </summary>
	private SkeletonAnimation skeletonAnimation = default;

	/// <summary> Spineアニメーションを適用するために必要なAnimationState </summary>
	private Spine.AnimationState spineAnimationState = default;

	private void Start()
	{
		// ゲームオブジェクトのSkeletonAnimationを取得
		skeletonAnimation = GetComponent<SkeletonAnimation>();

		// SkeletonAnimationからAnimationStateを取得
		spineAnimationState = skeletonAnimation.AnimationState;
	}

	private void Update()
	{/*
        if (Player.Jump == true)
        {
			PlayJumpAnimation();
        }
		// Aキーの入力でアニメーションを切り替えるテスト
		if (Player.OnGround==true)
		{
			PlayRunAnimation();
		}
		*/
	}

	/// <summary>
	/// Spineアニメーションを再生
	/// testAnimationNameに再生したいアニメーション名を記載してください。
	/// </summary>
	private void PlayRunAnimation()
	{
		// アニメーション「testAnimationName」を再生
		spineAnimationState.SetAnimation(0, charaRunAnimation, true);
	}

	private void PlayJumpAnimation()
	{
		// アニメーション「testAnimationName」を再生
		spineAnimationState.SetAnimation(0, charaJumpAnimation, true);
	}

}
