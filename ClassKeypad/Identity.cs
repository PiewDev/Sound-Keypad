using System;
using System.Collections.Generic;
using System.Text;

namespace ClassKeypad
{
    public abstract class Identity
    {
        private string Id;
        public Identity()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public override bool Equals(object obj)
        {
            var obje = obj as Identity;
            if (obje == null)
                return false;           
            if (obje.Id == this.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
