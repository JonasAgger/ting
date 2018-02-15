using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace I4GUI
{
    public class Agents : ObservableCollection<Agent>
    {
    };  // Just to reference it from xaml

   [Serializable]
   public class Agent : INotifyPropertyChanged
   {
      string id;
      string codeName;
      string speciality;
      string assignment;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Agent()
        {
            codeName = "New Agent";
        }

      public Agent(string aId, string aName, string aAddress, string aSpeciality, string aAssignment)
      {
         id = aId;
         codeName = aName;
         speciality = aSpeciality;
         assignment = aAssignment;
      }

      public string ID
      {
         get
         {
            return id;
         }
         set
         {
            id = value;
             Notify("ID");
            }
      }

      public string CodeName
      {
         get
         {
            return codeName;
         }
         set
         {
            codeName = value;
             Notify("CodeName");
            }
      }

      public string Speciality
      {
         get
         {
            return speciality;
         }
         set
         {
            speciality = value;
             Notify("Speciality");
            }
      }

      public string Assignment
      {
         get
         {
            return assignment;
         }
         set
         {
             assignment = value;
             Notify("Assignment");
         }
      }
   }
}
