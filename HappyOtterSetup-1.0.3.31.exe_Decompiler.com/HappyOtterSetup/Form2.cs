using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;
using HappyOtterSetup.Properties;
using Microsoft.Win32;
using WindowsFirewallHelper;

namespace HappyOtterSetup;

public class Form2 : Form
{
	public const int WM_NCLBUTTONDOWN = 161;

	public const int HT_CAPTION = 2;

	public static string sysDir = Path.GetPathRoot(Environment.SystemDirectory);

	public static string toolsDir = sysDir + "Program Files\\HappyOtterScripts";

	public static string userDir = sysDir + "ProgramData\\HappyOtterScripts";

	public static string sonyScriptsDir = "";

	public static string magixScriptsDir = "";

	public static string sonyDir = "";

	public static string magixDir = "";

	public static string tempDir = "";

	public static string tempExeDir = "";

	public static string avsReposDir = "";

	public static string mpcDir = "";

	public static string avsDir = "";

	public static string vdubDir = "";

	public static string vdubRenderDir = "";

	public static string scriptMenuFolder = "Script Menu\\Happy Otter Scripts";

	public static List<string> installDirs = new List<string>();

	public static List<string> allVersions = new List<string>();

	public static List<string> sonyVersions = new List<string> { "12.0", "13.0" };

	public static List<string> magixVersions = new List<string> { "14.0", "15.0", "16.0", "17.0", "18.0", "19.0", "20.0", "21.0", "22.0" };

	public const string SYSTEM_RESTORE = "SystemRestore";

	public const string CREATE_SYSTEM_RESTORE_POINT = "CreateRestorePoint";

	public const string SYSTEM_RESTORE_POINT_DESCRIPTION = "HappyOtter Script Install";

	public const string SYSTEM_RESTORE_POINT_TYPE = "RestorePointType";

	public const string SYSTEM_RESTORE_EVENTTYPE = "EventType";

	public static bool restorePointCompleted = false;

	public static bool installSony = false;

	public static bool installMagix = false;

	public static bool hasSony = false;

	public static bool hasMagix = false;

	public static bool hasV12 = false;

	public static bool hasV19 = false;

	public static string fail = "FAILED-";

	public static string ok = "SUCCESS-";

	public static bool installOK = true;

	public static string quote = "\"";

	public static bool avsInstalled = false;

	public static bool keepSettings = false;

	public static bool installShortcuts = false;

	public static bool magicYUVInstalled;

	public static bool installRedist64 = false;

	public static bool installRedist86 = false;

	public static string aacOffset = "0444";

	public static string hoVersion = "";

	public static bool isElevated;

	public static bool reStartAdmin = false;

	public static string licenseId;

	public static string myDocDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

	public static string hoDocDir = myDocDir + "\\HappyOtterScripts";

	public static string dashLine = "-----------------------------------------------------------------------------------------------------------------------------";

	public static bool securityException = false;

	public Version newVersion;

	private CultureInfo m_a = CultureInfo.InvariantCulture;

	public bool prevVersionInstalled;

	public bool trialCCFS;

	private IContainer m_b;

	private Button m_c;

	private Button m_d;

	private Label m_e;

	private PictureBox m_f;

	private Button m_g;

	private GroupBox m_h;

	private Label m_i;

	private Label m_j;

	private CheckBox m_k;

	private GroupBox m_l;

	private CheckBox m_m;

	private CheckBox m_n;

	private Label m_o;

	private Label m_p;

	private Label m_q;

	private Label m_r;

	private Label m_s;

	private Label m_t;

	private PictureBox m_u;

	private PictureBox v;

	private PictureBox w;

	private PictureBox x;

	private PictureBox y;

	private PictureBox z;

	private Label aa;

	private Label ab;

	private Label ac;

	private Label ad;

	private CheckBox ae;

	private CheckBox af;

	private CheckBox ag;

	public Form2()
	{
		a();
	}

	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	private void g(object A_0, EventArgs A_1)
	{
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Invalid comparison between Unknown and I4
		//IL_062b: Unknown result type (might be due to invalid IL or missing references)
		//IL_062e: Invalid comparison between Unknown and I4
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Invalid comparison between Unknown and I4
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Invalid comparison between Unknown and I4
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Invalid comparison between Unknown and I4
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Invalid comparison between Unknown and I4
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Invalid comparison between Unknown and I4
		//IL_046d: Invalid comparison between Unknown and I4
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		hoVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
		b("START" + dashLine);
		b("HappyOtterScripts Setup - Version - " + hoVersion);
		b("System Directory: " + sysDir);
		killProcess("fs2enc");
		killProcess("fs2vdub");
		killProcess("avi2enc");
		b("Processes killed if open");
		using (WindowsIdentity ntIdentity = WindowsIdentity.GetCurrent())
		{
			isElevated = new WindowsPrincipal(ntIdentity).IsInRole(WindowsBuiltInRole.Administrator);
		}
		b("Run as Administrator-" + isElevated);
		((Form)this).StartPosition = (FormStartPosition)0;
		a((Form)(object)this);
		Shortcut.loadColors((Form)(object)this);
		b("Colors loaded");
		((Control)z).Visible = false;
		((Control)y).Visible = false;
		((Control)x).Visible = false;
		((Control)w).Visible = false;
		((Control)v).Visible = false;
		((Control)this.m_u).Visible = false;
		b("Picture boxes invisible");
		bool flag = false;
		for (int i = 12; i <= 22; i++)
		{
			if (Process.GetProcessesByName("vegas" + i + "0").Length != 0)
			{
				flag = true;
			}
		}
		if (flag)
		{
			MessageBox.Show("You must first close all instances of Vegas before installing Happy Otter Scripts!", "Stop", (MessageBoxButtons)0, (MessageBoxIcon)16);
			Application.Exit();
		}
		for (int j = 12; j <= 22; j++)
		{
			allVersions.Add(j + ".0");
			string version = "vegas" + j + "0.exe";
			string vegasPath = GetVegasPath(version);
			if (!string.IsNullOrWhiteSpace(vegasPath))
			{
				installDirs.Add(vegasPath);
				b("Version " + j + " Installed--Found in Registry " + vegasPath);
				if (j == 12)
				{
					hasV12 = true;
				}
				if (j <= 13)
				{
					hasSony = true;
				}
				if (j >= 14)
				{
					hasMagix = true;
				}
				if (j >= 19)
				{
					hasV19 = true;
				}
				continue;
			}
			string text = "C:\\Program Files\\VEGAS\\VEGAS Pro " + j + ".0";
			if (j == 12 || j == 13)
			{
				text = "C:\\Program Files\\Sony\\VEGAS Pro " + j + ".0";
			}
			if (Directory.Exists(text))
			{
				installDirs.Add(text + "\\");
				b("Version " + j + " Installed--From Search " + vegasPath);
				if (j == 12)
				{
					hasV12 = true;
				}
				if (j <= 13)
				{
					hasSony = true;
				}
				if (j >= 14)
				{
					hasMagix = true;
				}
				if (j >= 19)
				{
					hasV19 = true;
				}
			}
		}
		b("V12: " + hasV12 + "  hasSony: " + hasSony + "  hasMagix: " + hasMagix + "  V19 or later: " + hasV19);
		DialogResult val;
		DialogResult val2;
		if (installDirs.Count() == 0)
		{
			MessageBox.Show("No supported versions of Vegas Pro have been found!  Enter cancel to exit!", "Warning", (MessageBoxButtons)0, (MessageBoxIcon)16);
			if (Directory.Exists(userDir))
			{
				Directory.Delete(userDir, recursive: true);
			}
			if (Directory.Exists(toolsDir))
			{
				Directory.Delete(toolsDir, recursive: true);
			}
			((Control)this.m_d).Enabled = false;
			((Control)this.m_g).Enabled = false;
			b("No supported version of Vegas--Must Exit");
		}
		else
		{
			b();
			if (!reStartAdmin)
			{
				if (Directory.Exists(userDir))
				{
					prevVersionInstalled = true;
					b("Previous version found");
					val = MessageBox.Show("It would appear that there was a previous installation with saved settings.  Do you wish to keep those settings?  If not, they will be deleted and a clean update will be performed.  Click cancel to exit the installation.", "Attention", (MessageBoxButtons)3, (MessageBoxIcon)48);
					if ((int)val == 2)
					{
						c();
					}
					if ((int)val == 7)
					{
						val2 = MessageBox.Show("You have elected to do a clean update. The user settings folder and a few registry settings will be removed.  Would you prefer to do a clean install in which the previous version is completely removed from your computer?  ", "Attention", (MessageBoxButtons)3, (MessageBoxIcon)48);
						if ((int)val2 == 2)
						{
							c();
						}
						if ((int)val2 == 6)
						{
							DialogResult val3 = MessageBox.Show("Warning! You have chosen to completely remove HappyOtterScripts from your computer and perform a clean install.  All settings and programs will be removed.  Do you wish to continue?", "Stop", (MessageBoxButtons)3, (MessageBoxIcon)16);
							if ((int)val3 == 2)
							{
								c();
							}
							if ((int)val3 == 6)
							{
								b("Perform clean install selected.  Begin uninstall of previous version");
								try
								{
									b("UNINSTALL" + dashLine);
									Process? process = Process.Start(new ProcessStartInfo(Path.Combine(toolsDir, "HappyOtterUninstall.exe"))
									{
										WindowStyle = ProcessWindowStyle.Normal,
										UseShellExecute = false
									});
									((Form)this).WindowState = (FormWindowState)1;
									process.WaitForExit();
									MessageBox.Show("The previous version of HappyOtterScripts has been successfully removed.  Click OK to continue installation of the new version.", "Attention", (MessageBoxButtons)0, (MessageBoxIcon)64);
									((Form)this).WindowState = (FormWindowState)0;
									b("COMPLETED" + dashLine);
									b(ok + "Previous version removed.  Begin install.");
								}
								catch (Exception ex)
								{
									MessageBox.Show("The removal of the previous version failed.  It is recommended that you manually uninstall HappyOtterScripts through the Windows control panel and then perform a clean installation.", "Stop", (MessageBoxButtons)0, (MessageBoxIcon)16);
									b("Could not delete previous settings" + ex);
									b("Installation terminated");
									c();
									goto IL_0554;
								}
								goto IL_0652;
							}
						}
						goto IL_0554;
					}
					goto IL_062b;
				}
				goto IL_0641;
			}
			((Control)this.m_d).Enabled = false;
			((Control)this.m_g).Enabled = false;
		}
		goto IL_0ae3;
		IL_062b:
		if ((int)val == 6)
		{
			b("Keep previous settings--begin install");
			keepSettings = true;
		}
		goto IL_0641;
		IL_0ae3:
		b("Successfully completed form load");
		return;
		IL_0554:
		if ((int)val2 != 7)
		{
			goto IL_062b;
		}
		keepSettings = false;
		try
		{
			Directory.Delete(userDir, recursive: true);
			b("Deleted previous settings");
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\HappyOtterScripts");
			registryKey.SetValue("RenderID", "");
			registryKey.SetValue("RenderID2", "");
			registryKey.SetValue("RPExitCode", "");
			registryKey.SetValue("ExitCode", "");
			registryKey.SetValue("fs2encReady", 0, RegistryValueKind.DWord);
			b("Previous settings removed--begin install");
		}
		catch (Exception ex2)
		{
			MessageBox.Show("The previous settings directory and/or registry items could not be deleted.  It is recommended that you manually uninstall HappyOtterScripts through the Windows control panel and then perform a clean installation.", "Stop", (MessageBoxButtons)0, (MessageBoxIcon)16);
			b("Could not delete previous settings" + ex2);
			b("Installation terminated");
			c();
			goto IL_062b;
		}
		goto IL_0652;
		IL_0652:
		try
		{
			Directory.CreateDirectory(userDir);
			Directory.CreateDirectory(toolsDir);
			b(ok + "User directory created: " + userDir);
			b(ok + "Tool directory created: " + toolsDir);
		}
		catch (Exception ex3)
		{
			b(fail + "User/tool directories created");
			b("ERROR-" + ex3);
			installOK = false;
		}
		try
		{
			tempDir = userDir + "\\Temp";
			Directory.CreateDirectory(tempDir);
			tempExeDir = userDir + "\\TempExe";
			Directory.CreateDirectory(tempExeDir);
			b(ok + "Temp install directoreis created");
		}
		catch (Exception ex4)
		{
			b(fail + "Temp install directoreis created");
			b("ERROR-" + ex4);
			installOK = false;
			a(ex4.Message);
		}
		try
		{
			avsReposDir = toolsDir + "\\AvisynthRepository";
			if (Directory.Exists(avsReposDir))
			{
				avsInstalled = true;
			}
			b(ok + "Avisynth installed-" + avsInstalled);
		}
		catch (Exception ex5)
		{
			b(fail + "Avisynth installed-" + avsInstalled);
			b("ERROR-" + ex5);
			installOK = false;
		}
		try
		{
			SetFolderPermission(userDir);
			b(ok + "folder permission set");
		}
		catch (Exception ex6)
		{
			b(fail + "folder permission set");
			b("ERROR-" + ex6);
			installOK = false;
			a(ex6.Message);
		}
		try
		{
			sonyDir = userDir + "\\Sony Vegas Pro";
			Directory.CreateDirectory(sonyDir);
			magixDir = userDir + "\\Magix Vegas Pro";
			Directory.CreateDirectory(magixDir);
			sonyScriptsDir = sonyDir + "\\Scripts";
			Directory.CreateDirectory(sonyScriptsDir);
			magixScriptsDir = magixDir + "\\Scripts";
			Directory.CreateDirectory(magixScriptsDir);
			avsDir = userDir + "\\AvisynthScripts";
			Directory.CreateDirectory(avsDir);
			vdubDir = userDir + "\\VirtualDub FilterSettings";
			Directory.CreateDirectory(vdubDir);
			vdubRenderDir = userDir + "\\VirtualDub RenderSettings";
			Directory.CreateDirectory(vdubRenderDir);
			b(ok + "Additional directories created");
		}
		catch (Exception ex7)
		{
			b(fail + "Additional directories created");
			b("ERROR-" + ex7);
			installOK = false;
			a(ex7.Message);
		}
		try
		{
			c(tempDir);
			c(tempExeDir);
			b(ok + "Temp Install Files Cleared");
		}
		catch (Exception ex8)
		{
			b(fail + "Temp Install Files Cleared");
			b("ERROR-" + ex8);
			installOK = false;
			a(ex8.Message);
		}
		try
		{
			if (hasSony)
			{
				this.m_n.Checked = true;
				b("Sony version to be installed");
			}
			else
			{
				this.m_n.Checked = false;
			}
			if (hasMagix)
			{
				this.m_m.Checked = true;
				b("Magix version to be installed");
			}
			else
			{
				this.m_m.Checked = false;
			}
			b(ok + "Versions to be installed checked");
		}
		catch (Exception ex9)
		{
			b(fail + "Versions to be installed checked");
			b("ERROR-" + ex9);
			installOK = false;
			a(ex9.Message);
		}
		goto IL_0ae3;
		IL_0641:
		installShortcuts = ae.Checked;
		goto IL_0652;
	}

