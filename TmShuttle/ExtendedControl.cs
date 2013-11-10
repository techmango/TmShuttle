using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
//An object from the Control class
//Created for transparency support.

using System.ComponentModel;
namespace ToastNotification
{

	public class ExtendedControl : Control
	{

		#region "Ctor"

		public ExtendedControl()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}

		#endregion

		#region "Properties"


		bool m_isTransparent = false;
		/// <summary>
		/// Gets or sets the transparency of the control.
		/// Transparency means you can see the controls beneath this control.
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		/// 
		[Description("Gets or sets the 'real' transparency of the control.")]
		public bool IsTransparent {
			get { return m_isTransparent; }
			set {
				m_isTransparent = value;
				if ((value == true)) {
					this.BackColor = Color.Transparent;
				}
				Invalidate();
			}
		}

		#endregion

		#region "Overrides"

		//Override the default paint background event.
		//Append here the true transparency effect.

		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			if ((IsTransparent)) {
				if ((Parent != null)) {
					int myIndex = Parent.Controls.GetChildIndex(this);
					for (int i = Parent.Controls.Count - 1; i >= myIndex + 1; i += -1) {
						Control ctrl = Parent.Controls[i];
						if ((ctrl.Bounds.IntersectsWith(Bounds))) {
							if ((ctrl.Visible)) {
								Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height);
								ctrl.DrawToBitmap(bmp, ctrl.ClientRectangle);
								e.Graphics.TranslateTransform(ctrl.Left - Left, ctrl.Top - Top);
								e.Graphics.DrawImage(bmp, Point.Empty);
								e.Graphics.TranslateTransform(Left - ctrl.Left, Top - ctrl.Top);
								bmp.Dispose();
							}
						}
					}
				}

			}

		}

		#endregion

	}
}
