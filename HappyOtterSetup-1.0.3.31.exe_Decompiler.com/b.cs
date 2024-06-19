using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

[CompilerGenerated]
internal static class b
{
	private static object m_a = new object();

	private static Dictionary<string, bool> m_b = new Dictionary<string, bool>();

	private static Dictionary<string, string> c = new Dictionary<string, string>();

	private static Dictionary<string, string> d = new Dictionary<string, string>();

	private static int e;

	private static string a(CultureInfo A_0)
	{
		if (A_0 == null)
		{
			return "";
		}
		return A_0.Name;
	}

	private static Assembly a(AssemblyName A_0)
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			AssemblyName name = assembly.GetName();
			if (string.Equals(name.Name, A_0.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(a(name.CultureInfo), a(A_0.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
			{
				return assembly;
			}
		}
		return null;
	}

	private static void a(Stream A_0, Stream A_1)
	{
		byte[] array = new byte[81920];
		int count;
		while ((count = A_0.Read(array, 0, array.Length)) != 0)
		{
			A_1.Write(array, 0, count);
		}
	}

	private static Stream a(string A_0)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		if (A_0.EndsWith(".compressed"))
		{
			using (Stream stream = executingAssembly.GetManifestResourceStream(A_0))
			{
				using DeflateStream a_ = new DeflateStream(stream, CompressionMode.Decompress);
				MemoryStream memoryStream = new MemoryStream();
				a(a_, memoryStream);
				memoryStream.Position = 0L;
				return memoryStream;
			}
		}
		return executingAssembly.GetManifestResourceStream(A_0);
	}

	private static Stream a(Dictionary<string, string> A_0, string A_1)
	{
		if (A_0.TryGetValue(A_1, out var value))
		{
			return a(value);
		}
		return null;
	}

	private static byte[] a(Stream A_0)
	{
		byte[] array = new byte[A_0.Length];
		A_0.Read(array, 0, array.Length);
		return array;
	}

	private static Assembly a(Dictionary<string, string> A_0, Dictionary<string, string> A_1, AssemblyName A_2)
	{
		string text = A_2.Name.ToLowerInvariant();
		if (A_2.CultureInfo != null && !string.IsNullOrEmpty(A_2.CultureInfo.Name))
		{
			text = A_2.CultureInfo.Name + "." + text;
		}
		byte[] rawAssembly;
		using (Stream stream = a(A_0, text))
		{
			if (stream == null)
			{
				return null;
			}
			rawAssembly = a(stream);
		}
		using (Stream stream2 = a(A_1, text))
		{
			if (stream2 != null)
			{
				byte[] rawSymbolStore = a(stream2);
				return Assembly.Load(rawAssembly, rawSymbolStore);
			}
		}
		return Assembly.Load(rawAssembly);
	}

	public static Assembly a(object A_0, ResolveEventArgs A_1)
	{
		lock (global::b.m_a)
		{
			if (m_b.ContainsKey(A_1.Name))
			{
				return null;
			}
		}
		AssemblyName assemblyName = new AssemblyName(A_1.Name);
		Assembly assembly = a(assemblyName);
		if (assembly != null)
		{
			return assembly;
		}
		assembly = a(c, d, assemblyName);
		if (assembly == null)
		{
			lock (global::b.m_a)
			{
				m_b[A_1.Name] = true;
			}
			if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != 0)
			{
				assembly = Assembly.Load(assemblyName);
			}
		}
		return assembly;
	}

	static b()
	{
		c.Add("costura", "costura.costura.dll.compressed");
		c.Add("windowsfirewallhelper", "costura.windowsfirewallhelper.dll.compressed");
	}

	public static void a()
	{
		if (Interlocked.Exchange(ref e, 1) == 1)
		{
			return;
		}
		AppDomain.CurrentDomain.AssemblyResolve += delegate(object A_0, ResolveEventArgs A_1)
		{
			lock (global::b.m_a)
			{
				if (m_b.ContainsKey(A_1.Name))
				{
					return (Assembly)null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(A_1.Name);
			Assembly assembly = a(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = a(c, d, assemblyName);
			if (assembly == null)
			{
				lock (global::b.m_a)
				{
					m_b[A_1.Name] = true;
				}
				if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != 0)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		};
	}
}
