using Rage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EggInABin {
	public class Start {
		public static void Main() {
			System.UInt32[] bins = { 1437508529, 1614656839, 4164154385, 4201147406, 1329570871, 1143474856, 4066370557, 3826337632, 2868958492, 3107680657, 3198190107, 3881769092, 437765445, 2464174121, 3965551402, 3953524871, 1792999139, 2198842852, 122303831, 1748268526, 998415499, 234941195, 4289023572, 3977789650, 1380691550, 218085040, 666561306, 4236481708, 4088277111, 3945129724, 1511880420, 682791951, 4179196157, 375956747, 673826957, 4209363037, 1233216915, 354692929, 4280259234, 811169045, 4198320122, 3907562202, 364445978, 3779688480, 2954040756, 2463859593, 3299174172, 1605769687, 388197031, 161075092, 2504789729, 1919238784, 3640092973, 651101403, 909943734 };
			var binLocations = new Dictionary<PoolHandle, Tuple<Boolean, Vector3>>();

			while (true) {
				Rage.Object[] objects = World.GetAllObjects();
				foreach (var item in objects) {
					if (bins.Contains(item.Model.Hash)) {
						if (!binLocations.Keys.Contains(item.Handle)) {
							binLocations.Add(item.Handle, new Tuple<Boolean, Vector3>(true, item.Position));
						}
					}
				}

				foreach (var item in binLocations.ToArray()) {
					if (item.Value.Item1 && Game.LocalPlayer.Character.Position.DistanceTo(item.Value.Item2) <= 5) {
						binLocations[item.Key] = new Tuple<Boolean, Vector3>(false, item.Value.Item2);
						World.SpawnExplosion(item.Value.Item2, 43, 8, true, false, 1.0f);
					}
				}

				GameFiber.Yield();
			}
		}
	}
}
