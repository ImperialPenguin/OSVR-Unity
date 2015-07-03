/// OSVR-Unity Connection
///
/// http://sensics.com/osvr
///
/// <copyright>
/// Copyright 2014,2015 Sensics, Inc.
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///     http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
/// </copyright>

using UnityEngine;
using System;

namespace OSVR
{
	namespace Unity
	{
		/// <summary>
		/// Analog Interface - exposes an analog interface to other scene objects.
		///
		/// Attach to a GameObject that is interested in analog button state or events.
		/// </summary>
		public class AnalogInterface : InterfaceGameObjectBase
		{
			public OSVR.ClientKit.AnalogInterface Interface { get; protected set; }
			
			override protected void Start()
			{
				base.Start();
				if (!String.IsNullOrEmpty(usedPath))
				{
					Interface = OSVR.ClientKit.AnalogInterface.GetInterface(
						ClientKit.instance.context, usedPath);
				}
			}
			
			protected override void Stop()
			{
				base.Stop();
				if(Interface != null)
				{
					Interface.Dispose();
					Interface = null;
				}
			}
		}
	}
}
