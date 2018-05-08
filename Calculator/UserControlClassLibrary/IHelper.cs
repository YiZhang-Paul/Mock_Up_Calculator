using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UtilityClassLibrary;

namespace UserControlClassLibrary {
    public interface IHelper {

        void ControlsOfType<T>(Control parent, List<T> found);
        void UpdateKeyText(Button button, string pattern, string replace, bool append);
        void DisableKeys(IEnumerable<Button> keys, IButtonTracker tracker);
        void EnableKeys(IEnumerable<Button> keys, IButtonTracker tracker);
        void CenterToPoint(Control parent, Point point);
        void CenterToScreen(Control parent);
        void ScaleTo(Control parent, int width, int height, bool center = true);
        void SetHeight(Control control, int height);
        void AddLabel(Panel panel, string text, int fontSize, int leftMargin, int topMargin);
        Rectangle GetViewport(Form form);
        Point GetPointerLocation(MouseEventArgs e);
        bool ContainsPointer(Control control, Point cursor);
        void DragWindow(MouseEventArgs e, Form parent, Point pointer);
        void ButtonMouseEnter(object sender, EventArgs e);
        void ButtonMouseLeave(object sender, EventArgs e);
        void DrawUnderline(object sender, PaintEventArgs e);
        void RaiseButtonEvent(object sender, EventArgs e, EventHandler handler, IButtonTracker tracker);
    }
}