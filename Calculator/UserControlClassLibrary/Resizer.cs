using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UserControlClassLibrary {
    public class Resizer : IResize {

        public int[] Keys { get; private set; }
        public Dictionary<int, Func<Rectangle>> Boxes { get; private set; }

        public Resizer(Form form, int thickness = 15) {

            Keys = new int[] { 13, 14, 16, 17, 10, 11, 12, 15 };
            GetBoxes(form, thickness);
        }

        private void GetBoxes(Form form, int thickness) {

            Boxes = new Dictionary<int, Func<Rectangle>>();

            Boxes[Keys[0]] = () => new Rectangle(0, 0, thickness, thickness);
            Boxes[Keys[1]] = () => new Rectangle(form.ClientSize.Width - thickness, 0, thickness, thickness);
            Boxes[Keys[2]] = () => new Rectangle(0, form.ClientSize.Height - thickness, thickness, thickness);
            Boxes[Keys[3]] = () => new Rectangle(form.ClientSize.Width - thickness, form.ClientSize.Height - thickness, thickness, thickness);
            Boxes[Keys[4]] = () => new Rectangle(0, 0, thickness, form.ClientSize.Height);
            Boxes[Keys[5]] = () => new Rectangle(form.ClientSize.Width - thickness, 0, thickness, form.ClientSize.Height);
            Boxes[Keys[6]] = () => new Rectangle(0, 0, form.ClientSize.Width, thickness);
            Boxes[Keys[7]] = () => new Rectangle(0, form.ClientSize.Height - thickness, form.ClientSize.Width, thickness);
        }
    }
}