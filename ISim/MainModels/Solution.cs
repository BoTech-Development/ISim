using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.MainModels
{
    internal class Solution
    {
        public string Name { get; set; } = string.Empty;   
        public List<string> parthToProjects { get; set; } = new List<string>();
        public string SolutionMode { get; set; } = string.Empty;
        public List<Extension> requiredExtensions { get; set; } = new List<Extension>();

        public Solution(string name, List<string> parthToProjects, string solutionMode, List<Extension> requiredExtensions)
        {
            Name = name;
            this.parthToProjects = parthToProjects;
            SolutionMode = solutionMode;
            this.requiredExtensions = requiredExtensions;
        }
    }
}
