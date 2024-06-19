using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HappyOtterSetup.Properties;

namespace HappyOtterSetup;

public class Form4 : Form
{
	public const int WM_NCLBUTTONDOWN = 161;

	public const int HT_CAPTION = 2;

	private IContainer m_a;

	private Button m_b;

	private Button m_c;

	private Label m_d;

	private PictureBox m_e;

	private Button f;

	private TextBox g;

	private Label h;

	private RadioButton i;

	private RadioButton j;

	private Label k;

	private Label l;

	private Label m;

	private Label n;

	public Form4()
	{
		a();
	}

	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	private void e(object A_0, EventArgs A_1)
	{
		Application.Exit();
	}

	private void d(object A_0, EventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).Hide();
		((Form)new Form2()).ShowDialog();
		((Form)this).Close();
	}

	private void c(object A_0, EventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).Hide();
		((Form)new Form1()).ShowDialog();
		((Form)this).Close();
	}

	private void b(object A_0, EventArgs A_1)
	{
		if (i.Checked)
		{
			((Control)this.m_c).Enabled = true;
		}
		else
		{
			((Control)this.m_c).Enabled = false;
		}
	}

	public void ToolbarLabel_MouseDown(object sender, MouseEventArgs e)
	{
		ReleaseCapture();
		SendMessage(((Control)this).Handle, 161, 2, 0);
	}

	private void a(object A_0, EventArgs A_1)
	{
		Shortcut.loadColors((Form)(object)this);
		((Form)this).StartPosition = (FormStartPosition)0;
		CenterFormPrimaryScreen((Form)(object)this);
	}

	public void CenterFormPrimaryScreen(Form form)
	{
		Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
		int width = workingArea.Width;
		int height = workingArea.Height;
		int width2 = ((Form)this).Size.Width;
		int height2 = ((Form)this).Size.Height;
		int x = (width - width2) / 2;
		int y = (height - height2) / 2;
		form.Location = new Point(x, y);
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
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Expected O, but got Unknown
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Expected O, but got Unknown
		//IL_0836: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0934: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aae: Expected O, but got Unknown
		//IL_0ab3: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form4));
		this.m_b = new Button();
		this.m_c = new Button();
		this.m_d = new Label();
		this.m_e = new PictureBox();
		f = new Button();
		g = new TextBox();
		h = new Label();
		i = new RadioButton();
		j = new RadioButton();
		k = new Label();
		l = new Label();
		m = new Label();
		n = new Label();
		((ISupportInitialize)this.m_e).BeginInit();
		((Control)this).SuspendLayout();
		((ButtonBase)this.m_b).FlatStyle = (FlatStyle)0;
		((Control)this.m_b).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_b).Location = new Point(627, 537);
		((Control)this.m_b).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_b).Name = "button1_cancel";
		((Control)this.m_b).Size = new Size(128, 35);
		((Control)this.m_b).TabIndex = 1;
		((Control)this.m_b).Text = "Cancel";
		((ButtonBase)this.m_b).UseVisualStyleBackColor = true;
		((Control)this.m_b).Click += e;
		((Control)this.m_c).Enabled = false;
		((ButtonBase)this.m_c).FlatStyle = (FlatStyle)0;
		((Control)this.m_c).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)this.m_c).Location = new Point(462, 537);
		((Control)this.m_c).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_c).Name = "NextButton";
		((Control)this.m_c).Size = new Size(128, 35);
		((Control)this.m_c).TabIndex = 0;
		((Control)this.m_c).Text = "Next";
		((ButtonBase)this.m_c).UseVisualStyleBackColor = true;
		((Control)this.m_c).Click += d;
		((Control)this.m_d).Anchor = (AnchorStyles)4;
		this.m_d.BorderStyle = (BorderStyle)1;
		this.m_d.FlatStyle = (FlatStyle)0;
		((Control)this.m_d).Location = new Point(-2, 514);
		((Control)this.m_d).Margin = new Padding(4, 0, 4, 0);
		((Control)this.m_d).Name = "label1";
		((Control)this.m_d).Size = new Size(824, 2);
		((Control)this.m_d).TabIndex = 3;
		((Control)this.m_e).BackgroundImage = (Image)(object)Resources.happyOtter;
		((Control)this.m_e).BackgroundImageLayout = (ImageLayout)4;
		((Control)this.m_e).Location = new Point(6, 46);
		((Control)this.m_e).Margin = new Padding(4, 5, 4, 5);
		((Control)this.m_e).Name = "pictureBox1";
		((Control)this.m_e).Size = new Size(243, 471);
		this.m_e.TabIndex = 5;
		this.m_e.TabStop = false;
		((ButtonBase)f).FlatStyle = (FlatStyle)0;
		((Control)f).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)f).Location = new Point(296, 537);
		((Control)f).Margin = new Padding(4, 5, 4, 5);
		((Control)f).Name = "PreviousButton";
		((Control)f).Size = new Size(128, 35);
		((Control)f).TabIndex = 7;
		((Control)f).Text = "Previous";
		((ButtonBase)f).UseVisualStyleBackColor = true;
		((Control)f).Click += c;
		((Control)g).BackColor = Color.FromArgb(45, 45, 45);
		((TextBoxBase)g).BorderStyle = (BorderStyle)1;
		((Control)g).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)g).Location = new Point(258, 106);
		((Control)g).Margin = new Padding(4, 5, 4, 5);
		((TextBoxBase)g).Multiline = true;
		((Control)g).Name = "textBox1";
		g.ScrollBars = (ScrollBars)2;
		((Control)g).Size = new Size(545, 385);
		((Control)g).TabIndex = 8;
		((Control)g).Text = componentResourceManager.GetString("textBox1.Text");
		((Control)h).AutoSize = true;
		((Control)h).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)h).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)h).Location = new Point(384, 62);
		((Control)h).Margin = new Padding(4, 0, 4, 0);
		((Control)h).Name = "label3";
		((Control)h).Size = new Size(259, 29);
		((Control)h).TabIndex = 9;
		((Control)h).Text = "Licensing Agreement";
		((Control)i).AutoSize = true;
		((Control)i).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)i).Location = new Point(24, 542);
		((Control)i).Margin = new Padding(4, 5, 4, 5);
		((Control)i).Name = "acceptRB";
		((Control)i).Size = new Size(84, 24);
		((Control)i).TabIndex = 10;
		((Control)i).Text = "Accept";
		((ButtonBase)i).UseVisualStyleBackColor = true;
		i.CheckedChanged += b;
		((Control)j).AutoSize = true;
		j.Checked = true;
		((Control)j).ForeColor = Color.FromArgb(185, 191, 198);
		((Control)j).Location = new Point(122, 542);
		((Control)j).Margin = new Padding(4, 5, 4, 5);
		((Control)j).Name = "declineRB";
		((Control)j).Size = new Size(87, 24);
		((Control)j).TabIndex = 11;
		j.TabStop = true;
		((Control)j).Text = "Decline";
		((ButtonBase)j).UseVisualStyleBackColor = true;
		((Control)k).BackColor = Color.FromArgb(70, 70, 70);
		((Control)k).Dock = (DockStyle)1;
		((Control)k).Font = new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)k).ForeColor = Color.FromArgb(185, 191, 198);
		k.ImageAlign = (ContentAlignment)16;
		((Control)k).Location = new Point(0, 0);
		((Control)k).Margin = new Padding(4, 0, 4, 0);
		((Control)k).Name = "ToolbarLabel";
		((Control)k).Size = new Size(825, 46);
		((Control)k).TabIndex = 76;
		((Control)k).Text = "        HappyOtter Setup";
		k.TextAlign = (ContentAlignment)16;
		((Control)k).MouseDown += new MouseEventHandler(ToolbarLabel_MouseDown);
		((Control)l).BackColor = Color.FromArgb(70, 70, 70);
		((Control)l).Dock = (DockStyle)2;
		((Control)l).Location = new Point(0, 580);
		((Control)l).Margin = new Padding(4, 0, 4, 0);
		((Control)l).Name = "BottomBorder";
		((Control)l).Size = new Size(825, 11);
		((Control)l).TabIndex = 88;
		((Control)m).BackColor = Color.FromArgb(70, 70, 70);
		((Control)m).Dock = (DockStyle)3;
		((Control)m).Location = new Point(0, 46);
		((Control)m).Margin = new Padding(4, 0, 4, 0);
		((Control)m).Name = "LeftBorder";
		((Control)m).Size = new Size(10, 534);
		((Control)m).TabIndex = 97;
		((Control)n).BackColor = Color.FromArgb(70, 70, 70);
		((Control)n).Dock = (DockStyle)4;
		((Control)n).Location = new Point(815, 46);
		((Control)n).Margin = new Padding(4, 0, 4, 0);
		((Control)n).Name = "RightBorder";
		((Control)n).Size = new Size(10, 534);
		((Control)n).TabIndex = 96;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(9f, 20f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = Color.FromArgb(45, 45, 45);
		((Form)this).ClientSize = new Size(825, 591);
		((Control)this).Controls.Add((Control)(object)m);
		((Control)this).Controls.Add((Control)(object)n);
		((Control)this).Controls.Add((Control)(object)l);
		((Control)this).Controls.Add((Control)(object)k);
		((Control)this).Controls.Add((Control)(object)j);
		((Control)this).Controls.Add((Control)(object)i);
		((Control)this).Controls.Add((Control)(object)h);
		((Control)this).Controls.Add((Control)(object)g);
		((Control)this).Controls.Add((Control)(object)f);
		((Control)this).Controls.Add((Control)(object)this.m_d);
		((Control)this).Controls.Add((Control)(object)this.m_c);
		((Control)this).Controls.Add((Control)(object)this.m_b);
		((Control)this).Controls.Add((Control)(object)this.m_e);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).Margin = new Padding(4, 5, 4, 5);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Form4";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "HappyOtter Scripting Setup";
		((Form)this).Load += a;
		((ISupportInitialize)this.m_e).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
