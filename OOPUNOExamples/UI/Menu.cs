using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPUNOExamples.UI
{
    public abstract class Menu : Screen
    {
        internal Menu(string title, string body, List<object> options) : base(title, body)
        {
            this.options = options ?? new List<object>();
            SelectedIndex = 0;
        }
        protected List<object> options;
        internal static bool menuLoopControl = true;
        protected int selectedIndex;
        protected int SelectedIndex
        {
            get { return this.selectedIndex; }
            set
            {
                if (value < 0)
                {
                    this.selectedIndex = 0;
                } else if (value > this.options.Count()-1)
                {
                    this.SelectedIndex= this.options.Count()-1;
                } else
                {
                    this.selectedIndex = value;
                }
            }
        }
        internal override void Draw()
        {
            base.Draw();
            foreach (var option in options)
            {
                if (option == options[SelectedIndex])
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.WriteLine("{0," + GetCenterPlacement(option.ToString()) + "}\n", option.ToString());
                Console.ResetColor();
            }
        }
    }
}