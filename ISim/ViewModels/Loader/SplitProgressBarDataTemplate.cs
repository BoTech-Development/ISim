using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.ViewModels.Loader
{
    public class SplitProgressBarDataTemplate : ProgressBarDataTemplate
    {
        // public ProgressBarStatus overallStatus {  get; set; } = ProgressBarStatus.Initialization;
        public string taskDescription { get; set; } = "Info not set yet. Please Wait...";

        public SplitProgressBarDataTemplate(string taskDescription, string status, int max, int min, bool visible, int value) : base( status, max, min, visible, value)
        {
            this.taskDescription = taskDescription;
        }
    }
}
