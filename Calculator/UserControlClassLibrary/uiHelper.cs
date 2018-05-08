using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UtilityClassLibrary;

namespace UserControlClassLibrary {
    public class UIHelper : IHelper {

        public void ControlsOfType<T>(Control parent, List<T> found) {

            found.AddRange(parent.Controls.OfType<T>());

            foreach(Control child in parent.Controls) {

                ControlsOfType<T>(child, found);
            }
        }

        public void UpdateKeyText(Button button, string pattern, string replace, bool append) {

            button.Text = Regex.Replace(button.Text, pattern, match => {

                return (append ? match.Value : string.Empty) + replace;
            });

            button.Tag = button.Text;
        }

        public void DisableKeys(IEnumerable<Button> keys, IButtonTracker tracker) {

            foreach(var key in keys) {

                tracker.Disable(key);
                key.FlatAppearance.MouseDownBackColor = key.BackColor;
                key.FlatAppearance.MouseOverBackColor = key.BackColor;
                key.ForeColor = Color.FromArgb(75, 75, 75);
            }
        }

        public void EnableKeys(IEnumerable<Button> keys, IButtonTracker tracker) {

            foreach(var key in keys) {

                tracker.Enable(key);
                key.FlatAppearance.MouseDownBackColor = Color.FromArgb(77, 77, 77);
                key.FlatAppearance.MouseOverBackColor = Color.FromArgb(69, 69, 69);
                key.ForeColor = SystemColors.ControlLightLight;
            }
        }

        public void CenterToPoint(Control parent, Point point) {

            parent.Top = point.Y - parent.Height / 2;
            parent.Left = point.X - parent.Width / 2;
        }

        public void CenterToScreen(Control parent) {

            var screen = Screen.FromControl(parent).WorkingArea;
            CenterToPoint(parent, new Point(screen.Width / 2, screen.Height / 2));
        }

        public void ScaleTo(Control parent, int width, int height, bool center = true) {

            var screen = Screen.FromControl(parent).WorkingArea;
            parent.Width = Math.Min(width, screen.Width);
            parent.Height = Math.Min(height, screen.Height);

            if(center) {

                CenterToScreen(parent);
            }
        }

        public void SetHeight(Control control, int height) {

            control.Top -= height - control.Height;
            control.Height = height;
        }

        public void AddLabel(Panel panel, string text, int fontSize, int leftMargin, int topMargin) {

            var label = new Label();
            label.Parent = panel;
            label.Text = text;
            label.Font = new Font(label.Font.FontFamily, fontSize, FontStyle.Bold);
            var dimension = TextRenderer.MeasureText(label.Text, label.Font);
            label.Height = dimension.Height;
            label.Width = dimension.Width;
            label.Left = leftMargin;
            label.Top = topMargin;
        }

        public Rectangle GetViewport(Form form) {

            return Screen.FromControl(form).WorkingArea;
        }

        public Point GetPointerLocation(MouseEventArgs e) {

            return e.Location;
        }

        public bool ContainsPointer(Control control, Point cursor) {

            var pointer = control.PointToClient(cursor);

            return control.ClientRectangle.Contains(pointer);
        }

        public void DragWindow(MouseEventArgs e, Form parent, Point pointer) {

            if(e.Button == MouseButtons.Left) {

                parent.Left += e.X - pointer.X;
                parent.Top += e.Y - pointer.Y;
            }
        }

        public void ButtonMouseEnter(object sender, EventArgs e) {

            var button = (Button)sender;
            button.FlatAppearance.BorderColor = Color.FromArgb(90, 90, 90);
        }

        public void ButtonMouseLeave(object sender, EventArgs e) {

            var button = (Button)sender;
            button.FlatAppearance.BorderColor = button.BackColor;
        }

        public void DrawUnderline(object sender, PaintEventArgs e) {

            var button = (Button)sender;
            int lineHeight = button.FlatAppearance.BorderSize * 2;

            e.Graphics.FillRectangle(

                new SolidBrush(Color.FromArgb(65, 65, 65)),
                0,
                button.Height - lineHeight,
                button.Width,
                lineHeight
            );
        }

        public void RaiseButtonEvent(object sender, EventArgs e, EventHandler handler, IButtonTracker tracker) {

            if(tracker.IsDisabled((Button)sender)) {

                return;
            }

            handler(sender, e);
        }
    }
}