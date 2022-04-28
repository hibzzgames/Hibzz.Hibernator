using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Hibzz.Hibernator
{
    public class Hibernator : Singleton<Hibernator>
    {
		/// <summary>
		/// How frequently should the screen refresh (in seconds)
		/// </summary>
		public float RenderFrequency 
		{
			get { return renderFrequency; } 
			set 
			{
				renderFrequency = value;
				renderInterval = Mathf.FloorToInt(Application.targetFrameRate* renderFrequency);
			} 
		}

		// how frequently should the screen refresh (in seconds)
		private float renderFrequency = 0;

		// how frequently should the screen refresh (in frames)
		private int renderInterval = 100;

		// Is the hibernator running
		private bool isRunning = false;

		// How long to refresh the system
		private float time = 0;

		/// <summary>
		/// Start the hibernator
		/// </summary>
		public void Begin()
		{
			isRunning = true;
		}

		/// <summary>
		/// Stop the hibernator
		/// </summary>
		public void Stop()
		{
			isRunning = false;
			OnDemandRendering.renderFrameInterval = 0;
		}

		/// <summary>
		/// Refresh the graphics side of code
		/// </summary>
		/// <param name="time">How long should the system keep refreshing?</param>
		public void Refresh(float time = 0)
		{
			this.time = time;
		}

		// Called once per frame
		private void Update()
		{
			// don't proceed if the system isn't running
			if(!isRunning) { return; }

			// when requesting refresh, maximize the rendering refresh rate
			if (time > 0)
			{
				OnDemandRendering.renderFrameInterval = 0;
				time -= Time.deltaTime;
			}
			else
			{
				OnDemandRendering.renderFrameInterval = renderInterval;
			}
		}
	}
}
