using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ISim.SchematicEditor
{
    public class IDProvider
    {
        private List<ID> IDs = new List<ID>();
        private double MaxStringCount = 32;


        private static IDProvider instance;
        public static IDProvider getInstance()
        {
            if (instance == null) instance = new IDProvider();
            return instance;
        }
        private IDProvider() { }


        public string getNewIDFor(ICountableID Object)
        {
            ID newID = new ID(Object, "");
            while (true) { newID.Id = GenerateRandomString(); if (!IDs.Contains(newID)) break; }
            if (IDs.Contains(null))
            {
                IDs[IDs.IndexOf(null)] = newID;
                return newID.Id;
            }
            IDs.Add(newID);
            return newID.Id;
        }
        public bool deleteElementByID(string Id)
        {
            for (int i = 0; i < IDs.Count; i++)
            {
                if (IDs[i].Id == Id)
                {
                    IDs.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool deleteElementByObject(ICountableID Object)
        {
            for (int i = 0; i < IDs.Count; i++)
            {
                if (IDs[i].Object == Object)
                {
                    IDs.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public ICountableID getElementByID(string Id)
        {
            foreach (ID obj in IDs)
            {
                if (obj.Id == Id) return obj.Object;
            }
            return null;
        }

        private string GenerateRandomString()
        {
            string ret = string.Empty;
            Random rnd = new Random();
            for (int i = 0; i < MaxStringCount; i++)
            {
                ret = ret + Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65))).ToString();
            }
            return ret;
        }
        private class ID
        {
            public ICountableID Object { get; set; }
            public string Id { get; set; }
            public ID(ICountableID @object, string id)
            {
                Object = @object;
                Id = id;
            }
        }
    }


}
