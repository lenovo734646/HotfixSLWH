using AssemblyCommon;
using Hotfix.Common;
using Hotfix.Common.MultiPlayer;
using LitJson;
using System.Collections;
using UnityEngine;

namespace Hotfix.SLWH
{
	public class GameController : GameControllerMultiplayer
	{
		ViewLoading loading;
		public override void Start()
		{
			base.Start();
			this.StartCor(ShowLoading_(), false);
		}

		public override IEnumerator ShowLogin()
		{
			MyDebug.Log("ShowLogin()");
			return base.ShowLogin();
		}

		IEnumerator ShowLoading_()
		{
			loading = new ViewLoading();
			OpenView(loading);
			yield return 0;
		}

		//调用这个避免内存泄露
		public override void Stop()
		{
			//移除所有正在执行的协程.
			this.StopCor(-1);
			base.Stop();
		}

		IEnumerator DoLoadMainScene()
		{
			yield return loading.WaitingForReady();
			//需要等待loding scene完成,不能同时load2个scene,必须等一个完成
			ViewGameScene view = new ViewGameScene(loading.loading);
			OpenView(view);
			yield return view.WaitingForReady();
			yield return 0;
		}

		protected override IEnumerator OnGameLoginSucc()
		{
			if(mainView != null) {
				mainView.Close();
			}
			yield return base.OnGameLoginSucc();
			yield return DoLoadMainScene();
		}

		public override msg_random_result_base CreateRandomResult(string json)
		{
			return JsonMapper.ToObject<msg_random_result_slwh>(json);
		}

		public override msg_last_random_base CreateLastRandom(string json)
		{
			return JsonMapper.ToObject<msg_last_random_slwh>(json);
		}
	}
}
