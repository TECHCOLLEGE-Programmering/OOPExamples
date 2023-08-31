using OOPUNOExamples.Classes;
using OOPUNOExamples.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPUNOExamples.Interfaces
{
    internal interface IMenu : IScreen
    {
        List<MenuOption> menuOptions { get; set; }
        public void MenuControl();
    }
}
