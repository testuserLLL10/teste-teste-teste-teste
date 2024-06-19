using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HappyOtterSetup.Properties;
using IWshRuntimeLibrary;

namespace HappyOtterSetup;

public static class Shortcut
{
	public static void CreateShortcut()
	{
		string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		if (!File.Exists(Path.Combine(folderPath, "\\Vdub64.lnk")))
		{
			IWshShortcut obj = ((WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")))).CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Vdub64.lnk") as IWshShortcut;
			obj.Arguments = "";
			obj.TargetPath = pathRoot + "Program Files\\HappyOtterScripts\\VirtualDub2\\VirtualDub64.exe";
			obj.WindowStyle = 1;
			obj.Description = "VirtualDub2 64bit";
			obj.WorkingDirectory = pathRoot + "Program Files\\HappyOtterScripts\\VirtualDub2";
			obj.Save();
		}
		if (!File.Exists(Path.Combine(folderPath, "\\MPC-HC.lnk")))
		{
			IWshShortcut obj2 = ((WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")))).CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MPC-HC.lnk") as IWshShortcut;
			obj2.Arguments = "";
			obj2.TargetPath = pathRoot + "Program Files\\HappyOtterScripts\\MPC-HC\\mpc-hc64.exe";
			obj2.WindowStyle = 1;
			obj2.Description = "Media Player Classic-Home Cinema";
			obj2.WorkingDirectory = pathRoot + "Program Files\\HappyOtterScripts\\MPC-HC";
			obj2.Save();
		}
		if (!File.Exists(Path.Combine(folderPath, "\\HOS-Batch.lnk")))
		{
			IWshShortcut obj3 = ((WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")))).CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Batch Render.lnk") as IWshShortcut;
			obj3.Arguments = "";
			obj3.TargetPath = pathRoot + "Program Files\\HappyOtterScripts\\BatchRender.exe";
			obj3.WindowStyle = 1;
			obj3.Description = "HappyOtterScripts BatchRender";
			obj3.WorkingDirectory = pathRoot + "Program Files\\HappyOtterScripts";
			obj3.Save();
		}
		if (!File.Exists(Path.Combine(folderPath, "\\Batch Archive.lnk")))
		{
			IWshShortcut obj4 = ((WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")))).CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Batch Archive.lnk") as IWshShortcut;
			obj4.Arguments = "";
			obj4.TargetPath = pathRoot + "Program Files\\HappyOtterScripts\\BatchArchive.exe";
			obj4.WindowStyle = 1;
			obj4.Description = "HappyOtterScripts BatchArchive";
			obj4.WorkingDirectory = pathRoot + "Program Files\\HappyOtterScripts";
			obj4.Save();
		}
		if (!File.Exists(Path.Combine(folderPath, "\\Batch WhisperAI.lnk")))
		{
			IWshShortcut obj5 = ((WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")))).CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Batch WhisperAI.lnk") as IWshShortcut;
			obj5.Arguments = "";
			obj5.TargetPath = pathRoot + "Program Files\\HappyOtterScripts\\BatchWhisperAI.exe";
			obj5.WindowStyle = 1;
			obj5.Description = "HappyOtterScripts BatchWhisperAI";
			obj5.WorkingDirectory = pathRoot + "Program Files\\HappyOtterScripts";
			obj5.Save();
		}
	}

	public static void ToolbarLabel_Paint(object sender, PaintEventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		Color black = Color.Black;
		Color color = ColorTranslator.FromHtml("#464646");
		Color color2 = ColorTranslator.FromHtml("#2D2D2D");
		Color color3 = ColorTranslator.FromHtml("#B9BFC6");
		Color color4 = ChangeColorBrightness(color2, Convert.ToSingle(-0.2));
		if ((double)color.GetBrightness() < 0.4)
		{
			color4 = ChangeColorBrightness(color2, Convert.ToSingle(0.2));
		}
		Label val = (Label)((sender is Label) ? sender : null);
		Pen val2 = new Pen(black, 1f);
		Pen val3 = new Pen(color4, 1f);
		int x = ((Control)val).ClientRectangle.X;
		int y = ((Control)val).ClientRectangle.Y;
		int num = ((Control)val).ClientRectangle.Width - 1;
		int num2 = ((Control)val).ClientRectangle.Height - 1;
		new Rectangle(x, y, num, num2);
		if (((Control)val).Name.Contains("Toolbar"))
		{
			e.Graphics.DrawLine(val2, new Point(x, y), new Point(x + num, y));
			e.Graphics.DrawLine(val2, new Point(x, y), new Point(x, y + num2));
			e.Graphics.DrawLine(val2, new Point(x + num, y), new Point(x + num, y + num2));
			e.Graphics.DrawLine(val3, new Point(x, y + num2), new Point(x + num, y + num2));
			Color color5 = color3;
			Graphics graphics = e.Graphics;
			Bitmap val4 = new Bitmap((Image)(object)Resources.otter_24x24);
			try
			{
				float num3 = (float)(int)color5.R / 255f;
				float num4 = (float)(int)color5.G / 255f;
				float num5 = (float)(int)color5.B / 255f;
				int num6 = Form1.toolBarLabelHeight - 10;
				ColorMatrix colorMatrix = new ColorMatrix(new float[5][]
				{
					new float[5],
					new float[5],
					new float[5],
					new float[5] { 0f, 0f, 0f, 1f, 0f },
					new float[5] { num3, num4, num5, 0f, 1f }
				});
				ImageAttributes val5 = new ImageAttributes();
				val5.SetColorMatrix(colorMatrix);
				graphics.DrawImage((Image)(object)val4, new Rectangle(5, 5, num6, num6), 0, 0, ((Image)val4).Width, ((Image)val4).Height, (GraphicsUnit)2, val5);
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
		if (((Control)val).Name.Contains("Left"))
		{
			((Control)val).BackColor = color2;
			e.Graphics.DrawLine(val2, new Point(x, y), new Point(x, y + num2));
			e.Graphics.DrawLine(val3, new Point(x + num, y), new Point(x + num, y + num2));
		}
		if (((Control)val).Name.Contains("Right"))
		{
			((Control)val).BackColor = color2;
			e.Graphics.DrawLine(val2, new Point(x + num, y), new Point(x + num, y + num2));
			e.Graphics.DrawLine(val3, new Point(x, y), new Point(x, y + num2));
		}
		if (((Control)val).Name.Contains("Bottom"))
		{
			((Control)val).BackColor = color2;
			e.Graphics.DrawLine(val2, new Point(x, y + num2), new Point(x + num, y + num2));
			e.Graphics.DrawLine(val2, new Point(x, y), new Point(x, y + num2));
			e.Graphics.DrawLine(val2, new Point(x + num, y), new Point(x + num, y + num2));
			e.Graphics.DrawLine(val3, new Point(x + num2, y), new Point(x + num - num2, y));
		}
	}

	public static Color ChangeColorBrightness(Color color, float correctionFactor)
	{
		float num = (int)color.R;
		float num2 = (int)color.G;
		float num3 = (int)color.B;
		if (correctionFactor < 0f)
		{
			correctionFactor = 1f + correctionFactor;
			num *= correctionFactor;
			num2 *= correctionFactor;
			num3 *= correctionFactor;
		}
		else
		{
			num = (255f - num) * correctionFactor + num;
			num2 = (255f - num2) * correctionFactor + num2;
			num3 = (255f - num3) * correctionFactor + num3;
		}
		return Color.FromArgb(color.A, (int)num, (int)num2, (int)num3);
	}

	public static void loadColors(Form form)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		Color backColor = ColorTranslator.FromHtml("#464646");
		Color color = ColorTranslator.FromHtml("#2D2D2D");
		ColorTranslator.FromHtml("#B9BFC6");
		Color color2 = ColorTranslator.FromHtml("#B9BFC6");
		foreach (Label item in ((IEnumerable)((Control)form).Controls).OfType<Label>())
		{
			if (((Control)item).Name == "ToolbarLabel" || ((Control)item).Name.Contains("Border"))
			{
				((Control)item).Paint += new PaintEventHandler(ToolbarLabel_Paint);
			}
		}
		Color mouseOverBackColor = ChangeColorBrightness(color, Convert.ToSingle(0.2));
		foreach (Button item2 in ((IEnumerable)((Control)form).Controls).OfType<Button>())
		{
			((Control)item2).BackColor = backColor;
			((Control)item2).ForeColor = color2;
			((ButtonBase)item2).FlatAppearance.BorderSize = 1;
			((ButtonBase)item2).FlatAppearance.BorderColor = color2;
			((ButtonBase)item2).FlatAppearance.MouseOverBackColor = mouseOverBackColor;
		}
	}
}