	private void f(object A_0, EventArgs A_1)
	{
		c();
	}

	private void e(object A_0, EventArgs A_1)
	{
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\HappyOtterScripts");
		if (registryKey.GetValue("UserCode") == null)
		{
			registryKey.SetValue("UserCode", "");
		}
		licenseId = registryKey.GetValue("UserCode").ToString();
		if (registryKey.GetValue("UserName") == null)
		{
			registryKey.SetValue("UserName", "");
		}
		if (registryKey.GetValue("EndDate") == null)
		{
			registryKey.SetValue("EndDate", "");
		}
		if (registryKey.GetValue("DateWord") == null)
		{
			registryKey.SetValue("DateWord", "");
		}
		if (registryKey.GetValue("strIV") == null)
		{
			registryKey.SetValue("strIV", "");
		}
		if (registryKey.GetValue("strSalt") == null)
		{
			registryKey.SetValue("strSalt", "");
		}
		if (registryKey.GetValue("fs2encReady") == null)
		{
			registryKey.SetValue("fs2encReady", 0, RegistryValueKind.DWord);
		}
		registryKey.SetValue("PreviewIdx", "0");
		((Control)this.m_d).Enabled = false;
		((Control)this.m_g).Enabled = false;
		((Control)this.m_c).Enabled = false;
		if (this.m_m.Checked)
		{
			installMagix = true;
		}
		if (this.m_n.Checked)
		{
			installSony = true;
		}
		if (this.m_k.Checked)
		{
			Cursor.Current = Cursors.WaitCursor;
			newRestorePoint();
			Cursor.Current = Cursors.Arrow;
			b("Restore Point Created");
		}
		if (!avsInstalled)
		{
			s();
		}
		else
		{
			updateAvisynth();
		}
		((Control)z).Visible = true;
		((Control)z).Refresh();
		e();
		d();
		t();
		i();
		((Control)x).Visible = true;
		((Control)x).Refresh();
		n();
		((Control)w).Visible = true;
		((Control)w).Refresh();
		q();
		((Control)v).Visible = true;
		((Control)v).Refresh();
		l();
		k();
		j();
		if (installShortcuts)
		{
			h();
		}
		((Control)this.m_u).Visible = true;
		((Control)this.m_u).Refresh();
		r();
		RegisterControlPanelProgram();
		string value = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", string.Empty).ToString();
		registryKey.SetValue("aacOffset", aacOffset);
		if (registryKey.GetValue("AlertsOK") == null)
		{
			registryKey.SetValue("AlertsOK", "True");
		}
		if (registryKey.GetValue("AlertLastDate") == null)
		{
			registryKey.SetValue("AlertLastDate", "01/01/2019");
		}
		if (registryKey.GetValue("AlertLastChecked") == null)
		{
			registryKey.SetValue("AlertLastChecked", "01/01/2019");
		}
		if (registryKey.GetValue("AlertLastDownload") == null)
		{
			registryKey.SetValue("AlertLastDownload", "01/01/2019");
		}
		if (registryKey.GetValue("Memory") == null)
		{
			registryKey.SetValue("Memory", "1024");
		}
		if (registryKey.GetValue("Threads") == null)
		{
			registryKey.SetValue("Threads", "4");
		}
		registryKey.SetValue("Version", hoVersion);
		registryKey.SetValue("NewVersion", hoVersion);
		DateTime now = DateTime.Now;
		registryKey.SetValue("LastCheckDate", now.ToString("d", this.m_a));
		registryKey.SetValue("InstallDate", now.ToString("d", this.m_a));
		registryKey.SetValue("PrevIdx", now.ToString("d", this.m_a));
		registryKey.SetValue("Dpi", "96");
		if (registryKey.GetValue("UpdateCheck") == null)
		{
			registryKey.SetValue("UpdateCheck", "Daily");
		}
		if (registryKey.GetValue("DownloadFolder") == null)
		{
			registryKey.SetValue("DownloadFolder", value);
		}
		if (registryKey.GetValue("RenderID") == null)
		{
			registryKey.SetValue("RenderID", "");
		}
		if (registryKey.GetValue("RenderID2") == null)
		{
			registryKey.SetValue("RenderID2", "");
		}
		if (registryKey.GetValue("ExitCode") == null)
		{
			registryKey.SetValue("ExitCode", "");
		}
		if (registryKey.GetValue("RPExitCode") == null)
		{
			registryKey.SetValue("RPExitCode", "");
		}
		magicYUVInstalled = MagicYUVInstalled();
		if (!magicYUVInstalled)
		{
			MessageBox.Show("The lossless codec MagicYUV is not installed on your system.  While certain Happy Otter tools can render using MagicYUV, the resulting files cannot be imported into Vegas until the codec has been installed.  A freeware version is available at https://www.magicyuv.com/.", "Warning", (MessageBoxButtons)0, (MessageBoxIcon)48);
		}
		u();
		if (trialCCFS)
		{
			MessageBox.Show("A trial version of the new CuminCode FrameServer (CCFS) has been installed.  The older DebugMode FrameServer (DMFS) is now deprecated and no longer works with the latest builds of Vegas 19 and future Vegas versions. Frameserving is necessary to support such rendering tools as RenderPlus and KwikPreview. To continue using CCFS beyond the 30 day trial, you must purchase a CCFS license.  For those already having an HOS license, a discounted (40%) license may be purchased at \"https://tools4vegas.com/\" for $15 US.  For those purchasing a new HOS license, it will be included in the purchase price.  If you are using an older version of Vegas, you may continue using DMFS after the 30 day trial or at any time.  To do so, you must uninstall CuminCode.  You can find more information about additional capabilities of CCFS at the developer's website \"https://www.cumincode.com/frameserver/.\"", "Attention", (MessageBoxButtons)0, (MessageBoxIcon)48);
		}
		if (installOK)
		{
			MessageBox.Show("HappyOtterScripts Setup has been completed!", "Success", (MessageBoxButtons)0, (MessageBoxIcon)64);
		}
		else if (securityException)
		{
			MessageBox.Show("HappyOtterScripts installation failed because of an Unauthorized Access Violation.  In other words, your system prevented the necessary access to the folders required for proper installation.  Most likely this was due to the Virus protection software you are using.  It is suggested that you take the following actions:" + Environment.NewLine + "1. Uninstall HappyOtterScripts" + Environment.NewLine + "2. Temporarily disable or whitelist HappyOtterScripts in your Virus applicatin" + Environment.NewLine + "3. Re-install HappyOtterScripts using \"Run as Administrator\"", "Stop--Installation Failure", (MessageBoxButtons)0, (MessageBoxIcon)16);
		}
		else
		{
			MessageBox.Show("HappyOtterScripts Setup had some errors! Please send a copy of the HappyOtterInstall.log to HappyOtterScripts.  The file may be found in your documents folder.  You may view it with any text editor.", "Errors!", (MessageBoxButtons)0, (MessageBoxIcon)16);
		}
		if (Directory.Exists(tempDir))
		{
			Directory.Delete(tempDir, recursive: true);
		}
		if (Directory.Exists(tempExeDir))
		{
			Directory.Delete(tempExeDir, recursive: true);
		}
		b("HO Installation End");
		b("END" + dashLine);
		Application.Exit();
	}

