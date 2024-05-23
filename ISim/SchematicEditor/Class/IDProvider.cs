using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Info: has the control over all Id's in the Simulation and schematic
 * 
 * 
 */
namespace ISim.SchematicEditor.Class
{
    public class IDProvider
    {
        static IDProvider idProvider = null; 
        private IDProvider()
        {
            
        }
        public static IDProvider getIDProvider()
        {
            if (idProvider == null)
            {
                idProvider = new IDProvider();
            }
          
            return idProvider;
        }
        private int MaxStringCount = 16;
        private List<string> busIds = new List<string>();
        private List<string> PinIds = new List<string>();
        private List<string> WireIds = new List<string>();
        private List<string> ComponentIds = new List<string>();

        public string getNewIDForBus()
        {
            string newID = string.Empty;
            while (true) { newID = GenerateRandomString(); if (!busIds.Contains(newID)) break; }
            if (busIds.Contains(null))
            {
                busIds[busIds.IndexOf(null)] = newID;
                return newID;
            }
            busIds.Add(newID); 
            return newID;
        }
        public int DeleteIDForBus(string id)
        {
            if (busIds.Contains(id))
            {
                busIds[busIds.IndexOf(id)] = null;
                return 1;
            }
            return -1;

        }

        public string getNewIDForPin()
        {
            string newID = string.Empty;
            while (true) { newID = GenerateRandomString(); if (!PinIds.Contains(newID)) break; }
            if (PinIds.Contains(null))
            {
                PinIds[PinIds.IndexOf(null)] = newID;
                return newID;
            }
            PinIds.Add(newID);
            return newID;
        }
        public int DeleteIDForPin(string id)
        {
            if (PinIds.Contains(id))
            {
                PinIds[PinIds.IndexOf(id)] = null;
                return 1;
            }
            return -1;
        }

        public string getNewIDForWire()
        {
            string newID = string.Empty;
            while (true) { newID = GenerateRandomString(); if (!WireIds.Contains(newID)) break; }
            if (WireIds.Contains(null))
            {
                WireIds[busIds.IndexOf(null)] = newID;
                return newID;
            }
            WireIds.Add(newID);
            return newID;
        }
        public int DeleteIDForWire(string id)
        {
            if (WireIds.Contains(id))
            {
                WireIds[busIds.IndexOf(id)] = null;
                return 1;
            }
            return -1;
        }

        public string getNewIDForComponent()
        {
            string newID = string.Empty;
            while (true) { newID = GenerateRandomString(); if (!ComponentIds.Contains(newID)) break; }
            if (ComponentIds.Contains(null))
            {
                ComponentIds[ComponentIds.IndexOf(null)] = newID;
                return newID;
            }
            ComponentIds.Add(newID);
            return newID;
        }
        public int DeleteIDForComponent(string id)
        {
            if (ComponentIds.Contains(id))
            {
                ComponentIds[ComponentIds.IndexOf(id)] = null;
                return 1;
            }
            return -1;
        }

        private string GenerateRandomString()
        {
            string ret = string.Empty;
            Random rnd = new Random();
            for(int i= 0; i < MaxStringCount; i++)
            {
                ret = ret + Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65))).ToString();
            }
            return ret;
        }
    }
}
