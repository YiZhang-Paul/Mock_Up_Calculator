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
    public class UIHelper {

        public static void ControlsOfType<T>(Control parent, List<T> found) {

            found.AddRange(parent.Controls.OfType<T>());

            foreach(Control child in parent.Controls) {

                if(child.GetType() != typeof(T)) {

                    ControlsOfType<T>(child, found);
                }
            }
        }

        public static void UpdateKeyText(Button button, string pattern, string replace, bool append) {

            button.Text = Regex.Replace(button.Text, pattern, match => {

                return (append ? match.Value : string.Empty) + replace;
            });

            button.Tag = button.Text;
        }

        public static void DisableKeys(IEnumerable<Button> keys, IButtonTracker tracker) {

            foreach(var key in keys) {

                tracker.Disable(key);
                key.FlatAppearance.MouseDownBackColor = key.BackColor;
                key.FlatAppearance.MouseOverBackColor = key.BackColor;
                key.ForeColor = Color.FromArgb(75, 75, 75);
            }
        }

        public static void EnableKeys(IEnumerable<Button> keys, IButtonTracker tracker) {

            foreach(var key in keys) {

                tracker.Enable(key);
                key.FlatAppearance.MouseDownBackColor = Color.FromArgb(77, 77, 77);
                key.FlatAppearance.MouseOverBackColor = Color.FromArgb(69, 69, 69);
                key.ForeColor = SystemColors.ControlLightLight;
            }
        }

        public static void CenterToPoint(Form parent, Point point) {

            parent.Top = point.Y - parent.Height / 2;
            parent.Left = point.X - parent.Width / 2;
        }

        public static void CenterToScreen(Form parent) {

            var screen = Screen.FromControl(parent).WorkingArea;
            CenterToPoint(parent, new Point(screen.Width / 2, screen.Height / 2));
        }

        public static void ScaleTo(Form parent, int width, int height, bool center = true) {

            var screen = Screen.FromControl(parent).WorkingArea;
            parent.Width = Math.Min(width, screen.Width);
            parent.Height = Math.Min(height, screen.Height);

            if(center) {

                CenterToScreen(parent);
            }
        }

        public static Point GetPointerLocation(MouseEventArgs e) {

            return e.Location;
        }

        public static void DragWindow(MouseEventArgs e, Form parent, Point pointer) {

            if(e.Button == MouseButtons.Left) {

                parent.Left += e.X - pointer.X;
                parent.Top += e.Y - pointer.Y;
            }
        }

        public static void KeypadButtonMouseEnter(object sender, EventArgs e) {

            var button = (Button)sender;
            button.FlatAppearance.BorderColor = Color.FromArgb(90, 90, 90);
        }

        public static void KeypadButtonMouseLeave(object sender, EventArgs e) {

            var button = (Button)sender;
            button.FlatAppearance.BorderColor = button.BackColor;
        }

        public static void DrawUnderline(object sender, PaintEventArgs e) {

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

        public static void RaiseButtonEvent(object sender, EventArgs e, EventHandler handler, IButtonTracker tracker) {

            if(tracker.IsDisabled((Button)sender)) {

                return;
            }

            handler(sender, e);
        }
    }
}