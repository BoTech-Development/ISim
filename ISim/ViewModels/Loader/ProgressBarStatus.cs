using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.ViewModels.Loader
{
    public enum ProgressBarStatus
    {
        Working, // Background Process is working on the task
        Fail, // Background Process failed to run the Task correctly
        Finished, // The Background Process has correctly executed the Task
        Ready, // The Background Process is halted.
        Initialization // The Background process Init itself => loading the Task 
    }
}
