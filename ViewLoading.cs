using AssemblyCommon;
using Hotfix.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Hotfix.SLWH
{

	public class AShower : IShowDownloadProgress
	{
		public ViewLoading vl_;
		public override void OnProgress(long downed, long totalLength)
		{
			if (totalLength == 0) return;
			per_ = downed / totalLength;
			if (vl_.slider != null) vl_.slider.maxValue = totalLength;
			if (vl_.slider != null) vl_.slider.value = downed;
		}

		public override void OnDesc(string desc)
		{
			if (vl_.txt != null) vl_.txt.text = desc;
		}

		public override void OnSetState(DownloadState st)
		{

		}
		float per_ = 0.0f;
	}

	public class ViewLoading : ViewBase
	{
		public Slider slider;
		public Text txt;
		public AShower loading = new AShower();

		public ViewLoading():base(null)
		{
			loading.vl_ = this;
		}

		protected override void SetLoader()
		{
			LoadScene("Assets/Res/Games/SLWH/Scenes/LoadingScene.unity", null);
		}

		protected override IEnumerator OnResourceReady()
		{
			yield return base.OnResourceReady();
			var canvas = GameObject.Find("Canvas");
			slider = canvas.FindChildDeeply("Slider").GetComponent<Slider>();
			txt = canvas.FindChildDeeply("Text").GetComponent<Text>();
		}

	}
}
