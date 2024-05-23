using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.ViewModels.Loader
{
    public class ProgressBarDataTemplate
    {
        public ProgressBarStatus thisStatus {  get; set; } = ProgressBarStatus.Initialization;
        public string status {  get; set; }
        public int max { get; set; } = 100; // set to 100 which is equal to 100%
        public int min { get; set; } = 0;
        public bool visible { get; set; } = false;

        public int value { get; set; } = 0;

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int value)
        {
            if (!(value >= 101)) this.value = value; else throw new ArgumentException(String.Format("You can not set the Progress Bar to {num} !", value));
        }

        public ProgressBarDataTemplate(string status, int max, int min, bool visible, int value)
        {
            this.status = status;
            this.max = max;
            this.min = min;
            this.visible = visible;
            SetValue(value); // check if the value is valid
        }
    }
}
