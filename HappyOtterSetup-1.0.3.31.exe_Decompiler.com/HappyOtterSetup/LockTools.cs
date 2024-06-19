using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace HappyOtterSetup;

public class LockTools
{
	private delegate void a(TreeNode A_0);

	private struct b
	{
		public int a;

		public FILETIME b;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	private struct c
	{
		public b a;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string b;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string c;

		public d d;

		public uint e;

		public uint f;

		[MarshalAs(UnmanagedType.Bool)]
		public bool g;
	}

	private enum d
	{
		a = 0,
		b = 1,
		c = 2,
		d = 3,
		e = 4,
		f = 5,
		g = 1000
	}

	private const int m_a = 0;

	private const int m_b = 255;

	private const int m_c = 63;

	[DllImport("rstrtmgr.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int RmRegisterResources(uint A_0, uint A_1, string[] A_2, uint A_3, [In] b[] A_4, uint A_5, string[] A_6);

	[DllImport("rstrtmgr.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int RmStartSession(out uint A_0, int A_1, string A_2);

	[DllImport("rstrtmgr.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int RmEndSession(uint A_0);

	[DllImport("rstrtmgr.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int RmGetList(uint A_0, out uint A_1, ref uint A_2, [In][Out] c[] A_3, ref uint A_4);

	public static List<Process> FindLockers(string filename)
	{
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		string a_ = Guid.NewGuid().ToString();
		int num = RmStartSession(out var A_, 0, a_);
		if (num != 0)
		{
			throw new Exception("Error " + num + " starting a Restart Manager session.");
		}
		List<Process> list = new List<Process>();
		try
		{
			uint A_2 = 0u;
			uint A_3 = 0u;
			uint A_4 = 0u;
			string[] array = new string[1] { filename };
			if (RmRegisterResources(A_, (uint)array.Length, array, 0u, null, 0u, null) != 0)
			{
				throw new Exception("Could not register resource.");
			}
			num = RmGetList(A_, out A_2, ref A_3, null, ref A_4);
			switch (num)
			{
			case 234:
			{
				c[] array2 = new c[A_2];
				A_3 = A_2;
				num = RmGetList(A_, out A_2, ref A_3, array2, ref A_4);
				if (num != 0)
				{
					throw new Exception("Error " + num + " listing lock processes");
				}
				for (int i = 0; i < A_3; i++)
				{
					try
					{
						list.Add(Process.GetProcessById(array2[i].a.a));
					}
					catch (ArgumentException)
					{
					}
				}
				break;
			}
			default:
				throw new Exception("Error " + num + " getting the size of the result.");
			case 0:
				break;
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
		}
		finally
		{
			RmEndSession(A_);
		}
		return list;
	}
}
