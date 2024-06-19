using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HappyOtterSetup.Properties;

namespace HappyOtterSetup;

public class Form1 : Form
{
	public const int WM_NCLBUTTONDOWN = 161;

	public const int HT_CAPTION = 2;

	public static int toolBarLabelHeight;

	private IContainer m_a;

	private Button m_b;

	private Button m_c;

	private Label d;

	private Label e;

	private Label f;

	private PictureBox g;

	private Label h;

	private Label i;

	private Label j;

	private Label k;

	public Form1()
	{
		a();
	}

	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	private void c(object A_0, EventArgs A_1)
	{
		toolBarLabelHeight = ((Control)h).Height;
		((Form)this).StartPosition = (FormStartPosition)0;
		a((Form)(object)this);
		Shortcut.loadColors((Form)(object)this);
	}

	private void a(Form A_0)
	{
		Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
		int width = workingArea.Width;
		int height = workingArea.Height;
		int width2 = ((Form)this).Size.Width;
		int height2 = ((Form)this).Size.Height;
		int x = (width - width2) / 2;
		int y = (height - height2) / 2;
		A_0.Location = new Point(x, y);
	}

	private void b(object A_0, EventArgs A_1)
	{
		Application.Exit();
	}

	public void ToolbarLabel_MouseDown(object sender, MouseEventArgs e)
	{
		ReleaseCapture();
		SendMessage(((Control)this).Handle, 161, 2, 0);
	}

