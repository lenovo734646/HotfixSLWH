﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotfix.SLWH
{
	public class ThisGameConfig
	{
		public List<int> betSet = new List<int>();
		public int maxRecordCount = 20;
		public void Init()
		{
			betSet.Add(1000);
			betSet.Add(10000);
			betSet.Add(100000);
			betSet.Add(500000);
			betSet.Add(1000000);
			betSet.Add(5000000);
		}
	}
}
