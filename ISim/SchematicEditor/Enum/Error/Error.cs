 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Enum.Error
{
    public enum Error
    {
        None = 0, NotDefined = -1, ObjectSetToNull = -2
    }
    public enum FileError
    {
        None = 0, NotDefined = -1, ResultObjectSetToNull = -2, FileNotFound = -3, DirNotFound = -4, ErrorByLoadingAssembly = -5, JsonDeserializeObjectError = -6, JsonSeserializeObjectError = -7
    }
}