	private void a(object A_0, EventArgs A_1)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		while (true)
		{
			bool flag = false;
			for (int i = 12; i <= 20; i++)
			{
				if (Process.GetProcessesByName("vegas" + i + "0").Length != 0)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				break;
			}
			MessageBox.Show("You must close all instances of Vegas before running setup.  After Vegas closes, enter OK to continue!", "Stop", (MessageBoxButtons)0, (MessageBoxIcon)16);
		}
		((Control)this).Hide();
		((Form)new Form4()).ShowDialog();
		((Form)this).Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && this.m_a != null)
		{
			this.m_a.Dispose();
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
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Expected O, but got Unknown
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_080f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0819: Expected O, but got Unknown
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
		this.m_b = new Button();
		this.m_c = new Button();
		d = new Label();
		e = new Label();
		f = new Label();
		g = new PictureBox();
		h = new Label();
		i = new Label();
		j = new Label();
		k = new Label();
		((ISupportInitialize)g).BeginInit();
		((Control)this).SuspendLayout();
		this.m_b.DialogResult = (DialogResult)3;
		((ButtonBase)this.m_b).FlatStyle = (FlatStyle)0;
		((Control)this.m_b).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_b).Location = new Point(621, 532);
		((Control)this.m_b).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_b).Name = "cancelButton";
		((Control)this.m_b).Size = new Size(128, 35);
		((Control)this.m_b).TabIndex = 1;
		((Control)this.m_b).Text = "Cancel";
		((ButtonBase)this.m_b).UseVisualStyleBackColor = true;
		((Control)this.m_b).Click += b;
		this.m_c.DialogResult = (DialogResult)6;
		((ButtonBase)this.m_c).FlatStyle = (FlatStyle)0;
		((Control)this.m_c).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_c).Location = new Point(450, 532);
		((Control)this.m_c).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_c).Name = "nextButton";
		((Control)this.m_c).Size = new Size(128, 35);
		((Control)this.m_c).TabIndex = 0;
		((Control)this.m_c).Text = "Next";
		((ButtonBase)this.m_c).UseVisualStyleBackColor = true;
		((Control)this.m_c).Click += a;
		((Control)d).Anchor = (AnchorStyles)4;
		((Control)d).BackColor = Color.FromArgb(70, 70, 70);
		d.FlatStyle = (FlatStyle)0;
		((Control)d).Location = new Point(-8, 514);
		((Control)d).Margin = new Padding(4, 0, 4, 0);
		((Control)d).Name = "label1";
		((Control)d).Size = new Size(1050, 3);
		((Control)d).TabIndex = 3;
		((Control)e).BackColor = Color.Transparent;
		((Control)e).Font = new Font("Microsoft Sans Serif", 15.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)e).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)e).Location = new Point(282, 85);
		((Control)e).Margin = new Padding(4, 0, 4, 0);
		((Control)e).Name = "label3";
		((Control)e).Size = new Size(483, 89);
		((Control)e).TabIndex = 7;
		((Control)e).Text = "Welcome to the HappyOtter\r\n     Scripts Setup Wizard";
		((Control)f).BackColor = Color.Transparent;
		((Control)f).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)f).Location = new Point(298, 206);
		((Control)f).Margin = new Padding(4, 0, 4, 0);
		((Control)f).Name = "label4";
		((Control)f).Size = new Size(466, 272);
		((Control)f).TabIndex = 8;
		((Control)f).Text = componentResourceManager.GetString("label4.Text");
		((Control)g).BackgroundImage = (Image)(object)Resources.happyOtter;
		((Control)g).BackgroundImageLayout = (ImageLayout)4;
		((Control)g).Location = new Point(10, 45);
		((Control)g).Margin = new Padding(4, 5, 4, 5);
		((Control)g).Name = "pictureBox1";
		((Control)g).Size = new Size(243, 471);
		g.TabIndex = 5;
		g.TabStop = false;
		((Control)h).BackColor = Color.FromArgb(70, 70, 70);
		((Control)h).Dock = (DockStyle)1;
		((Control)h).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)h).ForeColor = Color.FromArgb(185, 191, 198);
		h.ImageAlign = (ContentAlignment)16;
		((Control)h).Location = new Point(0, 0);
		((Control)h).Margin = new Padding(4, 0, 4, 0);
		((Control)h).Name = "ToolbarLabel";
		((Control)h).Size = new Size(825, 46);
		((Control)h).TabIndex = 75;
		((Control)h).Text = "        HappyOtter Setup";
		h.TextAlign = (ContentAlignment)16;
		((Control)h).MouseDown += new MouseEventHandler(ToolbarLabel_MouseDown);
		((Control)i).BackColor = Color.FromArgb(70, 70, 70);
		((Control)i).Dock = (DockStyle)2;
		((Control)i).Location = new Point(0, 580);
		((Control)i).Margin = new Padding(4, 0, 4, 0);
		((Control)i).Name = "BottomBorder";
		((Control)i).Size = new Size(825, 11);
		((Control)i).TabIndex = 87;
		((Control)j).BackColor = Color.FromArgb(70, 70, 70);
		((Control)j).Dock = (DockStyle)3;
		((Control)j).Location = new Point(0, 46);
		((Control)j).Margin = new Padding(4, 0, 4, 0);
		((Control)j).Name = "LeftBorder";
		((Control)j).Size = new Size(10, 534);
		((Control)j).TabIndex = 95;
		((Control)k).BackColor = Color.FromArgb(70, 70, 70);
		((Control)k).Dock = (DockStyle)4;
		((Control)k).Location = new Point(815, 46);
		((Control)k).Margin = new Padding(4, 0, 4, 0);
		((Control)k).Name = "RightBorder";
		((Control)k).Size = new Size(10, 534);
		((Control)k).TabIndex = 94;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(9f, 20f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = Color.FromArgb(45, 45, 45);
		((Form)this).ClientSize = new Size(825, 591);
		((Control)this).Controls.Add((Control)(object)j);
		((Control)this).Controls.Add((Control)(object)k);
		((Control)this).Controls.Add((Control)(object)i);
		((Control)this).Controls.Add((Control)(object)f);
		((Control)this).Controls.Add((Control)(object)e);
		((Control)this).Controls.Add((Control)(object)d);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Control)this).Controls.Add((Control)(object)g);
		((Control)this).Controls.Add((Control)(object)h);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).Margin = new Padding(4, 5, 4, 5);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Form1";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "HappyOtter Scripting Setup";
		((Form)this).Load += c;
		((ISupportInitialize)g).EndInit();
		((Control)this).ResumeLayout(false);
	}
}