	private void d(object A_0, EventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).Hide();
		((Form)new Form4()).ShowDialog();
		((Form)this).Close();
	}

	private void u()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		string text = Path.Combine(toolsDir, "GetVersion.exe");
		try
		{
			if (((IEnumerable<IRule>)FirewallManager.Instance.Rules).SingleOrDefault((Func<IRule, bool>)((IRule A_0) => A_0.Name == "HOS Crash Reporter")) == null)
			{
				IRule val = FirewallManager.Instance.CreateApplicationRule(FirewallManager.Instance.GetProfile().Type, "HOS Crash Reporter", (FirewallAction)1, text);
				val.Direction = (FirewallDirection)1;
				FirewallManager.Instance.Rules.Add(val);
				b("Firewall Rule added for Crash reporting");
			}
			else
			{
				b("Firewall Rule for Crash reporting already exists");
			}
		}
		catch (Exception ex)
		{
			b("Firewall Rule could not be added for Crash reporting.  Error: " + ex.Message);
		}
		try
		{
			if (((IEnumerable<IRule>)FirewallManager.Instance.Rules).SingleOrDefault((Func<IRule, bool>)((IRule A_0) => A_0.Name == "HOS Updater")) == null)
			{
				IRule val2 = FirewallManager.Instance.CreateApplicationRule(FirewallManager.Instance.GetProfile().Type, "HOS Updater", (FirewallAction)1, text);
				val2.Direction = (FirewallDirection)0;
				FirewallManager.Instance.Rules.Add(val2);
				b("Firewall Rule added for updating");
			}
			else
			{
				b("Firewall Rule for updating already exists");
			}
		}
		catch (Exception ex2)
		{
			b("Firewall Rule could not be added for updating.  Error: " + ex2.Message);
		}
	}

	private void t()
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		string text = Path.Combine(tempExeDir, "temp.exe");
		File.WriteAllBytes(text, Resources.HappyOtterKeyboard);
		ZipFile.ExtractToDirectory(text, tempDir);
		string text2 = Path.Combine(tempDir, "HappyOtterKeyboard.ini");
		List<string> list = new List<string>();
		using (StreamReader streamReader = new StreamReader(text2))
		{
			string text3 = "";
			bool flag = false;
			while ((text3 = streamReader.ReadLine()) != null)
			{
				if (flag)
				{
					list.Add(text3);
				}
				if (text3.Contains("Global"))
				{
					flag = true;
				}
			}
		}
		try
		{
			if (installMagix)
			{
				string a_ = folderPath + "\\VEGAS Pro";
				a(a_, list, text2);
			}
			b(ok + "Magix KeyboardIni Installed");
		}
		catch (Exception ex)
		{
			b(fail + "Magix KeyboardIni Installed");
			b("ERROR-" + ex);
			installOK = false;
		}
		try
		{
			if (installSony)
			{
				string a_2 = folderPath + "\\Sony\\Vegas Pro";
				a(a_2, list, text2);
			}
			b(ok + "Sony KeyboardIni Installed");
		}
		catch (Exception ex2)
		{
			b(fail + "Sony KeyboardIni Installed");
			b("ERROR-" + ex2);
			installOK = false;
		}
		c(tempDir);
		File.Delete(text);
	}

	private void a(string A_0, List<string> A_1, string A_2)
	{
		string[] directories = Directory.GetDirectories(A_0);
		foreach (string text in directories)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(text);
			if (A_0.Contains("Sony"))
			{
				if (!sonyVersions.Contains(directoryInfo.Name))
				{
					continue;
				}
			}
			else if (!magixVersions.Contains(directoryInfo.Name))
			{
				continue;
			}
			string text2 = Path.Combine(text, "HappyOtterKeyboard.ini");
			string path = Path.Combine(text, "HappyOtterLastKeyboard.ini");
			string path2 = Path.Combine(text, "HappyOtterKeyboardLast.ini");
			if (File.Exists(path))
			{
				try
				{
					File.Delete(path);
				}
				catch (Exception)
				{
				}
			}
			if (File.Exists(path2))
			{
				try
				{
					File.Delete(path2);
				}
				catch (Exception)
				{
				}
			}
			if (!File.Exists(text2))
			{
				File.Copy(A_2, text2);
			}
			else
			{
				a(text2, A_1);
			}
			string text3 = Path.Combine(text, "keyboard.ini");
			if (File.Exists(text3))
			{
				a(text3, A_1);
			}
			if (!ag.Checked)
			{
				continue;
			}
			string[] files = Directory.GetFiles(text, "*.ini");
			foreach (string text4 in files)
			{
				if (!Path.GetFileNameWithoutExtension(text4).Contains("HappyOtter") && !(text4 == text3))
				{
					a(text4, A_1);
				}
			}
		}
	}

	private void a(string A_0, List<string> A_1)
	{
		string[] source = new string[4] { "HOS", "Ctrl+1+1", "Ctrl+1+2", "Ctrl+Alt+Shift+H" };
		List<string> list = new List<string>();
		using (StreamReader streamReader = new StreamReader(A_0))
		{
			string text = "";
			while ((text = streamReader.ReadLine()) != null)
			{
				if (!source.Any(text.Contains))
				{
					list.Add(text);
				}
			}
			streamReader.Close();
		}
		list = list.Distinct().ToList();
		bool flag = true;
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].Contains("[Global]"))
			{
				flag = false;
				num = i;
			}
		}
		if (flag)
		{
			list.Add("[Global]");
			list.AddRange(A_1);
		}
		else
		{
			foreach (string item in A_1)
			{
				if (!list.Contains(item))
				{
					num++;
					list.Insert(num, item);
				}
			}
		}
		if (File.Exists(A_0))
		{
			File.Delete(A_0);
		}
		StreamWriter streamWriter = new StreamWriter(A_0);
		foreach (string item2 in list)
		{
			streamWriter.WriteLine(item2);
		}
		streamWriter.Close();
	}

	private void s()
	{
		try
		{
			string text = Path.Combine(tempExeDir, "temp.exe");
			File.WriteAllBytes(text, Resources.AvisynthRepository);
			ZipFile.ExtractToDirectory(text, avsReposDir);
			File.Delete(text);
			b(ok + "Avisynth Repository Installed");
		}
		catch (Exception ex)
		{
			b(fail + "Avisynth Repository Installed");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
		try
		{
			string text2 = quote + Path.Combine(avsReposDir, "setavs.bat") + quote;
			Process.Start(new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/c " + text2 + " AVSPLUS_X86",
				UseShellExecute = false,
				CreateNoWindow = false
			}).WaitForExit();
			b(ok + "Avisytn Plus 32 bit installed");
		}
		catch (Exception ex2)
		{
			b(fail + "Avisytn Plus 32 bit installed");
			b("ERROR-" + ex2);
			installOK = false;
			a(ex2.Message);
		}
		try
		{
			string text3 = quote + Path.Combine(avsReposDir, "setavs.bat") + quote;
			Process.Start(new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/c " + text3 + " AVSPLUS_X64",
				UseShellExecute = false,
				CreateNoWindow = false
			}).WaitForExit();
			b(ok + "Avisytn Plus 64 bit installed");
		}
		catch (Exception ex3)
		{
			b(fail + "Avisytn Plus 64 bit installed");
			b("ERROR-" + ex3);
			installOK = false;
			a(ex3.Message);
		}
	}

	public void updateAvisynth()
	{
		try
		{
			string[] files = Directory.GetFiles(avsReposDir, "*.dll", SearchOption.TopDirectoryOnly);
			if (files.Length == 0)
			{
				b(ok + "No previous avisynth files found");
			}
			else
			{
				for (int i = 0; i < files.Length; i++)
				{
					File.Delete(files[i]);
				}
				b(ok + files.Length + " previous avisynth files deleted");
			}
		}
		catch (Exception ex)
		{
			b(fail + "Previous avisynth files could not be deleted");
			b("ERROR-" + ex);
			installOK = false;
		}
		try
		{
			string text = Path.Combine(tempExeDir, "temp.exe");
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			File.WriteAllBytes(text, Resources.AvisynthRepository);
			ZipFile.ExtractToDirectory(text, tempDir);
			a(tempDir, "*.bat", avsReposDir, A_3: true);
			string[] directories = Directory.GetDirectories(tempDir);
			for (int j = 0; j < directories.Length; j++)
			{
				string a_ = directories[j].Replace(tempDir, avsReposDir);
				a(directories[j], "*.*", a_, A_3: true);
			}
			c(tempDir);
			File.Delete(text);
			b(ok + "Avisynth Repository Updated");
		}
		catch (Exception ex2)
		{
			b(fail + "Avisynth Repository Updated");
			b("ERROR-" + ex2);
			installOK = false;
			a(ex2.Message);
		}
		try
		{
			string a_2 = avsReposDir + "\\AVSPLUS_x86";
			string a_3 = sysDir + "Windows\\SysWOW64";
			string a_4 = avsReposDir + "\\AVSPLUS_x64";
			string a_5 = sysDir + "Windows\\System32";
			a(a_2, "*.dll", a_3, A_3: true);
			c(tempDir);
			a(a_4, "*.dll", a_5, A_3: true);
			c(tempDir);
			b(ok + "Avisynth Updated in Sys32 and Syswow64");
		}
		catch (Exception ex3)
		{
			b(fail + "Avisynth Updated in Sys32 and Syswow64");
			b("ERROR-" + ex3);
			installOK = false;
			a(ex3.Message);
		}
	}

	private void r()
	{
		try
		{
			string path = Path.Combine(tempExeDir, "temp.exe");
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			path = Path.Combine(tempExeDir, "TreeksLicensingLibrary.dll");
			File.WriteAllBytes(path, Resources.TreeksLicensingLibrary);
			foreach (string installDir in installDirs)
			{
				string text = Path.Combine(installDir, "TreeksLicensingLibrary.dll");
				if (!File.Exists(text))
				{
					File.Copy(path, text);
					b("Added: " + text);
				}
			}
			c(tempDir);
			b(ok + "Treeks Added/Updated");
		}
		catch (Exception ex)
		{
			b(fail + "Treeks Added/Updated");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	private void q()
	{
		try
		{
			string a_ = sysDir + "Windows\\SysWOW64";
			string a_2 = sysDir + "Windows\\System32";
			string text = Path.Combine(tempExeDir, "temp.exe");
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			File.WriteAllBytes(text, Resources.UtVideoSilent);
			ZipFile.ExtractToDirectory(text, tempDir);
			File.Delete(text);
			File.Copy(Path.Combine(tempDir, "utvideo_del.reg"), Path.Combine(toolsDir, "utvideo_del.reg"), overwrite: true);
			string a_3 = tempDir + "\\x86";
			a(a_3, "*.dll", a_, A_3: true);
			string a_4 = tempDir + "\\x64";
			a(a_4, "*.dll", a_2, A_3: true);
			string text2 = Path.Combine(tempDir, "utvideo.reg");
			text2 = quote + text2 + quote;
			Process.Start("regedit.exe", "/s " + text2).WaitForExit();
			c(tempDir);
			b(ok + "Utvideo Codec Installed");
		}
		catch (Exception ex)
		{
			b(fail + "Utvideo Codec Installed");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	private void p()
	{
		if (File.Exists("C:\\Program Files\\CuminCode\\FrameServer\\ccfsVegasOutV2.dll") && File.Exists("C:\\Program Files\\CuminCode\\FrameServer\\ccfsVegasOutV3.dll"))
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\CuminCode\\FrameServer");
			if (registryKey.GetValue("serveVirtualUncompressedAvi") == null)
			{
				registryKey.SetValue("serveVirtualUncompressedAvi", 0, RegistryValueKind.DWord);
			}
			if (registryKey.GetValue("isHOS") == null)
			{
				registryKey.SetValue("isHOS", "0", RegistryValueKind.DWord);
			}
			b(ok + "CuminCoder already installed");
			return;
		}
		if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\CuminCode\\FrameServer") != null && !hasV19)
		{
			b(ok + "Previous version of CCFS installed and removed");
			return;
		}
		try
		{
			string text = Path.Combine(tempExeDir, "fssetup_hos.exe");
			File.WriteAllBytes(text, Resources.fssetup_hos);
			Process.Start(new ProcessStartInfo(text)
			{
				Arguments = "/mode hos",
				WindowStyle = ProcessWindowStyle.Normal,
				UseShellExecute = false
			}).WaitForExit();
			b(ok + "CuminCoder Installed");
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\CuminCode");
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\CuminCode\\FrameServer");
			RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\CuminCode\\FrameServer");
			if (registryKey2.GetValue("licenseKey") == null)
			{
				registryKey2.SetValue("licenseKey", "");
			}
			if (registryKey2.GetValue("isTrialLicense") == null)
			{
				registryKey2.SetValue("isTrialLicense", 1, RegistryValueKind.DWord);
			}
			if (registryKey2.GetValue("serveVirtualUncompressedAvi") == null)
			{
				registryKey2.SetValue("serveVirtualUncompressedAvi", 0, RegistryValueKind.DWord);
			}
			if (registryKey2.GetValue("isHOS") == null)
			{
				registryKey2.SetValue("isHOS", "0", RegistryValueKind.DWord);
			}
			o();
		}
		catch (Exception ex)
		{
			b(fail + "CuminCoder Installed");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	private void o()
	{
		try
		{
			string text = string.Empty;
			using (HttpWebResponse httpWebResponse = (HttpWebResponse)((HttpWebRequest)WebRequest.Create("https://www.cumincode.com/getTrial?rv=1&an=fs&av=4.21&id=HOS")).GetResponse())
			{
				using Stream stream = httpWebResponse.GetResponseStream();
				using StreamReader streamReader = new StreamReader(stream);
				text = streamReader.ReadToEnd();
			}
			int num = text.IndexOf("lk=");
			text = text.Substring(num + 3).Replace("\n", "");
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\CuminCode\\FrameServer");
			registryKey.SetValue("licenseKey", text);
			registryKey.SetValue("isTrialLicense", "1", RegistryValueKind.DWord);
			registryKey.SetValue("trialDate", DateTime.Now.ToString("d", this.m_a));
			registryKey.SetValue("isHOS", "0", RegistryValueKind.DWord);
			trialCCFS = true;
			b(ok + "Trial License Activated");
		}
		catch (Exception ex)
		{
			b(fail + "Trial License Activated");
			b("ERROR-" + ex);
			installOK = false;
		}
	}

	private void n()
	{
		b("FrameServer Install Start");
		string text = "";
		string a_ = sysDir + "Windows\\SysWOW64";
		_ = sysDir + "Windows\\System32";
		string text2 = sysDir + "Program Files\\Debugmode\\FrameServer";
		b("FrameServer Folder: " + text2);
		string text3 = Path.Combine(tempExeDir, "fssetup_hos.exe");
		File.WriteAllBytes(text3, Resources.fssetup_hos);
		Process.Start(new ProcessStartInfo(text3)
		{
			Arguments = "/mode hos",
			WindowStyle = ProcessWindowStyle.Normal,
			UseShellExecute = false
		}).WaitForExit();
		b(ok + "DMFS Installed");
		if (hasV12)
		{
			text = "v12 dll's extracted";
			string text4 = text2 + "\\V12";
			try
			{
				Directory.CreateDirectory(text4);
				text3 = Path.Combine(tempExeDir, "temp.exe");
				if (File.Exists(text3))
				{
					File.Delete(text3);
				}
				File.WriteAllBytes(text3, Resources.V12DLLs);
				ZipFile.ExtractToDirectory(text3, text4);
				File.Delete(text3);
				b(ok + text);
			}
			catch (Exception ex)
			{
				b(fail + text);
				b("ERROR-" + ex);
				installOK = false;
			}
			b(Path.Combine(text4, "dfsc.dll"), a_);
			b(Path.Combine(text4, "dfscacm.dll"), a_);
			b(Path.Combine(text4, "dfscVegasV264Out.dll"), text2);
			File.Delete(Path.Combine(text4, "dfsc.dll"));
			File.Delete(Path.Combine(text4, "dfscacm.dll"));
			File.Delete(Path.Combine(text4, "dfscVegasV264Out.dll"));
			Directory.Delete(text4);
			string name = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows NT\\CurrentVersion\\Drivers32";
			RegistryKey? registryKey = Registry.LocalMachine.OpenSubKey(name, writable: true);
			registryKey.SetValue("vidc.dfsc", "dfsc.dll", RegistryValueKind.String);
			registryKey.SetValue("msacm.dfscacm", "dfscacm.dll", RegistryValueKind.String);
			name = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows NT\\CurrentVersion\\drivers.desc";
			RegistryKey? registryKey2 = Registry.LocalMachine.OpenSubKey(name, writable: true);
			registryKey2.SetValue("dfsc.dll", "DebugMode FSVFWC (internal use)", RegistryValueKind.String);
			registryKey2.SetValue("dfscacm.dll", "DebugMode FSACMC (internal use)", RegistryValueKind.String);
		}
		string text5 = Path.Combine(text2, "fs12");
		if (File.Exists(text5))
		{
			File.Delete(text5);
		}
		List<string> list = new List<string>();
		list.Add("[FileIO Plug-Ins]");
		list.Add("frameserver=" + sysDir + "Program Files\\Debugmode\\FrameServer\\dfscVegasV264Out.dll");
		using (StreamWriter streamWriter = new StreamWriter(text5))
		{
			foreach (string item in list)
			{
				streamWriter.WriteLine(item);
			}
		}
		b("V12 Config file written");
		string text6 = Path.Combine(text2, "fs13");
		if (File.Exists(text6))
		{
			File.Delete(text6);
		}
		List<string> list2 = new List<string>();
		list2.Add("[FileIO Plug-Ins]");
		list2.Add("frameserver=" + sysDir + "Program Files\\Debugmode\\FrameServer\\dfscVegasOutV2.dll");
		using (StreamWriter streamWriter2 = new StreamWriter(text6))
		{
			foreach (string item2 in list2)
			{
				streamWriter2.WriteLine(item2);
			}
		}
		b("V13+ Config file written");
		string text7 = Path.Combine(text2, "fs18");
		if (File.Exists(text7))
		{
			File.Delete(text7);
		}
		List<string> list3 = new List<string>();
		list3.Add("[FileIO Plug-Ins]");
		list3.Add("frameserver=" + sysDir + "Program Files\\Debugmode\\FrameServer\\dfscVegasOutV3.dll");
		using (StreamWriter streamWriter3 = new StreamWriter(text7))
		{
			foreach (string item3 in list3)
			{
				streamWriter3.WriteLine(item3);
			}
		}
		b("V18 Config file written");
		text = "Config files added to vegas directories";
		try
		{
			foreach (string installDir in installDirs)
			{
				if (installDir.Contains("12"))
				{
					File.Copy(text5, Path.Combine(installDir, "Frameserver.x64.fio2007-config"), overwrite: true);
				}
				else if (installDir.Contains("18") || installDir.Contains("19") || installDir.Contains("20") || installDir.Contains("21") || installDir.Contains("22"))
				{
					File.Copy(text7, Path.Combine(installDir, "Frameserver.x64.fio2007-config"), overwrite: true);
				}
				else
				{
					File.Copy(text6, Path.Combine(installDir, "Frameserver.x64.fio2007-config"), overwrite: true);
				}
			}
			b(ok + text);
		}
		catch (Exception ex2)
		{
			b(fail + text);
			b("ERROR-" + ex2);
			installOK = false;
		}
		text = "Config files deleted";
		try
		{
			File.Delete(Path.Combine(text2, "fs12"));
			File.Delete(Path.Combine(text2, "fs13"));
			File.Delete(Path.Combine(text2, "fs18"));
			b(ok + text);
		}
		catch (Exception ex3)
		{
			b(fail + text);
			b("ERROR-" + ex3);
			installOK = false;
		}
	}

	private void m()
	{
		//IL_0da8: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			b("FrameServer Install Start");
			string text = "";
			string a_ = sysDir + "Windows\\SysWOW64";
			string a_2 = sysDir + "Windows\\System32";
			string text2 = sysDir + "Program Files\\Debugmode\\FrameServer";
			b("FrameServer Folder: " + text2);
			if (Directory.Exists(text2))
			{
				try
				{
					Directory.Delete(text2, recursive: true);
					b("Existing FrameServer directory deleted");
				}
				catch (Exception ex)
				{
					b("Exception: Could not delete FrameServer Directory: " + ex.Message);
					installOK = false;
					a(ex.Message);
				}
			}
			Directory.CreateDirectory(text2);
			string text3 = Path.Combine(text2, "fs12");
			if (File.Exists(text3))
			{
				File.Delete(text3);
			}
			List<string> obj = new List<string>
			{
				"[FileIO Plug-Ins]",
				"frameserver=" + sysDir + "Program Files\\Debugmode\\FrameServer\\dfscVegasV264Out.dll"
			};
			StreamWriter streamWriter = new StreamWriter(text3);
			foreach (string item in obj)
			{
				streamWriter.WriteLine(item);
			}
			streamWriter.Close();
			b("V12 Config file written");
			string text4 = Path.Combine(text2, "fs13");
			if (File.Exists(text4))
			{
				File.Delete(text4);
			}
			List<string> obj2 = new List<string>
			{
				"[FileIO Plug-Ins]",
				"frameserver=" + sysDir + "Program Files\\Debugmode\\FrameServer\\dfscVegasOutV2.dll"
			};
			streamWriter = new StreamWriter(text4);
			foreach (string item2 in obj2)
			{
				streamWriter.WriteLine(item2);
			}
			streamWriter.Close();
			b("V13+ Config file written");
			string text5 = Path.Combine(text2, "fs18");
			if (File.Exists(text5))
			{
				File.Delete(text5);
			}
			List<string> obj3 = new List<string>
			{
				"[FileIO Plug-Ins]",
				"frameserver=" + sysDir + "Program Files\\Debugmode\\FrameServer\\dfscVegasOutV3.dll"
			};
			streamWriter = new StreamWriter(text5);
			foreach (string item3 in obj3)
			{
				streamWriter.WriteLine(item3);
			}
			streamWriter.Close();
			b("V18 Config file written");
			text = "Config files added to vegas directories";
			try
			{
				foreach (string installDir in installDirs)
				{
					if (installDir.Contains("12"))
					{
						File.Copy(text3, Path.Combine(installDir, "Frameserver.x64.fio2007-config"), overwrite: true);
					}
					else if (installDir.Contains("18") || installDir.Contains("19") || installDir.Contains("20") || installDir.Contains("21") || installDir.Contains("22"))
					{
						File.Copy(text5, Path.Combine(installDir, "Frameserver.x64.fio2007-config"), overwrite: true);
					}
					else
					{
						File.Copy(text4, Path.Combine(installDir, "Frameserver.x64.fio2007-config"), overwrite: true);
					}
				}
				b(ok + text);
			}
			catch (Exception ex2)
			{
				b(fail + text);
				b("ERROR-" + ex2);
				installOK = false;
			}
			text = "Config files deleted";
			try
			{
				File.Delete(Path.Combine(text2, "fs12"));
				File.Delete(Path.Combine(text2, "fs13"));
				File.Delete(Path.Combine(text2, "fs18"));
				b(ok + text);
			}
			catch (Exception ex3)
			{
				b(fail + text);
				b("ERROR-" + ex3);
				installOK = false;
			}
			if (File.Exists("C:\\Program Files\\CuminCode\\FrameServer\\ccfsVegasOutV2.dll") || File.Exists("C:\\Program Files\\CuminCode\\FrameServer\\ccfsVegasOutV3.dll"))
			{
				text4 = Path.Combine(text2, "fs13");
				if (File.Exists(text4))
				{
					File.Delete(text4);
				}
				List<string> obj4 = new List<string>
				{
					"[FileIO Plug-Ins]",
					"ccframeserver=" + sysDir + "Program Files\\CuminCode\\FrameServer\\ccfsVegasOutV2.dll"
				};
				streamWriter = new StreamWriter(text4);
				foreach (string item4 in obj4)
				{
					streamWriter.WriteLine(item4);
				}
				streamWriter.Close();
				b("CC V13+ Config file written");
				text5 = Path.Combine(text2, "fs18");
				if (File.Exists(text5))
				{
					File.Delete(text5);
				}
				List<string> obj5 = new List<string>
				{
					"[FileIO Plug-Ins]",
					"ccframeserver=" + sysDir + "Program Files\\CuminCode\\FrameServer\\ccfsVegasOutV3.dll"
				};
				streamWriter = new StreamWriter(text5);
				foreach (string item5 in obj5)
				{
					streamWriter.WriteLine(item5);
				}
				streamWriter.Close();
				b("CC V18 Config file written");
				text = "CC Config files added to vegas directories";
				try
				{
					foreach (string installDir2 in installDirs)
					{
						if (!installDir2.Contains("12"))
						{
							if (installDir2.Contains("18") || installDir2.Contains("19") || installDir2.Contains("20") || installDir2.Contains("21") || installDir2.Contains("22"))
							{
								File.Copy(text5, Path.Combine(installDir2, "CCFrameserver.x64.fio2007-config"), overwrite: true);
							}
							else
							{
								File.Copy(text4, Path.Combine(installDir2, "CCFrameserver.x64.fio2007-config"), overwrite: true);
							}
						}
					}
					b(ok + text);
				}
				catch (Exception ex4)
				{
					b(fail + text);
					b("ERROR-" + ex4);
					installOK = false;
				}
				text = "CC Config files deleted";
				try
				{
					File.Delete(Path.Combine(text2, "fs12"));
					File.Delete(Path.Combine(text2, "fs13"));
					File.Delete(Path.Combine(text2, "fs18"));
					b(ok + text);
				}
				catch (Exception ex5)
				{
					b(fail + text);
					b("ERROR-" + ex5);
					installOK = false;
				}
			}
			string text6 = "";
			text = "FS directory location written to registry";
			try
			{
				text6 = "DebugMode\\FrameServer";
				string value = sysDir + "Program Files\\Debugmode\\FrameServer";
				string name = "SOFTWARE";
				Registry.LocalMachine.OpenSubKey(name, writable: true).CreateSubKey(text6).SetValue("InstallDir", value, RegistryValueKind.String);
				string name2 = "SOFTWARE\\WOW6432Node";
				Registry.LocalMachine.OpenSubKey(name2, writable: true).CreateSubKey(text6).SetValue("InstallDir", value, RegistryValueKind.String);
				b(ok + text);
			}
			catch (Exception ex6)
			{
				b(fail + text);
				b("ERROR-" + ex6);
				installOK = false;
			}
			text = "Default fs values written to user registry";
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\DebugMode\\FrameServer");
				registryKey.SetValue("serveFormat", "0", RegistryValueKind.DWord);
				registryKey.SetValue("pcmAudioInAvi", "0", RegistryValueKind.DWord);
				registryKey.SetValue("saveAsImageSequence", "0", RegistryValueKind.DWord);
				b(ok + text);
			}
			catch (Exception ex7)
			{
				b(fail + text);
				b("ERROR-" + ex7);
				installOK = false;
			}
			text = "fs dll's extracted";
			try
			{
				string text7 = Path.Combine(tempExeDir, "temp.exe");
				if (File.Exists(text7))
				{
					File.Delete(text7);
				}
				File.WriteAllBytes(text7, Resources.FrameServer64);
				ZipFile.ExtractToDirectory(text7, text2);
				File.Delete(text7);
				b(ok + text);
			}
			catch (Exception ex8)
			{
				b(fail + text);
				b("ERROR-" + ex8);
				installOK = false;
			}
			string text8 = text2 + "\\x64";
			text = "64bit dll's added to system32";
			try
			{
				b(Path.Combine(text8, "dfsc.dll"), a_2);
				b(Path.Combine(text8, "dfscacm.dll"), a_2);
				b(ok + text);
			}
			catch (Exception ex9)
			{
				b(fail + text);
				b("ERROR-" + ex9);
				installOK = false;
			}
			string text9 = text2 + "\\x86";
			text = "32bit dll's added to syswow64";
			try
			{
				b(Path.Combine(text9, "dfsc32.dll"), a_);
				b(Path.Combine(text9, "dfscacm32.dll"), a_);
				if (hasV12)
				{
					b(Path.Combine(text9, "dfsc.dll"), a_);
					b(Path.Combine(text9, "dfscacm.dll"), a_);
				}
				b(ok + text);
			}
			catch (Exception ex10)
			{
				b(fail + text);
				b("ERROR-" + ex10);
				installOK = false;
			}
			text = "Temp x64 x86 directories deleted";
			try
			{
				Directory.Delete(text9, recursive: true);
				Directory.Delete(text8, recursive: true);
				b(ok + text);
			}
			catch (Exception ex11)
			{
				b(fail + text);
				b("ERROR-" + ex11);
				installOK = false;
			}
			RegistryKey registryKey2 = null;
			string text10 = "";
			string text11 = "";
			text = "64bit codecs registered";
			try
			{
				text10 = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Drivers32";
				registryKey2 = Registry.LocalMachine.OpenSubKey(text10, writable: true);
				registryKey2.SetValue("vidc.dfsc", "dfsc.dll", RegistryValueKind.String);
				registryKey2.SetValue("msacm.dfscacm", "dfscacm.dll", RegistryValueKind.String);
				b(ok + text);
			}
			catch (Exception ex12)
			{
				b(fail + text);
				b("ERROR-" + ex12);
				installOK = false;
			}
			text = "32bit codecs registered";
			try
			{
				text11 = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows NT\\CurrentVersion\\Drivers32";
				registryKey2 = Registry.LocalMachine.OpenSubKey(text11, writable: true);
				if (hasV12)
				{
					registryKey2.SetValue("vidc.dfsc", "dfsc.dll", RegistryValueKind.String);
					registryKey2.SetValue("msacm.dfscacm", "dfscacm.dll", RegistryValueKind.String);
				}
				else
				{
					registryKey2.SetValue("vidc.dfsc", "dfsc32.dll", RegistryValueKind.String);
					registryKey2.SetValue("msacm.dfscacm", "dfscacm32.dll", RegistryValueKind.String);
				}
				b(ok + text);
			}
			catch (Exception ex13)
			{
				b(fail + text);
				b("ERROR-" + ex13);
				installOK = false;
			}
			RegistryKey registryKey3 = null;
			text = "64bit codec descriptions registered";
			try
			{
				text10 = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\drivers.desc";
				registryKey3 = Registry.LocalMachine.OpenSubKey(text10, writable: true);
				registryKey3.SetValue("dfsc.dll", "DebugMode FSVFWC (internal use)", RegistryValueKind.String);
				registryKey3.SetValue("dfscacm.dll", "DebugMode FSACMC (internal use)", RegistryValueKind.String);
				b(ok + text);
			}
			catch (Exception ex14)
			{
				b(fail + text);
				b("ERROR-" + ex14);
				installOK = false;
			}
			text = "32bit codec descriptions registered";
			try
			{
				text11 = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows NT\\CurrentVersion\\drivers.desc";
				registryKey3 = Registry.LocalMachine.OpenSubKey(text11, writable: true);
				if (hasV12)
				{
					registryKey3.SetValue("dfsc.dll", "DebugMode FSVFWC (internal use)", RegistryValueKind.String);
					registryKey3.SetValue("dfscacm.dll", "DebugMode FSACMC (internal use)", RegistryValueKind.String);
				}
				registryKey3.SetValue("dfsc32.dll", "DebugMode FSVFWC (internal use)", RegistryValueKind.String);
				registryKey3.SetValue("dfscacm32.dll", "DebugMode FSACMC (internal use)", RegistryValueKind.String);
				b(ok + text);
			}
			catch (Exception ex15)
			{
				b(fail + text);
				b("ERROR-" + ex15);
				installOK = false;
			}
			text = "FS uniinstall info written";
			try
			{
				string value2 = sysDir + "Program Files\\Debugmode\\FrameServer\\fsuninst.exe";
				string name3 = "Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
				RegistryKey registryKey4 = Registry.LocalMachine.OpenSubKey(name3, writable: true).CreateSubKey(text6);
				registryKey4.SetValue("DisplayName", text6, RegistryValueKind.String);
				registryKey4.SetValue("UninstallString", value2, RegistryValueKind.ExpandString);
				b(ok + text);
			}
			catch (Exception ex16)
			{
				b(fail + text);
				b("ERROR-" + ex16);
				installOK = false;
			}
			b(ok + "Frameserver for V12-18 Installed");
		}
		catch (Exception ex17)
		{
			MessageBox.Show("The V12-18 FrameServer Installation Failed.", "Warning", (MessageBoxButtons)0, (MessageBoxIcon)48);
			b(fail + "Frameserver for V12-18 Installed");
			b("ERROR-" + ex17);
			a(ex17.Message);
			installOK = false;
		}
	}

	private void l()
	{
		try
		{
			mpcDir = toolsDir + "\\MPC-HC";
			string text = Path.Combine(mpcDir, "mpc-hc64.exe");
			if (File.Exists(text) && FileVersionInfo.GetVersionInfo(text).FileVersion.StartsWith("2.2.1"))
			{
				b(ok + "Media Player Classic - Home Cinema Latest Version Already Installed");
				return;
			}
			if (Directory.Exists(mpcDir))
			{
				Directory.Delete(mpcDir, recursive: true);
			}
			Directory.CreateDirectory(mpcDir);
			string text2 = Path.Combine(tempExeDir, "temp.exe");
			if (File.Exists(text2))
			{
				File.Delete(text2);
			}
			File.WriteAllBytes(text2, Resources.MPC_HC_2_2_1_x64);
			ZipFile.ExtractToDirectory(text2, mpcDir);
			File.Delete(text2);
			b(ok + "Media Player Classic - Home Cinema Installed");
		}
		catch (Exception ex)
		{
			b(fail + "Media Player Classic - Home Cinema Installed");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	private void k()
	{
		try
		{
			string text = Path.Combine(tempExeDir, "ShaderPresets.reg");
			File.WriteAllText(text, Resources.ShaderPresets);
			Process.Start("regedit.exe", "/s " + text).WaitForExit();
			File.Delete(text);
			b(ok + "Media Player Classic - Shader Preses Installed");
		}
		catch (Exception ex)
		{
			b(fail + "Media Player Classic - Shader Preses Installed");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	private void j()
	{
		try
		{
			string fileName = "regsvr32";
			ProcessStartInfo processStartInfo = new ProcessStartInfo(fileName);
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			processStartInfo.Arguments = "/s " + quote + mpcDir + "\\LAVFilters64\\LAVAudio.ax" + quote;
			Process? process = Process.Start(processStartInfo);
			process.WaitForExit();
			process.Close();
			processStartInfo = new ProcessStartInfo(fileName);
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			processStartInfo.Arguments = "/s " + quote + mpcDir + "\\LAVFilters64\\LAVSplitter.ax" + quote;
			Process? process2 = Process.Start(processStartInfo);
			process2.WaitForExit();
			process2.Close();
			processStartInfo = new ProcessStartInfo(fileName);
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			processStartInfo.Arguments = "/s " + quote + mpcDir + "\\LAVFilters64\\LAVVideo.ax" + quote;
			Process? process3 = Process.Start(processStartInfo);
			process3.WaitForExit();
			process3.Close();
			b(ok + "Lav Filters 64bit Registered");
		}
		catch (Exception ex)
		{
			b(fail + "Lav Filters 64bit Registered");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
		try
		{
			Process.Start(sysDir + "Program Files\\HappyOtterScripts\\CodecTweakTool_650", "/silent /win7ds /h264_x64={FA10746C-9B63-4B6C-BC49-FC300EA5F256} /hevc_x64={FA10746C-9B63-4B6C-BC49-FC300EA5F256} /mp4v_x64={FA10746C-9B63-4B6C-BC49-FC300EA5F256} /mpeg2_x64={FA10746C-9B63-4B6C-BC49-FC300EA5F256} /mp43_x64={FA10746C-9B63-4B6C-BC49-FC300EA5F256}");
			b(ok + "Codecs Tweaked");
		}
		catch (Exception ex2)
		{
			b(fail + "Codecs Tweaked");
			b("ERROR-" + ex2);
			installOK = false;
			a(ex2.Message);
		}
	}

	private void i()
	{
		string text = toolsDir + "\\VirtualDub2";
		if (Directory.Exists(text))
		{
			try
			{
				string text2 = Path.Combine(tempExeDir, "temp.exe");
				File.WriteAllBytes(text2, Resources.VirtualDub2);
				ZipFile.ExtractToDirectory(text2, tempDir);
				d(text);
				c(tempDir);
				File.Delete(text2);
				b(ok + "VirtualDub2 Updated");
				return;
			}
			catch (Exception ex)
			{
				b(fail + "VirtualDub2 Updated");
				b("ERROR-" + ex);
				installOK = false;
				a(ex.Message);
				return;
			}
		}
		Directory.CreateDirectory(text);
		try
		{
			string text3 = Path.Combine(tempExeDir, "temp.exe");
			File.WriteAllBytes(text3, Resources.VirtualDub2);
			ZipFile.ExtractToDirectory(text3, text);
			File.Delete(text3);
			b(ok + "VirtualDub2 Installed");
		}
		catch (Exception ex2)
		{
			b(fail + "VirtualDub2 Installed");
			b("ERROR-" + ex2);
			installOK = false;
			a(ex2.Message);
		}
		try
		{
			string a_ = text + "\\plugins32";
			string text4 = Path.Combine(tempExeDir, "temp.exe");
			File.WriteAllBytes(text4, Resources.Deshaker31);
			ZipFile.ExtractToDirectory(text4, tempDir);
			d(a_);
			c(tempDir);
			File.Delete(text4);
			b(ok + "Deshaker 32 bit filter Installed");
		}
		catch (Exception ex3)
		{
			b(fail + "Deshaker 32 bit filter Installed");
			b("ERROR-" + ex3);
			installOK = false;
			a(ex3.Message);
		}
		try
		{
			string a_2 = text + "\\plugins64";
			string text5 = Path.Combine(tempExeDir, "temp.exe");
			File.WriteAllBytes(text5, Resources.Deshaker31_64);
			ZipFile.ExtractToDirectory(text5, tempDir);
			d(a_2);
			c(tempDir);
			File.Delete(text5);
			b(ok + "Deshaker 64 bit filter Installed");
		}
		catch (Exception ex4)
		{
			b(fail + "Deshaker 64 bit filter Installed");
			b("ERROR-" + ex4);
			installOK = false;
			a(ex4.Message);
		}
	}

	private void h()
	{
		try
		{
			Shortcut.CreateShortcut();
			b(ok + "Shortcuts placed on Desktop");
		}
		catch (Exception ex)
		{
			b(fail + "Shortcuts placed on Desktop");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	private void g()
	{
		try
		{
			string text = Path.Combine(tempExeDir, "vcredist_x64.exe");
			File.WriteAllBytes(text, Resources.VC_redist_x64);
			Process.Start(new ProcessStartInfo(text)
			{
				Arguments = "/norestart",
				WindowStyle = ProcessWindowStyle.Normal,
				UseShellExecute = false
			}).WaitForExit();
			b(ok + "VS 2019 x64 Redist Package Installed");
		}
		catch (Exception ex)
		{
			b(fail + "VS 2019 x64 Redist Package Installed");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	private void f()
	{
		try
		{
			string text = Path.Combine(tempExeDir, "vcredist_x86.exe");
			File.WriteAllBytes(text, Resources.VC_redist_x86);
			Process.Start(new ProcessStartInfo(text)
			{
				Arguments = "/norestart",
				WindowStyle = ProcessWindowStyle.Normal,
				UseShellExecute = false
			}).WaitForExit();
			b(ok + "VS 201 x86 Redist Package Installed");
		}
		catch (Exception ex)
		{
			b(fail + "VS 2019 x86 Redist Package Installed");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	private void e()
	{
		//IL_0c1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c07: Unknown result type (might be due to invalid IL or missing references)
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			try
			{
				string text = Path.Combine(tempExeDir, "temp.exe");
				File.WriteAllBytes(text, Resources.Tools);
				ZipFile.ExtractToDirectory(text, tempDir);
				d(toolsDir);
				string[] files = Directory.GetFiles(tempDir);
				foreach (string text2 in files)
				{
					if (text2.Contains("Microsoft.WindowsAPICodePack"))
					{
						a(text2, toolsDir);
					}
				}
				c(tempDir);
				File.Delete(text);
				b(ok + "Tools Added");
			}
			catch (Exception ex)
			{
				b(fail + "Tools Added");
				b("ERROR-" + ex);
				installOK = false;
				a(ex.Message);
			}
			((Control)y).Visible = true;
			((Control)y).Refresh();
			try
			{
				string text3 = toolsDir + "\\Licenses";
				Directory.CreateDirectory(text3);
				string text4 = Path.Combine(tempExeDir, "temp.exe");
				File.WriteAllBytes(text4, Resources.Licensing_Agreements);
				ZipFile.ExtractToDirectory(text4, tempDir);
				d(text3);
				c(tempDir);
				File.Delete(text4);
				b(ok + "Licenses Added");
			}
			catch (Exception ex2)
			{
				b(fail + "Licenses Added");
				b("ERROR-" + ex2);
				installOK = false;
				a(ex2.Message);
			}
			try
			{
				string text5 = toolsDir + "\\AvisynthRepository\\AVSPLUS_x86\\plugins";
				Directory.CreateDirectory(text5);
				string text6 = Path.Combine(tempExeDir, "temp.exe");
				File.WriteAllBytes(text6, Resources.avs32plugins);
				ZipFile.ExtractToDirectory(text6, tempDir);
				d(text5);
				c(tempDir);
				File.Delete(text6);
				b(ok + "32bit Avisynth plugins Added");
			}
			catch (Exception ex3)
			{
				b(fail + "32bit Avisynth plugins Added");
				b("ERROR-" + ex3);
				installOK = false;
				a(ex3.Message);
			}
			try
			{
				string text7 = toolsDir + "\\AvisynthRepository\\AVSPLUS_x64\\plugins";
				Directory.CreateDirectory(text7);
				string text8 = Path.Combine(tempExeDir, "temp.exe");
				File.WriteAllBytes(text8, Resources.avs64plugins);
				ZipFile.ExtractToDirectory(text8, tempDir);
				d(text7);
				c(tempDir);
				File.Delete(text8);
				b(ok + "64bit Avisynth plugins Added");
			}
			catch (Exception ex4)
			{
				b(fail + "64bit Avisynth plugins Added");
				b("ERROR-" + ex4);
				installOK = false;
				a(ex4.Message);
			}
			if (hasSony && installSony)
			{
				try
				{
					string text9 = sysDir + "ProgramData\\Sony\\Vegas Pro\\Application Extensions";
					Directory.CreateDirectory(text9);
					string text10 = sonyDir + "\\Extensions";
					Directory.CreateDirectory(text10);
					string text11 = Path.Combine(tempExeDir, "temp.exe");
					File.WriteAllBytes(text11, Resources.V13_Extensions);
					ZipFile.ExtractToDirectory(text11, tempDir);
					d(text10);
					c(tempDir);
					string[] files = Directory.GetFiles(text10);
					foreach (string obj in files)
					{
						string fileName = Path.GetFileName(obj);
						File.Copy(obj, Path.Combine(text9, fileName), overwrite: true);
					}
					File.Delete(text11);
					b(ok + "Extensions for Sony Vegas Added");
				}
				catch (Exception ex5)
				{
					b(fail + "Extensions for Sony Vegas Added");
					b("ERROR-" + ex5);
					installOK = false;
					a(ex5.Message);
				}
			}
			if (hasMagix && installMagix)
			{
				try
				{
					string text12 = sysDir + "ProgramData\\VEGAS Pro\\Application Extensions";
					Directory.CreateDirectory(text12);
					string text13 = magixDir + "\\Extensions";
					Directory.CreateDirectory(text13);
					string text14 = Path.Combine(tempExeDir, "temp.exe");
					File.WriteAllBytes(text14, Resources.V14_Extensions);
					ZipFile.ExtractToDirectory(text14, tempDir);
					d(text13);
					c(tempDir);
					string[] files = Directory.GetFiles(text13);
					foreach (string obj2 in files)
					{
						string fileName2 = Path.GetFileName(obj2);
						File.Copy(obj2, Path.Combine(text12, fileName2), overwrite: true);
					}
					File.Delete(text14);
					b(ok + "Extensions for Magix Vegas Added");
				}
				catch (Exception ex6)
				{
					b(fail + "Extensions for Magix Vegas Added");
					b("ERROR-" + ex6);
					installOK = false;
					a(ex6.Message);
				}
			}
			if (hasSony && installSony)
			{
				try
				{
					string text15 = Path.Combine(tempExeDir, "temp.exe");
					File.WriteAllBytes(text15, Resources.V13_Scripts);
					ZipFile.ExtractToDirectory(text15, tempDir);
					d(sonyScriptsDir);
					if (af.Checked)
					{
						foreach (string installDir in installDirs)
						{
							if (installDir.Contains("12") || installDir.Contains("13"))
							{
								string text16 = installDir + scriptMenuFolder;
								Directory.CreateDirectory(text16);
								d(text16);
							}
						}
					}
					c(tempDir);
					File.Delete(text15);
					b(ok + "Scripts for Sony Vegas Added");
				}
				catch (Exception ex7)
				{
					b(fail + "Scripts for Sony Vegas Added");
					b("ERROR-" + ex7);
					installOK = false;
					a(ex7.Message);
				}
			}
			if (hasMagix && installMagix)
			{
				try
				{
					string text17 = Path.Combine(tempExeDir, "temp.exe");
					File.WriteAllBytes(text17, Resources.V14_Scripts);
					ZipFile.ExtractToDirectory(text17, tempDir);
					d(magixScriptsDir);
					if (af.Checked)
					{
						foreach (string installDir2 in installDirs)
						{
							if (!installDir2.Contains("12") && !installDir2.Contains("13"))
							{
								string text18 = installDir2 + scriptMenuFolder;
								Directory.CreateDirectory(text18);
								d(text18);
							}
						}
					}
					c(tempDir);
					File.Delete(text17);
					b(ok + "Scripts for Magix Vegas Added");
				}
				catch (Exception ex8)
				{
					b(fail + "Scripts for Magix Vegas Added");
					b("ERROR-" + ex8);
					installOK = false;
					a(ex8.Message);
				}
			}
			try
			{
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string text19 = folderPath + "\\Sony\\Render Templates\\avc-sony";
				string text20 = folderPath + "\\VEGAS\\Render Templates\\avc-sony";
				Directory.CreateDirectory(text19);
				Directory.CreateDirectory(text20);
				string text21 = Path.Combine(tempExeDir, "temp.exe");
				File.WriteAllBytes(text21, Resources.avc_sony);
				ZipFile.ExtractToDirectory(text21, tempDir);
				d(text19);
				d(text20);
				c(tempDir);
				File.Delete(text21);
				b(ok + "Audio Templates for Sony AAC Added");
			}
			catch (Exception ex9)
			{
				b(fail + "Audio Templates for Sony AAC Added");
				b("ERROR-" + ex9);
				installOK = false;
				a(ex9.Message);
			}
			try
			{
				string text22 = Path.Combine(tempExeDir, "temp.exe");
				File.WriteAllBytes(text22, Resources.AVS_Scripts);
				ZipFile.ExtractToDirectory(text22, tempDir);
				d(avsDir);
				c(tempDir);
				File.Delete(text22);
				b(ok + "Sample Avisynth Scripts Added");
			}
			catch (Exception ex10)
			{
				b(fail + "Sample Avisynth Scripts Added");
				b("ERROR-" + ex10);
				installOK = false;
				a(ex10.Message);
			}
			try
			{
				string text23 = Path.Combine(tempExeDir, "temp.exe");
				File.WriteAllBytes(text23, Resources.Vdub_Settings);
				ZipFile.ExtractToDirectory(text23, tempDir);
				d(vdubDir);
				c(tempDir);
				File.Delete(text23);
				b(ok + "Sample VirtualDub FilterSettings Added");
			}
			catch (Exception ex11)
			{
				b(fail + "Sample VirtualDub FilterSettings Added");
				b("ERROR-" + ex11);
				installOK = false;
				a(ex11.Message);
			}
			try
			{
				string text24 = Path.Combine(tempExeDir, "temp.exe");
				File.WriteAllBytes(text24, Resources.VirtualDub_RenderSettings);
				ZipFile.ExtractToDirectory(text24, tempDir);
				d(vdubRenderDir);
				c(tempDir);
				File.Delete(text24);
				b(ok + "Sample VirtualDub RenderSettings Added");
			}
			catch (Exception ex12)
			{
				b(fail + "Sample VirtualDub RenderSettings Added");
				b("ERROR-" + ex12);
				installOK = false;
				a(ex12.Message);
			}
			try
			{
				string text25 = Path.Combine(tempExeDir, "temp.exe");
				File.WriteAllBytes(text25, Resources.ColorThemes);
				ZipFile.ExtractToDirectory(text25, tempDir);
				File.Copy(Path.Combine(tempDir, "HappyOtterHelp.chm"), Path.Combine(userDir, "HappyOtterHelp.chm"), overwrite: true);
				File.Copy(Path.Combine(tempDir, "vegasKeys.txt"), Path.Combine(userDir, "vegasKeys.txt"), overwrite: true);
				if (!keepSettings)
				{
					File.Copy(Path.Combine(tempDir, "ColorThemes.xml"), Path.Combine(userDir, "ColorThemes.xml"), overwrite: true);
					File.Copy(Path.Combine(tempDir, "ToolFileLocation.xml"), Path.Combine(userDir, "ToolFileLocation.xml"), overwrite: true);
				}
				Array.ForEach(Directory.GetFiles(tempDir), File.Delete);
				File.Delete(text25);
				b(ok + "Misc File Settings Added");
			}
			catch (Exception ex13)
			{
				b(fail + "Misc File Settings Added");
				b("ERROR-" + ex13);
				installOK = false;
				a(ex13.Message);
			}
			Cursor.Current = Cursors.Default;
			AddEnvironmentPath(toolsDir);
			string filepath = toolsDir + "\\VirtualDub2";
			AddEnvironmentPath(filepath);
		}
		catch (Exception ex14)
		{
			if (ex14.Message.Contains("virus"))
			{
				MessageBox.Show("Windows Defender thinks there is malware in one of the files.  Disable real-time checking and try again.", "HappyOtterSetup", (MessageBoxButtons)0, (MessageBoxIcon)16);
			}
			else
			{
				MessageBox.Show("An error has occurred.  After you hit OK, another message will appear.  Please do a screen grab or copy the contents of the message and send it to HappyOtterScripts.  Thanks!", "HappyOtterSetup", (MessageBoxButtons)0, (MessageBoxIcon)16);
				MessageBox.Show(ex14.Message);
				installOK = false;
			}
			a(ex14.Message);
		}
	}

	private void d()
	{
		string text = toolsDir + "/_models";
		Directory.CreateDirectory(text);
		if (File.Exists(Path.Combine(text + "/faster-whisper-base", "model.bin")))
		{
			b("Base Whisper Model found");
			return;
		}
		try
		{
			string text2 = Path.Combine(tempExeDir, "temp.exe");
			File.WriteAllBytes(text2, Resources._models);
			ZipFile.ExtractToDirectory(text2, text);
			File.Delete(text2);
			b(ok + "Whisper Models Added");
		}
		catch (Exception ex)
		{
			b(fail + "Whisper Models Added");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	public void AddEnvironmentPath(string filepath)
	{
		try
		{
			string text = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine) ?? string.Empty;
			if (!text.Contains(filepath))
			{
				if (!string.IsNullOrEmpty(text) && !text.EndsWith(";"))
				{
					text += ";";
				}
				text += filepath;
				Environment.SetEnvironmentVariable("PATH", text, EnvironmentVariableTarget.Machine);
				Array.ForEach(Directory.GetFiles(tempDir), File.Delete);
				b(ok + "Environment Path Added: " + filepath);
			}
		}
		catch (Exception ex)
		{
			b(fail + "Environment Variable Path statement updated");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	public void newRestorePoint()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0035: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			MessageBox.Show("Starting with Windows 8.1 and newer, 24 hours must elapse before a new Restore Point can be created.  If it has been less than 24 hours, the Sucessful Creation box will still appear even though the point has not been created.  The only workaround is to first delete all previous restore points.", "Warning", (MessageBoxButtons)0, (MessageBoxIcon)48);
			ManagementScope val = new ManagementScope("\\\\localhost\\root\\DEFAULT");
			ManagementPath val2 = new ManagementPath("SystemRestore");
			ObjectGetOptions val3 = new ObjectGetOptions();
			ManagementClass val4 = new ManagementClass(val, val2, val3);
			ManagementBaseObject methodParameters = ((ManagementObject)val4).GetMethodParameters("CreateRestorePoint");
			methodParameters["Description"] = "HappyOtter Install";
			methodParameters["RestorePointType"] = 0;
			methodParameters["EventType"] = 100;
			((ManagementObject)val4).InvokeMethod("CreateRestorePoint", methodParameters, (InvokeMethodOptions)null);
			MessageBox.Show("Restore point has been successfully created.", "Attention", (MessageBoxButtons)0, (MessageBoxIcon)64);
			b(ok + "Restore Point Created");
		}
		catch (ManagementException val5)
		{
			ManagementException val6 = val5;
			MessageBox.Show("Error.  Restore point was not created.", "Warning", (MessageBoxButtons)0, (MessageBoxIcon)48);
			b(fail + "Restore point created.");
			b("ERROR-" + (object)val6);
			installOK = false;
			a(((Exception)(object)val6).Message);
		}
		restorePointCompleted = true;
	}

	private void b(string A_0, string A_1)
	{
		FileInfo fileInfo = null;
		try
		{
			FileInfo fileInfo2 = new FileInfo(A_0);
			fileInfo = new FileInfo(Path.Combine(A_1, fileInfo2.Name));
			if (fileInfo.Exists)
			{
				if (fileInfo2.LastWriteTime > fileInfo.LastWriteTime)
				{
					fileInfo2.CopyTo(fileInfo.FullName, overwrite: true);
					b("Copied later version " + fileInfo2.Name + " to " + A_1);
				}
				else
				{
					b("Same version--did not copy " + fileInfo2.Name + " to " + A_1);
				}
			}
			else
			{
				fileInfo2.CopyTo(fileInfo.FullName);
				b("Copied " + fileInfo2.Name + " to " + A_1);
			}
		}
		catch (Exception ex)
		{
			string text = "";
			foreach (Process item in LockTools.FindLockers(fileInfo.FullName))
			{
				text += item.ProcessName;
			}
			installOK = false;
			b("Error copying " + A_0 + Environment.NewLine + ex.Message + Environment.NewLine + "File Locked By: " + text);
		}
	}

	private void a(string A_0, string A_1)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(A_0);
			FileInfo fileInfo2 = new FileInfo(Path.Combine(A_1, fileInfo.Name));
			if (fileInfo2.Exists)
			{
				File.Delete(fileInfo2.FullName);
				fileInfo.CopyTo(fileInfo2.FullName, overwrite: true);
				b("File overwritten " + fileInfo.Name + " to " + A_1);
			}
			else
			{
				fileInfo.CopyTo(fileInfo2.FullName);
				b("Copied " + fileInfo.Name + " to " + A_1);
			}
		}
		catch (Exception ex)
		{
			installOK = false;
			b("Error overwriting " + A_0 + Environment.NewLine + ex.Message);
		}
	}

	private void d(string A_0)
	{
		try
		{
			if (!Directory.Exists(A_0))
			{
				b("ERROR:" + A_0 + " does not exist");
				return;
			}
			Directory.CreateDirectory(A_0);
			string[] files = Directory.GetFiles(tempDir, "*", SearchOption.AllDirectories);
			foreach (string text in files)
			{
				string fileName = Path.GetFileName(text);
				string text2 = Path.Combine(A_0, fileName);
				FileInfo fileInfo = new FileInfo(text);
				FileInfo fileInfo2 = new FileInfo(text2);
				if (!File.Exists(text2))
				{
					File.Copy(text, text2);
					b("Added " + text2);
					continue;
				}
				string text3 = fileInfo.LastWriteTime.ToString("yyyy/MM/dd");
				string text4 = fileInfo2.LastWriteTime.ToString("yyyy/MM/dd");
				if (fileInfo.LastWriteTime > fileInfo2.LastWriteTime)
				{
					File.Copy(text, text2, overwrite: true);
					b("Updated " + text2 + "--From-" + text4 + "--To-" + text3);
				}
				else
				{
					b("No Update To: " + text2);
				}
			}
		}
		catch (Exception ex)
		{
			b(fail + "File update problem");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	private void c(string A_0)
	{
		if (Directory.Exists(A_0))
		{
			Array.ForEach(Directory.GetFiles(A_0, "*", SearchOption.AllDirectories), File.Delete);
		}
	}

	private void a(string A_0, string A_1, string A_2, bool A_3)
	{
		SearchOption searchOption = SearchOption.AllDirectories;
		if (A_3)
		{
			searchOption = SearchOption.TopDirectoryOnly;
		}
		try
		{
			Directory.CreateDirectory(A_2);
			string[] files = Directory.GetFiles(A_0, A_1, searchOption);
			foreach (string text in files)
			{
				string fileName = Path.GetFileName(text);
				string text2 = Path.Combine(A_2, fileName);
				FileInfo fileInfo = new FileInfo(text);
				FileInfo fileInfo2 = new FileInfo(text2);
				if (!File.Exists(text2))
				{
					File.Copy(text, text2);
					b("Added " + text2);
					continue;
				}
				string text3 = fileInfo.LastWriteTime.ToString("yyyy/MM/dd");
				string text4 = fileInfo2.LastWriteTime.ToString("yyyy/MM/dd");
				if (fileInfo.LastWriteTime > fileInfo2.LastWriteTime)
				{
					File.Copy(text, text2, overwrite: true);
					b("Updated " + text2 + "--From-" + text4 + "--To-" + text3);
				}
				else
				{
					b("No Update To: " + text2);
				}
			}
		}
		catch (Exception ex)
		{
			b(fail + "File update problem");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	private void b(string A_0)
	{
		Directory.CreateDirectory(hoDocDir);
		Directory.CreateDirectory(hoDocDir + "\\CrashLogs");
		string path = Path.Combine(hoDocDir, "HappyOtterInstall.log");
		string format = DateTime.Now.ToString("yyyy/MM/dd  HH:mm:ss ") + "-- " + A_0;
		StreamWriter streamWriter = new StreamWriter(path, append: true);
		streamWriter.WriteLine(format, true);
		streamWriter.Close();
	}

	private void c(object A_0, EventArgs A_1)
	{
		if (this.m_n.Checked)
		{
			installSony = true;
		}
		else
		{
			installSony = false;
		}
	}

	private void b(object A_0, EventArgs A_1)
	{
		if (this.m_m.Checked)
		{
			installMagix = true;
		}
		else
		{
			installMagix = false;
		}
	}

	public static void SetFolderPermission(string folderPath)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
		DirectorySecurity accessControl = directoryInfo.GetAccessControl();
		WindowsIdentity.GetCurrent();
		FileSystemAccessRule rule = new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
		accessControl.AddAccessRule(rule);
		directoryInfo.SetAccessControl(accessControl);
	}

	public void RegisterControlPanelProgram()
	{
		try
		{
			Version version = ((object)this).GetType().Assembly.GetName().Version;
			string text = "HappyOtterScripts for Vegas Pro";
			string value = sysDir + "Program Files\\HappyOtterScripts\\HappyOtterUninstall.exe";
			string value2 = sysDir + "Program Files\\HappyOtterScripts";
			string value3 = sysDir + "Program Files\\HappyOtterScripts\\otter.ico";
			string name = "Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name, writable: true).CreateSubKey(text);
			registryKey.SetValue("DisplayName", text, RegistryValueKind.String);
			registryKey.SetValue("Publisher", "The Happy Otter", RegistryValueKind.String);
			registryKey.SetValue("InstallLocation", value2, RegistryValueKind.ExpandString);
			registryKey.SetValue("DisplayIcon", value3, RegistryValueKind.String);
			registryKey.SetValue("UninstallString", value, RegistryValueKind.ExpandString);
			registryKey.SetValue("DisplayVersion", version.ToString(), RegistryValueKind.String);
			b(ok + "Added Registry Entries for Uninstall");
		}
		catch (Exception ex)
		{
			b(fail + "Added Registry Entries for Uninstall");
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
	}

	public void ToolbarLabel_MouseDown(object sender, MouseEventArgs e)
	{
		ReleaseCapture();
		SendMessage(((Control)this).Handle, 161, 2, 0);
	}

	public void killProcess(string processName)
	{
		Process[] processesByName = Process.GetProcessesByName(processName);
		if (processesByName.Length != 0)
		{
			processesByName[0].Kill();
			processesByName[0].WaitForExit();
		}
	}

	private void a(object A_0, EventArgs A_1)
	{
		if (ae.Checked)
		{
			installShortcuts = true;
		}
		else
		{
			installShortcuts = false;
		}
	}

	private void c()
	{
		b("Installation Cancelled");
		Application.Exit();
	}

	private void b()
	{
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string path = Path.Combine(tempExeDir, "Vis2019");
			File.WriteAllText(path, Resources.VS2017Version);
			StreamReader streamReader = new StreamReader(path);
			newVersion = new Version(streamReader.ReadLine());
			streamReader.Close();
			File.Delete(path);
			b(ok + "Redist Version - " + newVersion.ToString());
		}
		catch (Exception ex)
		{
			b(fail + "Redist Version - " + newVersion.ToString());
			b("ERROR-" + ex);
			installOK = false;
			a(ex.Message);
		}
		try
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\VisualStudio\\14.0\\VC\\Runtimes\\x64");
			if (registryKey == null)
			{
				installRedist64 = true;
				b("VS2019 x64 registry key does not exist");
			}
			else if (Registry.GetValue(registryKey.Name, "Version", null) == null)
			{
				installRedist64 = true;
				b("VS2019 x64 version # does not exist");
			}
			else
			{
				string text = registryKey.GetValue("Version").ToString();
				b("User x64 redist - " + text);
				text = text.Substring(1);
				if (text == null)
				{
					installRedist64 = true;
				}
				else
				{
					Version value = new Version(text);
					if (newVersion.CompareTo(value) > 0)
					{
						installRedist64 = true;
					}
					else
					{
						installRedist64 = false;
					}
				}
			}
			b("Install x64 redist - " + installRedist64);
			b(ok + "VS2019 x64 redist query completed");
		}
		catch (Exception ex2)
		{
			b(fail + "VS2019 x64 redist query completed");
			b("ERROR-" + ex2);
			installOK = false;
			a(ex2.Message);
		}
		try
		{
			RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\VisualStudio\\14.0\\VC\\Runtimes\\x86");
			if (registryKey2 == null)
			{
				installRedist86 = true;
				b("VS2019 x86 registry key does not exist");
			}
			else if (Registry.GetValue(registryKey2.Name, "Version", null) == null)
			{
				installRedist86 = true;
				b("VS2019 x86 version # does not exist");
			}
			else
			{
				string text2 = registryKey2.GetValue("Version").ToString();
				b("User x86 redist - " + text2);
				text2 = text2.Substring(1);
				if (text2 == null)
				{
					installRedist86 = true;
				}
				else
				{
					Version value2 = new Version(text2);
					if (newVersion.CompareTo(value2) > 0)
					{
						installRedist86 = true;
					}
					else
					{
						installRedist86 = false;
					}
				}
			}
			b("Install x86 redist - " + installRedist86);
			b(ok + "VS2019 x86 redist query completed");
		}
		catch (Exception ex3)
		{
			b(fail + "VS2019 x86 redist query completed");
			b("ERROR-" + ex3);
			installOK = false;
			a(ex3.Message);
		}
		if (installRedist64)
		{
			if (!isElevated)
			{
				MessageBox.Show("The Microsoft Visual C++ 2019 Redistributable Package(x64) must be installed.  However you must have elevated privileges.  Enter cancel to exit and re-run HappyOtterSetup with Run as administrator selected in the context menu (right-click)!", "Warning", (MessageBoxButtons)0, (MessageBoxIcon)16);
				if (Directory.Exists(userDir))
				{
					Directory.Delete(userDir, recursive: true);
				}
				if (Directory.Exists(toolsDir))
				{
					Directory.Delete(toolsDir, recursive: true);
				}
				((Control)this.m_d).Enabled = false;
				((Control)this.m_g).Enabled = false;
				reStartAdmin = true;
				return;
			}
			MessageBox.Show("The Microsoft Visual C++ 2019 Redistributable Package(x64) must be installed", "Warning", (MessageBoxButtons)0, (MessageBoxIcon)48);
			g();
		}
		if (!installRedist86)
		{
			return;
		}
		if (!isElevated)
		{
			MessageBox.Show("The Microsoft Visual C++ 2019 Redistributable Package(x86) must be installed.  However you must have elevated privileges.  Enter cancel to exit and re-run HappyOtterSetup with Run as administrator selected in the context menu (right-click)!", "Warning", (MessageBoxButtons)0, (MessageBoxIcon)16);
			if (Directory.Exists(userDir))
			{
				Directory.Delete(userDir, recursive: true);
			}
			if (Directory.Exists(toolsDir))
			{
				Directory.Delete(toolsDir, recursive: true);
			}
			((Control)this.m_d).Enabled = false;
			((Control)this.m_g).Enabled = false;
			reStartAdmin = true;
		}
		else
		{
			MessageBox.Show("The Microsoft Visual C++ 2019 Redistributable Package(x86) must be installed", "Warning", (MessageBoxButtons)0, (MessageBoxIcon)48);
			f();
		}
	}

	public string GetVegasPath(string version)
	{
		try
		{
			string text = "";
			string text2 = "";
			string name = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths";
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name, writable: false).OpenSubKey(version);
			if (registryKey == null)
			{
				return null;
			}
			text2 = registryKey.GetValue("Path").ToString();
			text = registryKey.GetValue("").ToString();
			if (File.Exists(text))
			{
				return text2;
			}
			return null;
		}
		catch (Exception ex)
		{
			b("FAILED: Cannot access registry. " + ex.Message);
		}
		return null;
	}

	public static bool MagicYUVInstalled()
	{
		bool result = true;
		string name = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Drivers32";
		if (Registry.LocalMachine.OpenSubKey(name, writable: true).GetValue("VIDC.M8Y0") == null)
		{
			result = false;
		}
		return result;
	}

	private void a(Form A_0)
	{
		Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
		int width = workingArea.Width;
		int height = workingArea.Height;
		int width2 = ((Form)this).Size.Width;
		int height2 = ((Form)this).Size.Height;
		int num = (width - width2) / 2;
		int num2 = (height - height2) / 2;
		A_0.Location = new Point(num, num2);
	}

	private void a(string A_0)
	{
		if (A_0.Contains("UnauthorizedAccessException"))
		{
			securityException = true;
		}
	}

	private void a(List<string> A_0, string A_1)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		string text = A_1 + Environment.NewLine;
		for (int i = 0; i < A_0.Count(); i++)
		{
			text = text + i + ": " + A_0[i] + Environment.NewLine;
		}
		MessageBox.Show(text);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_b != null)
		{
			this.m_b.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void a()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_087b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6d: Expected O, but got Unknown
		//IL_0dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_104d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1107: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b7: Expected O, but got Unknown
		//IL_11ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1267: Unknown result type (might be due to invalid IL or missing references)
		//IL_1271: Expected O, but got Unknown
		//IL_12b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1330: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1456: Unknown result type (might be due to invalid IL or missing references)
		//IL_152e: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b8: Expected O, but got Unknown
		//IL_17bd: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form2));
		this.m_c = new Button();
		this.m_d = new Button();
		this.m_e = new Label();
		this.m_g = new Button();
		this.m_h = new GroupBox();
		this.m_t = new Label();
		this.m_r = new Label();
		this.m_s = new Label();
		this.m_q = new Label();
		this.m_p = new Label();
		this.m_o = new Label();
		this.m_i = new Label();
		z = new PictureBox();
		y = new PictureBox();
		x = new PictureBox();
		w = new PictureBox();
		v = new PictureBox();
		this.m_u = new PictureBox();
		this.m_j = new Label();
		this.m_k = new CheckBox();
		this.m_f = new PictureBox();
		this.m_l = new GroupBox();
		this.m_m = new CheckBox();
		this.m_n = new CheckBox();
		aa = new Label();
		ab = new Label();
		ac = new Label();
		ad = new Label();
		ae = new CheckBox();
		af = new CheckBox();
		ag = new CheckBox();
		((Control)this.m_h).SuspendLayout();
		((ISupportInitialize)z).BeginInit();
		((ISupportInitialize)y).BeginInit();
		((ISupportInitialize)x).BeginInit();
		((ISupportInitialize)w).BeginInit();
		((ISupportInitialize)v).BeginInit();
		((ISupportInitialize)this.m_u).BeginInit();
		((ISupportInitialize)this.m_f).BeginInit();
		((Control)this.m_l).SuspendLayout();
		((Control)this).SuspendLayout();
		this.m_c.DialogResult = (DialogResult)3;
		((ButtonBase)this.m_c).FlatStyle = (FlatStyle)0;
		((Control)this.m_c).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_c).Location = new Point(614, 571);
		((Control)this.m_c).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_c).Name = "button1_cancel";
		((Control)this.m_c).Size = new Size(128, 35);
		((Control)this.m_c).TabIndex = 0;
		((Control)this.m_c).Text = "Cancel";
		((ButtonBase)this.m_c).UseVisualStyleBackColor = true;
		((Control)this.m_c).Click += f;
		((ButtonBase)this.m_d).FlatStyle = (FlatStyle)0;
		((Control)this.m_d).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_d).Location = new Point(449, 571);
		((Control)this.m_d).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_d).Name = "NextButton";
		((Control)this.m_d).Size = new Size(128, 35);
		((Control)this.m_d).TabIndex = 1;
		((Control)this.m_d).Text = "Install";
		((ButtonBase)this.m_d).UseVisualStyleBackColor = true;
		((Control)this.m_d).Click += e;
		((Control)this.m_e).Anchor = (AnchorStyles)4;
		this.m_e.BorderStyle = (BorderStyle)1;
		((Control)this.m_e).Location = new Point(-4, 543);
		((Control)this.m_e).Margin = new Padding(4, 0, 4, 0);
		((Control)this.m_e).Name = "label1";
		((Control)this.m_e).Size = new Size(1049, 2);
		((Control)this.m_e).TabIndex = 3;
		this.m_g.DialogResult = (DialogResult)7;
		((ButtonBase)this.m_g).FlatStyle = (FlatStyle)0;
		((Control)this.m_g).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_g).Location = new Point(282, 571);
		((Control)this.m_g).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_g).Name = "PreviousButton";
		((Control)this.m_g).Size = new Size(128, 35);
		((Control)this.m_g).TabIndex = 7;
		((Control)this.m_g).Text = "Previous";
		((ButtonBase)this.m_g).UseVisualStyleBackColor = true;
		((Control)this.m_g).Click += d;
		((Control)this.m_h).Controls.Add((Control)(object)this.m_t);
		((Control)this.m_h).Controls.Add((Control)(object)this.m_r);
		((Control)this.m_h).Controls.Add((Control)(object)this.m_s);
		((Control)this.m_h).Controls.Add((Control)(object)this.m_q);
		((Control)this.m_h).Controls.Add((Control)(object)this.m_p);
		((Control)this.m_h).Controls.Add((Control)(object)this.m_o);
		((Control)this.m_h).Controls.Add((Control)(object)this.m_i);
		((Control)this.m_h).Controls.Add((Control)(object)z);
		((Control)this.m_h).Controls.Add((Control)(object)y);
		((Control)this.m_h).Controls.Add((Control)(object)x);
		((Control)this.m_h).Controls.Add((Control)(object)w);
		((Control)this.m_h).Controls.Add((Control)(object)v);
		((Control)this.m_h).Controls.Add((Control)(object)this.m_u);
		((Control)this.m_h).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_h).Location = new Point(284, 208);
		((Control)this.m_h).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_h).Name = "groupBox2";
		((Control)this.m_h).Padding = new Padding(4, 5, 4, 5);
		((Control)this.m_h).Size = new Size(494, 228);
		((Control)this.m_h).TabIndex = 9;
		this.m_h.TabStop = false;
		((Control)this.m_h).Text = "Apps to be installed or updated";
		((Control)this.m_t).AutoSize = true;
		((Control)this.m_t).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_t).Location = new Point(30, 63);
		((Control)this.m_t).Margin = new Padding(4, 0, 4, 0);
		((Control)this.m_t).Name = "label10";
		((Control)this.m_t).Size = new Size(69, 20);
		((Control)this.m_t).TabIndex = 28;
		((Control)this.m_t).Text = "FFmpeg";
		((Control)this.m_r).AutoSize = true;
		((Control)this.m_r).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_r).Location = new Point(30, 94);
		((Control)this.m_r).Margin = new Padding(4, 0, 4, 0);
		((Control)this.m_r).Name = "label9";
		((Control)this.m_r).Size = new Size(148, 20);
		((Control)this.m_r).TabIndex = 26;
		((Control)this.m_r).Text = "VirtualDub2 (VDub)";
		((Control)this.m_s).AutoSize = true;
		((Control)this.m_s).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_s).Location = new Point(30, 186);
		((Control)this.m_s).Margin = new Padding(4, 0, 4, 0);
		((Control)this.m_s).Name = "label8";
		((Control)this.m_s).Size = new Size(229, 20);
		((Control)this.m_s).TabIndex = 24;
		((Control)this.m_s).Text = "Media Player Classic (MPC-HC)";
		((Control)this.m_q).AutoSize = true;
		((Control)this.m_q).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_q).Location = new Point(30, 155);
		((Control)this.m_q).Margin = new Padding(4, 0, 4, 0);
		((Control)this.m_q).Name = "label7";
		((Control)this.m_q).Size = new Size(158, 20);
		((Control)this.m_q).TabIndex = 23;
		((Control)this.m_q).Text = "UtVideo Codec Suite";
		((Control)this.m_p).AutoSize = true;
		((Control)this.m_p).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_p).Location = new Point(30, 125);
		((Control)this.m_p).Margin = new Padding(4, 0, 4, 0);
		((Control)this.m_p).Name = "label6";
		((Control)this.m_p).Size = new Size(193, 20);
		((Control)this.m_p).TabIndex = 22;
		((Control)this.m_p).Text = "DebugMode FrameServer";
		((Control)this.m_o).AutoSize = true;
		((Control)this.m_o).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_o).Location = new Point(30, 32);
		((Control)this.m_o).Margin = new Padding(4, 0, 4, 0);
		((Control)this.m_o).Name = "label3";
		((Control)this.m_o).Size = new Size(179, 20);
		((Control)this.m_o).TabIndex = 21;
		((Control)this.m_o).Text = "Avisynth+ (32 and 64bit)";
		((Control)this.m_i).AutoSize = true;
		((Control)this.m_i).Location = new Point(384, 0);
		((Control)this.m_i).Margin = new Padding(4, 0, 4, 0);
		((Control)this.m_i).Name = "label5";
		((Control)this.m_i).Size = new Size(72, 20);
		((Control)this.m_i).TabIndex = 17;
		((Control)this.m_i).Text = "Progress";
		z.Image = (Image)(object)Resources.check_16_16;
		((Control)z).Location = new Point(408, 29);
		((Control)z).Margin = new Padding(4, 5, 4, 5);
		((Control)z).Name = "pictureBox2";
		((Control)z).Size = new Size(24, 25);
		z.TabIndex = 30;
		z.TabStop = false;
		y.Image = (Image)(object)Resources.check_16_16;
		((Control)y).Location = new Point(408, 58);
		((Control)y).Margin = new Padding(4, 5, 4, 5);
		((Control)y).Name = "pictureBox3";
		((Control)y).Size = new Size(24, 25);
		y.TabIndex = 31;
		y.TabStop = false;
		x.Image = (Image)(object)Resources.check_16_16;
		((Control)x).Location = new Point(408, 89);
		((Control)x).Margin = new Padding(4, 5, 4, 5);
		((Control)x).Name = "pictureBox4";
		((Control)x).Size = new Size(24, 25);
		x.TabIndex = 32;
		x.TabStop = false;
		w.Image = (Image)(object)Resources.check_16_16;
		((Control)w).Location = new Point(408, 120);
		((Control)w).Margin = new Padding(4, 5, 4, 5);
		((Control)w).Name = "pictureBox5";
		((Control)w).Size = new Size(24, 25);
		w.TabIndex = 33;
		w.TabStop = false;
		v.Image = (Image)(object)Resources.check_16_16;
		((Control)v).Location = new Point(408, 151);
		((Control)v).Margin = new Padding(4, 5, 4, 5);
		((Control)v).Name = "pictureBox6";
		((Control)v).Size = new Size(24, 25);
		v.TabIndex = 34;
		v.TabStop = false;
		this.m_u.Image = (Image)(object)Resources.check_16_16;
		((Control)this.m_u).Location = new Point(408, 182);
		((Control)this.m_u).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_u).Name = "pictureBox7";
		((Control)this.m_u).Size = new Size(24, 25);
		this.m_u.TabIndex = 35;
		this.m_u.TabStop = false;
		((Control)this.m_j).AutoSize = true;
		((Control)this.m_j).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)this.m_j).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_j).Location = new Point(286, 51);
		((Control)this.m_j).Margin = new Padding(4, 0, 4, 0);
		((Control)this.m_j).Name = "label4";
		((Control)this.m_j).Size = new Size(465, 29);
		((Control)this.m_j).TabIndex = 10;
		((Control)this.m_j).Text = "Applications to be Installed or Updated\r\n";
		((Control)this.m_k).AutoSize = true;
		((Control)this.m_k).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_k).Location = new Point(284, 89);
		((Control)this.m_k).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_k).Name = "createRestorePointCheckBox";
		((Control)this.m_k).Size = new Size(241, 24);
		((Control)this.m_k).TabIndex = 11;
		((Control)this.m_k).Text = "Create System Restore Point";
		((ButtonBase)this.m_k).UseVisualStyleBackColor = true;
		((Control)this.m_f).BackgroundImage = (Image)(object)Resources.happyOtter;
		((Control)this.m_f).BackgroundImageLayout = (ImageLayout)3;
		((Control)this.m_f).Location = new Point(18, 49);
		((Control)this.m_f).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_f).Name = "pictureBox1";
		((Control)this.m_f).Size = new Size(236, 490);
		this.m_f.TabIndex = 5;
		this.m_f.TabStop = false;
		((Control)this.m_l).Controls.Add((Control)(object)this.m_m);
		((Control)this.m_l).Controls.Add((Control)(object)this.m_n);
		((Control)this.m_l).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_l).Location = new Point(284, 117);
		((Control)this.m_l).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_l).Name = "groupBox1";
		((Control)this.m_l).Padding = new Padding(4, 5, 4, 5);
		((Control)this.m_l).Size = new Size(494, 77);
		((Control)this.m_l).TabIndex = 12;
		this.m_l.TabStop = false;
		((Control)this.m_l).Text = "Versions to be Installed";
		((Control)this.m_m).AutoSize = true;
		((Control)this.m_m).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_m).Location = new Point(201, 32);
		((Control)this.m_m).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_m).Name = "MagixCheckBox";
		((Control)this.m_m).Size = new Size(143, 24);
		((Control)this.m_m).TabIndex = 14;
		((Control)this.m_m).Text = "Magix V13-V21";
		((ButtonBase)this.m_m).UseVisualStyleBackColor = true;
		this.m_m.CheckedChanged += b;
		((Control)this.m_n).AutoSize = true;
		((Control)this.m_n).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_n).Location = new Point(34, 32);
		((Control)this.m_n).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_n).Name = "SonyCheckBox";
		((Control)this.m_n).Size = new Size(138, 24);
		((Control)this.m_n).TabIndex = 13;
		((Control)this.m_n).Text = "Sony V12-V13";
		((ButtonBase)this.m_n).UseVisualStyleBackColor = true;
		this.m_n.CheckedChanged += c;
		((Control)aa).BackColor = Color.FromArgb(70, 70, 70);
		((Control)aa).Dock = (DockStyle)1;
		((Control)aa).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)aa).ForeColor = Color.FromArgb(185, 191, 198);
		aa.ImageAlign = (ContentAlignment)16;
		((Control)aa).Location = new Point(0, 0);
		((Control)aa).Margin = new Padding(4, 0, 4, 0);
		((Control)aa).Name = "ToolbarLabel";
		((Control)aa).Size = new Size(825, 46);
		((Control)aa).TabIndex = 76;
		((Control)aa).Text = "        HappyOtter Setup";
		aa.TextAlign = (ContentAlignment)16;
		((Control)aa).MouseDown += new MouseEventHandler(ToolbarLabel_MouseDown);
		((Control)ab).BackColor = Color.FromArgb(70, 70, 70);
		((Control)ab).Dock = (DockStyle)2;
		((Control)ab).Location = new Point(0, 633);
		((Control)ab).Margin = new Padding(4, 0, 4, 0);
		((Control)ab).Name = "BottomBorder";
		((Control)ab).Size = new Size(825, 11);
		((Control)ab).TabIndex = 88;
		((Control)ac).BackColor = Color.FromArgb(70, 70, 70);
		((Control)ac).Dock = (DockStyle)3;
		((Control)ac).Location = new Point(0, 46);
		((Control)ac).Margin = new Padding(4, 0, 4, 0);
		((Control)ac).Name = "LeftBorder";
		((Control)ac).Size = new Size(10, 587);
		((Control)ac).TabIndex = 97;
		((Control)ad).BackColor = Color.FromArgb(70, 70, 70);
		((Control)ad).Dock = (DockStyle)4;
		((Control)ad).Location = new Point(815, 46);
		((Control)ad).Margin = new Padding(4, 0, 4, 0);
		((Control)ad).Name = "RightBorder";
		((Control)ad).Size = new Size(10, 587);
		((Control)ad).TabIndex = 96;
		((Control)ae).AutoSize = true;
		ae.Checked = true;
		ae.CheckState = (CheckState)1;
		((Control)ae).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)ae).Location = new Point(285, 478);
		((Control)ae).Margin = new Padding(4, 5, 4, 5);
		((Control)ae).Name = "cbDesktopShortcuts";
		((Control)ae).Size = new Size(501, 24);
		((Control)ae).TabIndex = 98;
		((Control)ae).Text = "Add Desktop Shortcuts for VDub, MPC-HC, and HOS Batch Tools";
		((ButtonBase)ae).UseVisualStyleBackColor = true;
		ae.CheckedChanged += a;
		((Control)af).AutoSize = true;
		af.Checked = true;
		af.CheckState = (CheckState)1;
		((Control)af).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)af).Location = new Point(285, 448);
		((Control)af).Margin = new Padding(4, 5, 4, 5);
		((Control)af).Name = "cbAddToScriptMenu";
		((Control)af).Size = new Size(364, 24);
		((Control)af).TabIndex = 99;
		((Control)af).Text = "Add Happy Otter Scripts to Vegas Script Menu";
		((ButtonBase)af).UseVisualStyleBackColor = true;
		((Control)ag).AutoSize = true;
		ag.Checked = true;
		ag.CheckState = (CheckState)1;
		((Control)ag).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)ag).Location = new Point(285, 510);
		((Control)ag).Margin = new Padding(4, 5, 4, 5);
		((Control)ag).Name = "cbKeyboardShortcuts";
		((Control)ag).Size = new Size(357, 24);
		((Control)ag).TabIndex = 100;
		((Control)ag).Text = "Add Keyboard Shortcuts to all keyboard maps";
		((ButtonBase)ag).UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(9f, 20f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = Color.FromArgb(45, 45, 45);
		((Form)this).ClientSize = new Size(825, 644);
		((Control)this).Controls.Add((Control)(object)ag);
		((Control)this).Controls.Add((Control)(object)af);
		((Control)this).Controls.Add((Control)(object)ae);
		((Control)this).Controls.Add((Control)(object)ac);
		((Control)this).Controls.Add((Control)(object)ad);
		((Control)this).Controls.Add((Control)(object)ab);
		((Control)this).Controls.Add((Control)(object)aa);
		((Control)this).Controls.Add((Control)(object)this.m_l);
		((Control)this).Controls.Add((Control)(object)this.m_k);
		((Control)this).Controls.Add((Control)(object)this.m_j);
		((Control)this).Controls.Add((Control)(object)this.m_h);
		((Control)this).Controls.Add((Control)(object)this.m_g);
		((Control)this).Controls.Add((Control)(object)this.m_e);
		((Control)this).Controls.Add((Control)(object)this.m_d);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Control)this).Controls.Add((Control)(object)this.m_f);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).Margin = new Padding(4, 5, 4, 5);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Form2";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "HappyOtter Scripting Setup";
		((Form)this).Load += g;
		((Control)this.m_h).ResumeLayout(false);
		((Control)this.m_h).PerformLayout();
		((ISupportInitialize)z).EndInit();
		((ISupportInitialize)y).EndInit();
		((ISupportInitialize)x).EndInit();
		((ISupportInitialize)w).EndInit();
		((ISupportInitialize)v).EndInit();
		((ISupportInitialize)this.m_u).EndInit();
		((ISupportInitialize)this.m_f).EndInit();
		((Control)this.m_l).ResumeLayout(false);
		((Control)this.m_l).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
