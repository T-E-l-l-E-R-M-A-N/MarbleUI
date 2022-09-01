using System;
using System.Collections.Generic;
using System.Text;

namespace MarbleUI.Controls
{
    public interface IMenuItemObject
    {

        public bool IsCheckable { get; set; }

        public bool IsChecked {get; set; }

        public bool IsRadioButtonMode { get; set; }
        public string Group { get; set; }
    }
}
