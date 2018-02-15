using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    class Budfirma
    {

        public class Rootobject
        {
            public Cykelbud Cykelbud { get; set; }
            public Budcentral Budcentral { get; set; }
            public Adresse Adresse { get; set; }
            public By By { get; set; }
            public Cykel Cykel { get; set; }
        }

        public class Cykelbud
        {
            public object Budnummer { get; set; }
            public object Fornavn { get; set; }
            public object Efternavn { get; set; }
            public object[] Cykel { get; set; }
            public object Budcentral { get; set; }
        }

        public class Budcentral
        {
            public object Navn { get; set; }
            public object Adresse { get; set; }
            public object[] Cykelbud { get; set; }
            public object[] Cykel { get; set; }
        }

        public class Adresse
        {
            public object VejNavn { get; set; }
            public object Nummer { get; set; }
            public object By { get; set; }
        }

        public class By
        {
            public Navn Navn { get; set; }
        }

        public class Navn
        {
            public string Type { get; set; }
        }

        public class Cykel
        {
            public int Stelnummer { get; set; }
            public object Type { get; set; }
        }

    }
}
