﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

namespace OpenTK.Android.Test
{
	// the ConfigurationChanges flags set here keep the EGL context
	// from being destroyed whenever the device is rotated or the
	// keyboard is shown (highly recommended for all GL apps)
	[Activity (Label = "OpenTK.Android.Test",
				#if __ANDROID_11__
				HardwareAccelerated=false,
				#endif
		ConfigurationChanges = ConfigChanges.Orientation | 
			ConfigChanges.KeyboardHidden | 
			ConfigChanges.ScreenSize |
			ConfigChanges.Orientation,
		MainLauncher = true,
		Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		GLView1 view;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create our OpenGL view, and display it
			view = new GLView1 (this);
			SetContentView (view);



			view.Run ();
		}

		protected override void OnPause ()
		{
			// never forget to do this!
			base.OnPause ();
			view.Pause ();
		}

		protected override void OnResume ()
		{
			// never forget to do this!
			base.OnResume ();
			view.Resume ();
		}
	}
}


