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

	[SerializeField]
	private string charaDieAnimation;

	[SerializeField]
	private string charaTaikiAnimation;

	private int a;
	private int b;
	private int timer=0;
	bool set;

	private SkeletonAnimation  _skeletonAnimation;

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

		_skeletonAnimation = GetComponent<SkeletonAnimation>();

		a =0;
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

		// Aキーの入力でアニメーションを切り替えるテスト
		if (Player.OnGround==true&&b==0&&Player.lifePoint!=0)
		{
			PlayRunAnimation();
			b=1;
		}

        //_skeletonAnimation.skeleton.R = Mathf.PerlinNoise(Time.time*4, 0);
        //_skeletonAnimation.skeleton.G = Mathf.PerlinNoise(Time.time * 4, 0);
        ///_skeletonAnimation.skeleton.B = Mathf.PerlinNoise(Time.time * 4, 0);
        if(Player.blink == true) {
			timer += 1;
			if(timer > 20) {
				if(set == true) {
					_skeletonAnimation.skeleton.A = 0f;
					set = false;
					timer = 0;
				} else
				if(set == false) {
					_skeletonAnimation.skeleton.A = 1f;
					set = true;
					timer = 0;
				}
			}
		}else if(Player.blink==false) {
			_skeletonAnimation.skeleton.A = 1f;
		}
		
	}

	/// <summary>
	/// Spineアニメーションを再生
	/// testAnimationNameに再生したいアニメーション名を記載してください。
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
