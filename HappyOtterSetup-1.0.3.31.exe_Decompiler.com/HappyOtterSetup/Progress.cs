using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HappyOtterSetup;

public class Progress : Form
{
	private IContainer m_a;

	public Progress()
	{
		a();
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
		((Control)this).SuspendLayout();
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(177, 15);
		((Form)this).ControlBox = false;
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Control)this).Name = "Progress";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "Installation in Progress";
		((Control)this).ResumeLayout(false);
	}
}
