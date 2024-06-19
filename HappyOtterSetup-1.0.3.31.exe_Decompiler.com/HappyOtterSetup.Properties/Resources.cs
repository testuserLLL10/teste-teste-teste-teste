using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace HappyOtterSetup.Properties;

[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
internal class Resources
{
	private static ResourceManager a;

	private static CultureInfo b;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (a == null)
			{
				a = new ResourceManager("HappyOtterSetup.Properties.Resources", typeof(Resources).Assembly);
			}
			return a;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return b;
		}
		set
		{
			b = value;
		}
	}

	internal static byte[] _models => (byte[])ResourceManager.GetObject("_models", b);

	internal static byte[] avc_sony => (byte[])ResourceManager.GetObject("avc_sony", b);

	internal static byte[] AvisynthRepository => (byte[])ResourceManager.GetObject("AvisynthRepository", b);

	internal static byte[] AVS_Scripts => (byte[])ResourceManager.GetObject("AVS_Scripts", b);

	internal static byte[] avs32plugins => (byte[])ResourceManager.GetObject("avs32plugins", b);

	internal static byte[] avs64plugins => (byte[])ResourceManager.GetObject("avs64plugins", b);

	internal static Bitmap check_16_16 => (Bitmap)ResourceManager.GetObject("check_16_16", b);

	internal static byte[] ColorThemes => (byte[])ResourceManager.GetObject("ColorThemes", b);

	internal static byte[] Deshaker31 => (byte[])ResourceManager.GetObject("Deshaker31", b);

	internal static byte[] Deshaker31_64 => (byte[])ResourceManager.GetObject("Deshaker31_64", b);

	internal static byte[] FrameServer64 => (byte[])ResourceManager.GetObject("FrameServer64", b);

	internal static byte[] fssetup_hos => (byte[])ResourceManager.GetObject("fssetup_hos", b);

	internal static Bitmap happyOtter => (Bitmap)ResourceManager.GetObject("happyOtter", b);

	internal static byte[] HappyOtterKeyboard => (byte[])ResourceManager.GetObject("HappyOtterKeyboard", b);

	internal static byte[] Licensing_Agreements => (byte[])ResourceManager.GetObject("Licensing_Agreements", b);

	internal static byte[] MPC_HC_2_1_4_x64 => (byte[])ResourceManager.GetObject("MPC_HC_2_1_4_x64", b);

	internal static byte[] MPC_HC_2_2_1_x64 => (byte[])ResourceManager.GetObject("MPC_HC_2_2_1_x64", b);

	internal static Bitmap otter_24px_silver => (Bitmap)ResourceManager.GetObject("otter_24px_silver", b);

	internal static Bitmap otter_24x24 => (Bitmap)ResourceManager.GetObject("otter_24x24", b);

	internal static string ShaderPresets => ResourceManager.GetString("ShaderPresets", b);

	internal static byte[] Tools => (byte[])ResourceManager.GetObject("Tools", b);

	internal static byte[] TreeksLicensingLibrary => (byte[])ResourceManager.GetObject("TreeksLicensingLibrary", b);

	internal static byte[] UtVideoSilent => (byte[])ResourceManager.GetObject("UtVideoSilent", b);

	internal static byte[] V12DLLs => (byte[])ResourceManager.GetObject("V12DLLs", b);

	internal static byte[] V13_Extensions => (byte[])ResourceManager.GetObject("V13_Extensions", b);

	internal static byte[] V13_Scripts => (byte[])ResourceManager.GetObject("V13_Scripts", b);

	internal static byte[] V14_Extensions => (byte[])ResourceManager.GetObject("V14_Extensions", b);

	internal static byte[] V14_Scripts => (byte[])ResourceManager.GetObject("V14_Scripts", b);

	internal static byte[] VC_redist_x64 => (byte[])ResourceManager.GetObject("VC_redist_x64", b);

	internal static byte[] VC_redist_x86 => (byte[])ResourceManager.GetObject("VC_redist_x86", b);

	internal static byte[] Vdub_Settings => (byte[])ResourceManager.GetObject("Vdub_Settings", b);

	internal static byte[] VirtualDub_RenderSettings => (byte[])ResourceManager.GetObject("VirtualDub_RenderSettings", b);

	internal static byte[] VirtualDub2 => (byte[])ResourceManager.GetObject("VirtualDub2", b);

	internal static string VS2017Version => ResourceManager.GetString("VS2017Version", b);

	internal Resources()
	{
	}
}
