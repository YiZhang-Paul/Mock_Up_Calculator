using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlClassLibrary;

namespace MockUpCalculator {
    public interface ICalculatorPanel : IResizable {

        void ToggleMemoryPanel(object sender, EventArgs e);
        void ToggleHistoryPanel(object sender, EventArgs e);
        void DeactivateBackPanel();
    }
}