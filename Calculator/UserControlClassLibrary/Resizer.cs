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

        public Resizer(Form form) {

            Keys = new int[] { 13, 14, 16, 17, 10, 11, 12, 15 };
            GetBoxes(form);
        }

        private void GetBoxes(Form form) {

            const int thick = 15;
            Boxes = new Dictionary<int, Func<Rectangle>>();

            Boxes[Keys[0]] = () => new Rectangle(0, 0, thick, thick);
            Boxes[Keys[1]] = () => new Rectangle(form.ClientSize.Width - thick, 0, thick, thick);
            Boxes[Keys[2]] = () => new Rectangle(0, form.ClientSize.Height - thick, thick, thick);
            Boxes[Keys[3]] = () => new Rectangle(form.ClientSize.Width - thick, form.ClientSize.Height - thick, thick, thick);
            Boxes[Keys[4]] = () => new Rectangle(0, 0, thick, form.ClientSize.Height);
            Boxes[Keys[5]] = () => new Rectangle(form.ClientSize.Width - thick, 0, thick, form.ClientSize.Height);
            Boxes[Keys[6]] = () => new Rectangle(0, 0, form.ClientSize.Width, thick);
            Boxes[Keys[7]] = () => new Rectangle(0, form.ClientSize.Height - thick, form.ClientSize.Width, thick);
        }
    }
}